using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlAccess
{
    public class EventLogStatus
    {
        public void EventLogStop()
        {
            string UserID = Environment.UserName;
            string Event = "Внимание: Пользователь остановил работу сервера. Имя пользователя " + UserID;
            string Source = "AppStopWork";
            string Log = "App";
            if (!EventLog.SourceExists(Source))
                EventLog.CreateEventSource(Source, Log);
            using (EventLog eventLog = new EventLog("App"))
            {
                eventLog.Source = "AppStopWork"; //название источника лога
                eventLog.WriteEntry(Event, EventLogEntryType.Warning);
                return;
            }
        }
         public void EventLogStart()
        {
            string UserID = Environment.UserName;
            string Event = "Внимание: Пользователь возобновил работу сервера. Имя пользователя " + UserID;
            string Source = "AppStopWork";
            string Log = "App";
            if (!EventLog.SourceExists(Source))
                EventLog.CreateEventSource(Source, Log);
            using (EventLog eventLog = new EventLog("App"))
            {
                eventLog.Source = "AppStopWork"; //название источника лога
                eventLog.WriteEntry(Event, EventLogEntryType.Information);
            }
         }
    }
}
