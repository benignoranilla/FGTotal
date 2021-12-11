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

namespace FGTotal.Views.Seguidor
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SendMensaje : ContentPage
    {
        public SendMensaje()
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
           Navigation.PushAsync(new Account());
        }

        private async void TapGestureRecognizer_Tapped_4(object sender, EventArgs e)
        {
            DmModel log = new DmModel
            {
                mensaje = TextoMensaje.Text,
                idSeguidor = int.Parse(Preferences.Get("idSeguidor",string.Empty)),
                idJugador = int.Parse (Preferences.Get("idJugador",string.Empty)),
                idTipoDm = 1,
                idMetodoPago = "TAR"
            };
            string id = Preferences.Get("idSeguidor", string.Empty);
            Uri RequestUri = new Uri("http://projectwebapi-481816807.us-east-2.elb.amazonaws.com/api/Dm/EnviarDM/"+id);

            var Client = new HttpClient();
            var json = JsonConvert.SerializeObject(log);
            var ContentJson = new StringContent(json, Encoding.UTF8, "application/json");
            var Response = await Client.PostAsync(RequestUri, ContentJson);
            if (Response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                await Navigation.PushModalAsync(new SendMensaje());
                //await Navigation.PushModalAsync(new NavigationPage(new SendMensaje()));
            }
            else
            {
                await DisplayAlert("Mensaje", "Mensaje no fue enviado", "OK");
            }
        } 
    }
}