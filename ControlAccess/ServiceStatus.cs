using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace ControlAccess
{
    class ServiceStatus
    {
        public void serviceStatus()
        {
            ServiceController sc = new ServiceController("TermService");
            sc.Status.ToString();

            if ((sc.Status.Equals(ServiceControllerStatus.Stopped)) ||
             (sc.Status.Equals(ServiceControllerStatus.StopPending)))
            {
                sc.Start();
                sc.Refresh();

                EventLogStatus evetnLogStatus = new EventLogStatus();
                evetnLogStatus.EventLogStart();

                sc.Status.ToString();
                sc.Close();

                return;
            }
            else
            {
                EventLogStatus evetnLogStatus = new EventLogStatus();
                evetnLogStatus.EventLogStop();

                sc.Stop();
            }            
            sc.Refresh();

        }
    }
}
