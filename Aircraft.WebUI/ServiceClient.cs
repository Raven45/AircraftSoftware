using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aircraft.WebUI
{
    public class ServiceClient
    {

        public static ServiceReference1.Service1Client GetClient()
        {
            var client = new ServiceReference1.Service1Client();
            return client;
        }
    }
}