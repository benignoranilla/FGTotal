﻿using FGTotal.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FGTotal.Views.Jugador
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Editar : ContentPage
    {
        public Editar()
        {
            InitializeComponent();
        }
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new HomePage());
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new FGPlay());
        }

        private void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Search());
        }

        private void TapGestureRecognizer_Tapped_3(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Verificacion());
        }

        private void btn_privacidad(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Cuenta());
        }

        private async void Guardar_clicked(object sender, EventArgs e)
        {
            string idJ = Preferences.Get("idJugador", string.Empty);

            EditarModel log = new EditarModel
            {
                nombres = TextoNombre.Text,
                descripcionPerfil = TextoDescripcion.Text,
                tipoUsuario = "J",
                id = int.Parse(idJ)
            };


            Uri RequestUri = new Uri(" http:/http://projectwebapi-1533273939.us-east-2.elb.amazonaws.com/api/usuarios/" + idJ);

            var Client = new HttpClient();
            var json = JsonConvert.SerializeObject(log);
            var ContentJson = new StringContent(json, Encoding.UTF8, "application/json");
            var Response = await Client.PutAsync(RequestUri, ContentJson);
            if (Response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                await Navigation.PushAsync(new Editar());

            }

        }
    }
}