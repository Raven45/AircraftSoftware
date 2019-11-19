using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aircraft.Test
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
