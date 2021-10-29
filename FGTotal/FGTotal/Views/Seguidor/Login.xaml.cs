using System;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;
using FGTotal.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace FGTotal.Views.Seguidor
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }
        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            LoginModel log = new LoginModel
            {
                usuario = DNI.Text,
                contrasena = Password.Text
            };
            Uri RequestUri = new Uri("http://projectwebapiloadbalancer-1962764078.us-east-2.elb.amazonaws.com/api/usuarios");

            var Client = new HttpClient();
            var json = JsonConvert.SerializeObject(log);
            var ContentJson = new StringContent(json, Encoding.UTF8, "application/json");
            var Response = await Client.PostAsync(RequestUri, ContentJson);
            if (Response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                await Navigation.PushAsync(new HomePage());

                var jsonlogin = await Response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<WsModel>(jsonlogin);

                var idLoginUsuario = $"{resultado.ID}";
                Preferences.Set("idSeguidor", idLoginUsuario);

                var usuario = $"{resultado.usuario}";
                Preferences.Set("usuario", usuario);

                var tipoUsuario = $"{resultado.tipousuario}";
                Preferences.Set("tipoUsuario", tipoUsuario);

            }
            else
            {
                await DisplayAlert("Mensaje", "Datos inválidos", "OK");
            }
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
            await Navigation.PushModalAsync(new Account());
        }

        private async void TapGestureRecognizer_Tapped_6(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Registro());
        }


        protected override bool OnBackButtonPressed()
        {
            return false;
        }
    }
}