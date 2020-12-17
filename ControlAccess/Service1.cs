using System;
using System.ServiceProcess;
using System.ServiceModel;


namespace ControlAccess
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }
        public class StartService
        {
            public void startService()
            {
                ServiceHost host = new ServiceHost(typeof(MyService), new Uri("http://localhost:8000/MyService"));                      
                host.AddServiceEndpoint(typeof(ServiceApp), new BasicHttpBinding(), "");                                                   
                host.Open();                                                                                                      
            }       
        }

        [ServiceContract]
        public interface ServiceApp
        {
            [OperationContract]
            int serviceOff(int status);

            [OperationContract]
            string currentStatus(string currStatus);
        }
        public class MyService : ServiceApp                                                                                   
        {
            public int serviceOff(int status)
            {
                ServiceStatus scStatus = new ServiceStatus();
                scStatus.serviceStatus();

                return status;
            }
            public string currentStatus(string currStatus)
            {
                string status;
                ServiceController sc = new ServiceController("TermService");
                status = sc.Status.ToString();

                return currStatus + status;
            }          
        }

        public class StopService
        {
            public void stopService()
            {

            }
        }      
        protected override void OnStart(string[] args)
        {
            StartService start = new StartService();
            start.startService();
        }

        protected override void OnStop()
        {
            StopService stop = new StopService();
            stop.stopService();
        }
    }
}
