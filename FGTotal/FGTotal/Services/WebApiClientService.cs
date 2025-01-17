﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FGTotal.Services
{
    public class WebApiClientService
    {
        Uri urlBase = new Uri("http://projectwebapiloadbalancer-1962764078.us-east-2.elb.amazonaws.com/api/");

        public async Task<T> executeRequestPost<T>(object objectParams)
        {
            string requestUri = "DM/ObtenerDetalleMensaje/J";

            var client = new HttpClient();
            client.BaseAddress = urlBase;
            string jsonData = JsonConvert.SerializeObject(objectParams);

            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(requestUri, content).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(json);
            }
            else
            {
                return default(T);
            }

        }
    }
}
