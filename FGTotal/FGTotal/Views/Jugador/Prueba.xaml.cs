

using Amazon;
using Amazon.CognitoIdentity;
using Amazon.S3;
using Amazon.S3.Transfer;
using FGTotal.Model;
using Newtonsoft.Json;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static FGTotal.MainPage;

namespace FGTotal.Views.Jugador
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Prueba : ContentPage
    {
        public Prueba()
        {
            InitializeComponent();
        }

        private void TapGestureRecognizer_Tapped1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new HomePage());
        }

        private void TapGestureRecognizer_Tapped_11(object sender, EventArgs e)
        {
            Navigation.PushAsync(new FGPlay());
        }

        private void TapGestureRecognizer_Tapped_21(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Search());
        }

        private void TapGestureRecognizer_Tapped_31(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Verificacion());
        }

        private void TapGestureRecognizer_Tapped_41(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Mensajes());
        }

        private void TapGestureRecognizer_Tapped_51(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Prueba());
        }

        private void btn_editar1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Editar());
        }


        private async void Camara_Clicked1 (object sender, EventArgs e)
        {
            //var photo = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            var photo_name = Preferences.Get("usuario", string.Empty) + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".jpg";
            Preferences.Set("photo_name", photo_name);

            var foto = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
            { Name = photo_name, });

            if (foto != null)
            {
                var url = foto.Path.ToString();
                Preferences.Set("photo_url", url);

                Foto1.Source = ImageSource.FromStream(() =>
                {
                    return foto.GetStream();
                });
            }
        }
        private async void Gallery_Clicked1 (object sender, EventArgs e)
        {
            var picture_name = Preferences.Get("usuario", string.Empty) + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".jpg";
            Preferences.Set("photo_name", picture_name);

            var foto = await CrossMedia.Current.PickPhotoAsync();

            DependencyService.Get<IFile>().Copy(foto.Path, "/storage/emulated/0/Android/data/com.phoenix.fgtotal/files/Pictures/temp/" + Preferences.Get("photo_name", string.Empty));

            var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(foto.Path);

            if (foto != null)
            {
                Foto1.Source = ImageSource.FromStream(() =>
                {
                    var stream = foto.GetStream();

                    foto.Dispose();

                    return stream;
                });
            }
        }

        private async void Video_Clicked1 (Object sender, EventArgs e)
        {
            var foto = await CrossMedia.Current.PickVideoAsync();

            Foto1.Source = ImageSource.FromStream(() =>
            {
                var stream = foto.GetStream();

                foto.Dispose();

                return stream;
            });
        }

        private async void Agregar_Clicked1 (object sender, EventArgs e)
        {

            string ruta = "https://bucketfgtotal.s3.us-east-2.amazonaws.com/FGTotal_file/" + Preferences.Get("photo_name", string.Empty);

            PostModel log = new PostModel
            {
                titulo = "Prueba",
                idUsuario = Convert.ToInt32(Preferences.Get("idLogin", string.Empty)),
                descripcion = NewComent1.Text,
                idTipoPublicacion = "N"
            };

            Uri urlBase = new Uri("http://projectwebapi-1533273939.us-east-2.elb.amazonaws.com/api/Publicacion/CrearPublicacion/");

            string idJugador = Preferences.Get("idLogin", string.Empty);
            string RequestUri = urlBase + idJugador;

            var Client = new HttpClient();
            var json = JsonConvert.SerializeObject(log);
            var ContentJson = new StringContent(json, Encoding.UTF8, "application/json");
            var Response = await Client.PostAsync(urlBase, ContentJson);
            if (Response.StatusCode == System.Net.HttpStatusCode.OK && Foto1 != null)
            {
                #region
                AWSConfigs.AWSRegion = "us-east-2";
                AWSConfigsS3.UseSignatureVersion4 = true;
                AWSConfigs.CorrectForClockSkew = true;

                CognitoAWSCredentials credentials = new CognitoAWSCredentials(AWSEnvironment.IdentityPoolId, RegionEndpoint.USEast2);

                IAmazonS3 s3Client = new AmazonS3Client(credentials, RegionEndpoint.USEast2);

                var transferUtility = new TransferUtility(s3Client);

                await transferUtility.UploadAsync(Preferences.Get("photo_url", string.Empty), "bucketfgtotal/FGTotal_file"
               );

                Foto1 = null;
                #endregion

                var jsonpost = await Response.Content.ReadAsStringAsync();

                var resultado = JsonConvert.DeserializeObject<PostModel>(jsonpost);

                var idPublicacion = $"{resultado.idPublicacion}";

                // Publicación de la ruta multimedia

                PostMultimediaModel log2 = new PostMultimediaModel
                {
                    idPublicacion = Convert.ToInt32(idPublicacion),
                    rutaArchivo = ruta,
                    idItem = 1,
                    idTipoMultimedia = "I",

                };

                Uri urlBase2 = new Uri("http://projectwebapi-1533273939.us-east-2.elb.amazonaws.com/api/Publicacion/GuardarRutaMultimedia/");

                var Client2 = new HttpClient();
                var json2 = JsonConvert.SerializeObject(log2);
                var ContentJson2 = new StringContent(json2, Encoding.UTF8, "application/json");
                var Response2 = await Client2.PostAsync(urlBase2, ContentJson2);


                // await Navigation.PushAsync(new Perfil());
            }
            if (Response.StatusCode == System.Net.HttpStatusCode.OK && Foto1 == null)
            {
                await DisplayAlert("Mensaje", "Publicación realizada", "OK");
            }
            else
            {
                await DisplayAlert("Mensaje", "No se ha podido realizar la publicación", "OK");
            }

            //await Navigation.PushAsync(new Perfil());
        }
    }
}