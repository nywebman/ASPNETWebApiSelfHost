using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http.SelfHost;
using System.Web.Http;
using System.Net.Http;

namespace ASPNETWebApiSelfHost
{
    public class Program
    {
        static void Main(string[] args) 
        {
            //var config = new HttpSelfHostConfiguration("http://localhost:8999");
            var config = new MyConfig("http://localhost:8999");
            config.Routes.MapHttpRoute(
                "DefaultRoute", "{controller}/{id}",
                new { id = RouteParameter.Optional });
            //custom message processing
            //var server = new HttpSelfHostServer(config,
            //    new MyNewSimpleMessagehandler());

            //controller message processing
            var server = new HttpSelfHostServer(config,
                new MyNewSimpleMessagehandler());

            server.OpenAsync();

            //trick, calls server just created to  confirm it works
            var client = new HttpClient(server);
            client.GetAsync("http://localhost:8999/simple")
                .ContinueWith((t) =>
                    {
                        var result = t.Result;
                        result.Content.ReadAsStringAsync()
                            .ContinueWith((rt) => {
                                Console.WriteLine("Client got " + rt.Result);
                    });
                });
            //

            Console.WriteLine("opening web api selfhost ");
            Console.ReadKey();
        }
    }
}
