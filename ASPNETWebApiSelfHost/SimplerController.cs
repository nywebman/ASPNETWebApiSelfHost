using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http;

namespace ASPNETWebApiSelfHost
{
    class SimplerController :ApiController
    {
        public IEnumerable<string> Get()
        {
            return new string[] { "Hello", "Controller API" };
        }
    }
}
