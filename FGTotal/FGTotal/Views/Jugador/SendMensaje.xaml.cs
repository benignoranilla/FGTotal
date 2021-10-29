using FGTotal.Model;
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
    public partial class SendMensaje : ContentPage
    {
        public SendMensaje()
        {
            InitializeComponent();
        }
        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new HomePage());
        }

        private async void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new FGPlay());
        }

        private async void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Search());
        }

        private async void TapGestureRecognizer_Tapped_3(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Perfil());
        }

        private async void TapGestureRecognizer_Tapped_4(object sender, EventArgs e)
        {
            DmModel log = new DmModel
            {
                mensaje = Mensaje.Text,
                idSeguidor = int.Parse(Preferences.Get("idSeguidor", string.Empty)),
                idJugador = int.Parse(Preferences.Get("idUsuarioLogin", string.Empty))
            };
            Uri RequestUri = new Uri("http://projectwebapiloadbalancer-1962764078.us-east-2.elb.amazonaws.com/api/Dm/EnviarDM");

            var Client = new HttpClient();
            var json = JsonConvert.SerializeObject(log);
            var ContentJson = new StringContent(json, Encoding.UTF8, "application/json");
            var Response = await Client.PostAsync(RequestUri, ContentJson);
            if (Response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                await DisplayAlert("Mensaje", "Mensaje enviado con éxito", "OK");
            }
            else
            {
                await DisplayAlert("Mensaje", "Mensaje no fue enviado", "OK");
            }
        }
    }
}