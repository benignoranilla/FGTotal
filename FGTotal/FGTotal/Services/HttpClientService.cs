using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace FGTotal.Services
{
    public class HttpClientService
    {
        public static HttpClientService Instance
        {
            get
            {
                return Instance;
            }
        }

        private static readonly HttpClientService instance = new HttpClientService();
        private HttpClient client;

        public async Task<HttpResponseMessage> GetAsync(string api)
        {
            HttpClient client = GetClient();
            HttpResponseMessage response = await client.GetAsync(api);
            return response;
        }

        private HttpClient GetClient()
        {
            if (client != null)
            {
                client = new HttpClient();
                client.BaseAddress = new Uri("http://projectwebapiloadbalancer-1962764078.us-east-2.elb.amazonaws.com/api/");
            }
            return client;
        }
    }
}