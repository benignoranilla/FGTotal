using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FGTotal.Services
{
    public class URLService 
    {
        private HttpClient client;
        
        private static string URL = "http://projectwebapiloadbalancer-1962764078.us-east-2.elb.amazonaws.com/api/";

        public static string ObtenerURLBase
        {
            get { return URL; }
            set { URL = value; }
        }

        //public string ObtenerURL()
        //{
        //    URL = "http://projectwebapiloadbalancer-1962764078.us-east-2.elb.amazonaws.com/api/";
        //
        //    return URL;
        //}
        //
        //private HttpClient GetClient()
        //{
        //    if (client != null)
        //    {
        //        client = new HttpClient();
        //        client.BaseAddress = new Uri("http://projectwebapiloadbalancer-1962764078.us-east-2.elb.amazonaws.com/api/");
        //    }
        //    return client;
        //}

    }
}
