Declare
@LS_DatabaseName					Varchar(1000), 
@LS_CreationDate					DateTime,
@LS_DataFile						Varchar(1000),
@LS_LogFile							Varchar(1000),

@LS_SQLExecuteString				nVarchar(Max),
@LS_ParameterDefinition				nVarchar(Max)

Declare 
@LS_Table Table
(
	DatabaseName			Varchar(1000),
	CreationDate			DateTime,
	DataFile				Varchar(1000),
	Logfile					Varchar(1000)
)

Insert Into @LS_Table (
	DatabaseName,
	CreationDate
) Select
	name, 
	Create_Date 
From 
	sys.databases
Where
	name <> 'master' And
	name <> 'tempdb' And
	name <> 'model' And
	name <> 'msdb' And
	state_desc = 'ONLINE' And
	is_read_only = 0		


Declare Database_CSR Cursor Local Fast_Forward Read_Only
For
	Select
		DatabaseName,
		CreationDate
	From
		@LS_Table
	Order By
		DatabaseName

Open Database_CSR

Fetch Next From Database_CSR Into
	@LS_DatabaseName, @LS_CreationDate

While @@Fetch_Status = 0
Begin
	-- Get Data File
	Select @LS_SQLExecuteString='',@LS_ParameterDefinition=''
	Select @LS_SQLExecuteString=N'Select @LS_DataFile = physical_name From '+@LS_DatabaseName+'.sys.database_files where type = 0'
	Select @LS_ParameterDefinition=N'@LS_DataFile	Varchar(1000) Output'
	
	Execute sp_ExecuteSQL @LS_SQLExecuteString,
		@LS_ParameterDefinition,
		@LS_DataFile Output
	
	-- Get Log File
	Select @LS_SQLExecuteString='',@LS_ParameterDefinition=''
	Select @LS_SQLExecuteString=N'Select @LS_LogFile = physical_name From '+@LS_DatabaseName+'.sys.database_files where type = 1'
	Select @LS_ParameterDefinition=N'@LS_LogFile	Varchar(1000) Output'
	
	Execute sp_ExecuteSQL @LS_SQLExecuteString,
		@LS_ParameterDefinition,
		@LS_LogFile Output
	
	Update @LS_Table Set DataFile = @LS_DataFile, Logfile = @LS_LogFile Where DatabaseName = @LS_DatabaseName
	
	Fetch Next From Database_CSR Into
		@LS_DatabaseName, @LS_CreationDate
End
Close Database_CSR
DeAllocate Database_CSR

Select * From @LS_Table