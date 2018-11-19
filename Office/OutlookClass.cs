using Microsoft.Office.Interop.Outlook;
using System;
using System.Data;
using System.Windows.Forms;
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
            var codePanel = new DataTable(); //CodePanel Data
            codePanel.Columns.Add
                (
                    "Subject",
                    typeof(string));
            codePanel.Columns.Add
                (
                    "Location",
                    typeof(string));
            codePanel.Columns.Add
                (
                    "StartTime",
                    typeof(DateTime));
            codePanel.Columns.Add
                (
                    "EndTime",
                    typeof(DateTime));
            codePanel.Columns.Add
                (
                    "StartDate",
                    typeof(DateTime));
            codePanel.Columns.Add
                (
                    "EndDate",
                    typeof(DateTime));
            codePanel.Columns.Add
                (
                    "AllDayEvent",
                    typeof(bool));
            codePanel.Columns.Add
                (
                    "Body",
                    typeof(string));

            ListViewContacts = new ListView();
            OApp = new Application();
            ONs = OApp.GetNamespace("MAPI");
            OCalenderFolder = ONs.GetDefaultFolder(OlDefaultFolders.olFolderCalendar);
            OutlookCalendarItems = OCalenderFolder.Items;
            OutlookCalendarItems.IncludeRecurrences = true;
            // DataTable CodePanel = new DataTable();
            foreach (AppointmentItem item in OutlookCalendarItems)
            {
                DataRow row = codePanel.NewRow();
                row["Subject"] = item.Subject;
                row["Location"] = item.Location;
                row["StartTime"] = item.Start.TimeOfDay.ToString();
                row["EndTime"] = item.End.TimeOfDay.ToString();
                row["StartDate"] = item.Start.Date;
                row["EndDate"] = item.End.Date;
                row["AllDayEvent"] = item.AllDayEvent;
                row["Body"] = item.Body;
                codePanel.Rows.Add(row);
            }
            codePanel.AcceptChanges();
            foreach (DataRow dr in codePanel.Rows)
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
            return codePanel;
        }
    }
}