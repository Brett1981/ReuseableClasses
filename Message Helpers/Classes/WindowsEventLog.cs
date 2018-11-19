namespace Re_useable_Classes.Message_Helpers.Classes
{
    public class WindowsEventLog
    {
        public static void WriteEventLogEntry(string message, string appName)
        {
            // Create an instance of EventLog
            System.Diagnostics.EventLog eventLog = new System.Diagnostics.EventLog();

            // Check if the event source exists. If not create it.
            if (!System.Diagnostics.EventLog.SourceExists(appName))
            {
                System.Diagnostics.EventLog.CreateEventSource(appName, "Application");
            }

            // Set the source name for writing log entries.
            eventLog.Source = appName;

            // Create an event ID to add to the event log
            int eventId = 8;

            // Write an entry to the event log.
            eventLog.WriteEntry(message,
                                System.Diagnostics.EventLogEntryType.Error,
                                eventId);

            // Close the Event Log
            eventLog.Close();
        }
    }
}