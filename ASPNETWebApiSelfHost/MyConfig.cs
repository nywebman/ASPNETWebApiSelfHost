using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http.SelfHost;
using System.ServiceModel.Channels;
using System.Web.Http.SelfHost.Channels;
using System.ServiceModel;

namespace ASPNETWebApiSelfHost
{
    public class MyConfig : HttpSelfHostConfiguration
    {
        protected override BindingParameterCollection OnConfigureBinding(HttpBinding httpBinding)
        {

            httpBinding.Security.Mode = HttpBindingSecurityMode.TransportCredentialOnly;
            httpBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Windows;
            return base.OnConfigureBinding(httpBinding);
        }
        public MyConfig(string uri) : base(uri)
        {

        }
    }
}
