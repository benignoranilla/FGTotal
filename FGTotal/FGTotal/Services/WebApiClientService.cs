﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace FGTotal.Services
{
    public class WebApiClientService
    {
        Uri urlBase = new Uri("http://projectwebapi-1533273939.us-east-2.elb.amazonaws.com/api/");

        public async Task<T> executeRequestPost<T>(object objectParams)
        {
            string tipoJugador = Preferences.Get("tipoUsuario", string.Empty);
            string requestUri = "DM/ObtenerDetalleMensaje/" + tipoJugador;

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
        public async Task<T> ObtenerBandejaMensajeJugadorGet<T>()
        {

            string id = Preferences.Get("idLogin", string.Empty);
            string requestUri = "DM/ObtenerBandejaMensaje/" + id;

            var client = new HttpClient();

            client.BaseAddress = urlBase;

            HttpResponseMessage response = await client.GetAsync(requestUri).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var _json = JsonConvert.DeserializeObject<T>(json);
                return _json;
            }
            else
            {
                return default(T);
            }
        }
        public async Task<T> ObtenerPerfilUsuarioGet<T>()
        {

            string id = Preferences.Get("idLogin", string.Empty);
            string requestUri = "Usuarios/ObtenerPerfilJugadorPayPremiumDeta/" + id;

            var client = new HttpClient();

            client.BaseAddress = urlBase;

            HttpResponseMessage response = await client.GetAsync(requestUri).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var _json = JsonConvert.DeserializeObject<T>(json);
                return _json;
            }
            else
            {
                return default(T);
            }
        }

        public async Task<T> ObtenerPerfilSeguidorGet<T>()
        {

            string id = Preferences.Get("idSeguidor", string.Empty);
            string requestUri = "usuarios/" + id;

            var client = new HttpClient();

            client.BaseAddress = urlBase;

            HttpResponseMessage response = await client.GetAsync(requestUri).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var _json = JsonConvert.DeserializeObject<T>(json);
                return _json;
            }
            else
            {
                return default(T);
            }
        }

        public async Task<T> ObtenerUltimasPublicaciones<T>()
        {

            string id = Preferences.Get("idSeguidor", string.Empty);
            string requestUri = "Publicacion/ObtenerUltimasPublicaciones/" + id;

            var client = new HttpClient();

            client.BaseAddress = urlBase;

            HttpResponseMessage response = await client.GetAsync(requestUri).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var _json = JsonConvert.DeserializeObject<T>(json);
                return _json;
            }
            else
            {
                return default(T);
            }


        }
    }
}
