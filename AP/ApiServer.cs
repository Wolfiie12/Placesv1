using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.SelfHost;
using System.Web.Routing;
using System.Runtime.Serialization;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web;
using System.Net;

/*
   Packages required
   ASP.NET Web API Self Host
   https://nuget.org/packages/AspNetWebApi.SelfHost
   Package Manager Console command line: Install-Package AspNetWebApi.SelfHost 
 */

namespace ApiServer
{
    class ApiServer
    {
        static void Main(string[] args)
        {
            var baseAddress = "http://localhost:8080/";
            var selfHostconfiguration = new HttpSelfHostConfiguration(baseAddress);
            selfHostconfiguration.Routes.MapHttpRoute(
                name: "UserApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var server = new HttpSelfHostServer(selfHostconfiguration);
            server.OpenAsync().Wait();
            Console.WriteLine("ASP.NET Web API Server Running...");
            Console.WriteLine("Listening at " + baseAddress);
            Console.WriteLine("");
            Console.ReadLine();
        }
    }
}