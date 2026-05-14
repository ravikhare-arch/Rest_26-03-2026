using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.SelfHost;

namespace PrintService
{
    public partial class PrintSelfHostService : ServiceBase
    {
        public PrintSelfHostService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {

            var config = new HttpSelfHostConfiguration("http://127.0.0.1:8085");

            config.Routes.MapHttpRoute(
                "API Default", "api/{controller}/{action}/{id}",
                new { id = RouteParameter.Optional });
            HttpSelfHostServer server = new HttpSelfHostServer(config);
                 server.OpenAsync().Wait();
            //using (HttpSelfHostServer server = new HttpSelfHostServer(config))
            //{
            //    server.OpenAsync().Wait();
            //    //Console.WriteLine("Press Enter to quit.");
            //    //Console.ReadLine();
            //}
        }

        protected override void OnStop()
        {
        }
    }
}
