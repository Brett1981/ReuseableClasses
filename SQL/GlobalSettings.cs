using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Re_useable_Classes.SQL
{
    public static class GlobalSettings
    {
        //Build Constructors
        public static string VersionNo = "1.01";

        public static string AEntryId;
        public static Form AFrmEvents { get; set; }

        //Connection Constructors
        public static bool IsLoading { get; set; }

        public static bool IsDevMode { get; set; }
        public static Connection AConnection { get; set; }
        public static string ADatabase { get; set; }
        public static string APassword { get; set; }
        public static string AServer { get; set; }
        public static string AType { get; set; }
        public static string AUser { get; set; }
        public static string AAuthKey { get; set; }
        public static string AIpAddress { get; set; }

        //Validation Constructors
        public static float AOrderNo { get; set; }

        public static string APacks { get; set; }
        public static string AWeight { get; set; }
        public static string AServiceCode { get; set; }
        public static string ACustomer { get; set; }
        public static float AOhPrimary { get; set; }
        public static int ACustomerOnStop { get; set; }
        public static int ALinesInvd { get; set; }
        public static int ALinesDlvd { get; set; }

        //Temporary Results Table
        public static DataTable ASqlResultsTable { get; set; }

        //Stored Procedure Variables
        public static string AStoredProc { get; set; }

        public static string AVarOrderPrim { get; set; }
        public static string AVarOrderNumber { get; set; }
        public static string AVarPacks { get; set; }
        public static string AVarWeight { get; set; }
        public static string AVarServiceCode { get; set; }
        public static string AVarError { get; set; }
        public static List<string> AIpAddressList { get; set; }
        public static DateTime ADateFrom { get; set; }
        public static DateTime ADateTo { get; set; }
        public static bool DatesValid { get; set; }
        public static DataTable CalendarData { get; set; }
    }
}