using System;
using FGTotal.Model;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FGTotal.Views.Jugador
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registro : ContentPage
    {
        public Registro()
        {
            InitializeComponent();
            
        }
        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Login());
        }

        private async void TapGestureRecognizer_TappedRegistro(object sender, EventArgs e)
        {
            if (RegistroPassword.Text == RegistroPassword1.Text)
            {
                LoginModel log = new LoginModel
                {
                    usuario = RegistroDni.Text,
                    contrasena = RegistroPassword1.Text,
                    correo = RegistroCorreo.Text,
                    tipousuario = "S"

                };
                Uri RequestUri = new Uri("http://projectwebapiloadbalancer-1962764078.us-east-2.elb.amazonaws.com/api/Usuarios/RegistrarUsuario");

                var Client = new HttpClient();
                var json = JsonConvert.SerializeObject(log);
                var ContentJson = new StringContent(json, Encoding.UTF8, "application/json");
                var Response = await Client.PostAsync(RequestUri, ContentJson);
                if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    await Navigation.PushAsync(new HomePage());
                }
                else
                {
                    await DisplayAlert("Mensaje", "Usuario ya existe", "OK");
                }
            }
            else
            {
                await DisplayAlert("Mensaje", "Contraseñas no coinciden", "OK");
            }
        }




        protected override bool OnBackButtonPressed()
        {
            return false;
        }
    }
}