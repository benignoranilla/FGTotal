using System;
using FGTotal.Model;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FGTotal.Views.Seguidor
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

                    System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();

                    mmsg.To.Add(RegistroCorreo.Text);
                    mmsg.Subject = "Bienvenido a FGTotal!";
                    mmsg.SubjectEncoding = System.Text.Encoding.UTF8;

                    mmsg.Body = "Hola! " + RegistroDni.Text + " el registro de tu cuenta ha sido satisfactoria.";
                    mmsg.BodyEncoding = System.Text.Encoding.UTF8;
                    mmsg.IsBodyHtml = true;
                    mmsg.From = new System.Net.Mail.MailAddress("joseb_ranilla@outlook.com");

                    System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();

                    cliente.Credentials = new System.Net.NetworkCredential("joseb_ranilla@outlook.com", "BenignoFlores1618@");

                    cliente.Port = 587;
                    cliente.EnableSsl = true;

                    cliente.Host = "smtp.office365.com";

                    try
                    {
                        cliente.Send(mmsg);
                    }
                    catch (Exception)
                    {
                        await DisplayAlert("Mensaje", "Error al enviar el correo", "OK");
                    }
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
    }
}