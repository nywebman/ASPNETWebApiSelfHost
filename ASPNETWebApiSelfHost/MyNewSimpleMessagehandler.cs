using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;

namespace ASPNETWebApiSelfHost
{
    class MyNewSimpleMessagehandler : HttpMessageHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, 
            CancellationToken cancellationToken)
        {
            Console.WriteLine("received an http message");
            var t = new Task<HttpResponseMessage>((msg) =>
                {
                    var up = System.Threading.Thread.CurrentPrincipal;
                    var r = new HttpResponseMessage();
                    r.Content = new StringContent("Hello self hosting " + up.Identity.Name);
                    Console.WriteLine("http response sent");
                    return r;

                },new object().ToString());
            t.Start();
            return t;

        }
    }
}
