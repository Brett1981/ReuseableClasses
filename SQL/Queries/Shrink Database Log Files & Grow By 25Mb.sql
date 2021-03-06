Use master

Declare
@LS_DatabaseName					Varchar(500),
@LS_LogFileName						nVarchar(500),
@LS_SQLExecuteString				nVarchar(MAX),
@LS_ParameterDefinition				nVarchar(MAX)

-- Create Cursor Of All Databases To Shrink
Declare Databases_Csr cursor Local Fast_Forward Read_only
For
	Select
		name
	From 
		sys.databases
	Where
		name <> 'master' And
		name <> 'tempdb' And
		name <> 'model' And
		name <> 'msdb' And
		state_desc = 'ONLINE' And
		is_read_only = 0		

Open Databases_Csr

Fetch Next From Databases_Csr Into @LS_DatabaseName

While @@Fetch_Status = 0
Begin
		-- Retrieve Log File Name
		Select @LS_SQLExecuteString='', @LS_ParameterDefinition=''
		Select @LS_SQLExecuteString = N'Select @LS_LogFileName = name From ' + @LS_DatabaseName + '.sys.database_files Where type_desc = ''LOG'' '
		Select @LS_ParameterDefinition=N'@LS_LogFileName		nVarchar(500) Output'
		
		Begin Try 
			Execute sp_ExecuteSQL @LS_SQLExecuteString, @LS_ParameterDefinition, @LS_LogFileName Output
		End Try
		
		Begin Catch
			Print Error_Message()
			GoTo Fetch_Next
		End Catch

		-- Run DBCC to shrink the log file
		Select @LS_SQLExecuteString='', @LS_ParameterDefinition=''
		Select @LS_SQLExecuteString = N'Use ' + @LS_DatabaseName + ' DBCC SHRINKFILE (' + @LS_LogFileName + ', 50)'
		Select @LS_ParameterDefinition=N'@LS_LogFileName		nVarchar(500)'
		
		Begin Try 
			Execute sp_ExecuteSQL @LS_SQLExecuteString, @LS_ParameterDefinition, @LS_LogFileName
		End Try
		
		Begin Catch
			Print Error_Message()
			GoTo Fetch_Next
		End Catch
		
		-- Change File Growth To Grow In 25Mb Chunks
		Select @LS_SQLExecuteString='', @LS_ParameterDefinition=''
		Select @LS_SQLExecuteString = N'Alter Database ' + @LS_DatabaseName + ' MODIFY FILE ( NAME = N''' + @LS_LogFileName + ''', FILEGROWTH = 25600KB )'
		Select @LS_ParameterDefinition=N'@LS_LogFileName		nVarchar(500)'
		
		Begin Try 
			Execute sp_ExecuteSQL @LS_SQLExecuteString, @LS_ParameterDefinition, @LS_LogFileName
		End Try
		
		Begin Catch
			Print Error_Message()
			GoTo Fetch_Next
		End Catch
		
	Fetch_Next:
		Fetch Next From Databases_Csr Into @LS_DatabaseName
End

Close Databases_Csr

DeAllocate Databases_Csr