using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Office.Interop.Outlook;
using Application = Microsoft.Office.Interop.Outlook.Application;

namespace Re_useable_Classes.Office
{
    public class OutlookClass
    {
        private Application OApp { get; set; }
        public ListView ListViewContacts { get; set; }
        private NameSpace ONs { get; set; }
        private MAPIFolder OCalenderFolder { get; set; }
        public Items OutlookCalendarItems { get; set; }

        public DataTable GetAllCalendarItems()
        {
            var CodePanel = new DataTable(); //CodePanel Data
            CodePanel.Columns.Add
                (
                    "Subject",
                    typeof (string));
            CodePanel.Columns.Add
                (
                    "Location",
                    typeof (string));
            CodePanel.Columns.Add
                (
                    "StartTime",
                    typeof (DateTime));
            CodePanel.Columns.Add
                (
                    "EndTime",
                    typeof (DateTime));
            CodePanel.Columns.Add
                (
                    "StartDate",
                    typeof (DateTime));
            CodePanel.Columns.Add
                (
                    "EndDate",
                    typeof (DateTime));
            CodePanel.Columns.Add
                (
                    "AllDayEvent",
                    typeof (bool));
            CodePanel.Columns.Add
                (
                    "Body",
                    typeof (string));

            ListViewContacts = new ListView();
            OApp = new Application();
            ONs = OApp.GetNamespace("MAPI");
            OCalenderFolder = ONs.GetDefaultFolder(OlDefaultFolders.olFolderCalendar);
            OutlookCalendarItems = OCalenderFolder.Items;
            OutlookCalendarItems.IncludeRecurrences = true;
            // DataTable CodePanel = new DataTable();
            foreach (AppointmentItem item in OutlookCalendarItems)
            {
                DataRow row = CodePanel.NewRow();
                row["Subject"] = item.Subject;
                row["Location"] = item.Location;
                row["StartTime"] = item.Start.TimeOfDay.ToString();
                row["EndTime"] = item.End.TimeOfDay.ToString();
                row["StartDate"] = item.Start.Date;
                row["EndDate"] = item.End.Date;
                row["AllDayEvent"] = item.AllDayEvent;
                row["Body"] = item.Body;
                CodePanel.Rows.Add(row);
            }
            CodePanel.AcceptChanges();
            foreach (DataRow dr in CodePanel.Rows)
            {
                var lvi = new ListViewItem(dr["Subject"].ToString());

                lvi.SubItems.Add(dr["Location"].ToString());
                lvi.SubItems.Add(dr["StartTime"].ToString());
                lvi.SubItems.Add(dr["EndTime"].ToString());
                lvi.SubItems.Add(dr["StartDate"].ToString());
                lvi.SubItems.Add(dr["EndDate"].ToString());
                lvi.SubItems.Add(dr["AllDayEvent"].ToString());
                lvi.SubItems.Add(dr["Body"].ToString());


                ListViewContacts.Items.Add(lvi);
            }
            OApp = null;
            ONs = null;
            return CodePanel;
        }
    }
}
