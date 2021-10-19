using System;
using FGTotal.Views.Jugador;
using System.Text;
using FGTotal.Model;
using System.Net.Http;
using Newtonsoft.Json;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FGTotal.Views.Jugador
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Account : ContentPage
    {
        public Account()
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
            await Navigation.PushModalAsync(new Verificacion());
        }

        private async void TapGestureRecognizer_Tapped_4(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Editar());
        }

        private async void TapGestureRecognizer_Tapped_5(object sender, EventArgs e)
        {

        }

        protected override bool OnBackButtonPressed()
        {
            return false;
        }

        private async void btn_Publicar_Clicked(object sender, EventArgs e)
        {
            PostModel log = new PostModel
            {
                titulo = "Publicación 14",
                descripcion = TextoDescripcion.Text,
                idUsuario = 7,
                idTipoPublicacion = "N"

            };
            Uri RequestUri = new Uri("http://projectwebapiloadbalancer-1962764078.us-east-2.elb.amazonaws.com/api/Publicacion/CrearPublicacion");

            var Client = new HttpClient();
            var json = JsonConvert.SerializeObject(log);
            var ContentJson = new StringContent(json, Encoding.UTF8, "application/json");
            var Response = await Client.PostAsync(RequestUri, ContentJson);
            if (Response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                await DisplayAlert("Mensaje", "Publicación exitosa", "OK");
            }
            else
            {
                await DisplayAlert("Mensaje", "Faltan datos", "OK");
            }
        }
    }
}