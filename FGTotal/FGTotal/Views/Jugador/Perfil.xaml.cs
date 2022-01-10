

using Amazon;
using Amazon.CognitoIdentity;
using Amazon.S3;
using Amazon.S3.Transfer;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FGTotal.Views.Jugador
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Perfil : ContentPage
    {
        public Perfil()
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

        private void TapGestureRecognizer_Tapped_4(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Mensajes());
        }

        private void TapGestureRecognizer_Tapped_5(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Mensajes());
        }

        private void btn_editar (object sender, EventArgs e)
        {
            Navigation.PushAsync(new Editar());
        }

        
        private async void Camara_Clicked (object sender, EventArgs e)
        {
            var foto = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                { Name = "Temp_Photo.jpg", });

            Preferences.Set("Photo", foto.text);

            if(foto != null)
            {
                Foto.Source = ImageSource.FromStream(() =>
                {
                    return foto.GetStream();
                });
            }
        }

        private async void Agregar_Clicked (object sender, EventArgs e)
        {
            #region
            CognitoAWSCredentials credentials = new CognitoAWSCredentials(
            "us-east-1:263cc401-708c-4bad-8594-9c414f1d2e7d",   //"us-east-1:00000000-0000-0000-0000-000000000000", // Your identity pool ID
            RegionEndpoint.USEast2 // Region
            );

            var loggingConfig = AWSConfigs.LoggingConfig;
            loggingConfig.LogMetrics = true;
            loggingConfig.LogResponses = ResponseLoggingOption.Always;
            loggingConfig.LogMetricsFormat = LogMetricsFormatOption.JSON;
            loggingConfig.LogTo = LoggingOptions.SystemDiagnostics;

            AWSConfigs.AWSRegion = "us-east-2";
            IAmazonS3 s3Client = new AmazonS3Client(credentials, RegionEndpoint.USEast2);

            AWSConfigsS3.UseSignatureVersion4 = true;

            //var s3Client = new AmazonS3Client(credentials, region);
            var transferUtility = new TransferUtility(s3Client);

            string path = "/storage/emulated/0/Android/data/com.phoenix.fgtotal/files/Pictures/";
                //Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            // Para SUBIR un archivo nuevo
            transferUtility.Upload(
              Path.Combine(path, "Temp_Photo_5.jpg"),
              "bucketfgtotal"
            );


            // Para DESCARGAR un archivo nuevo
            transferUtility.Download(
              Path.Combine(path, "imagen_prueba_001"),
              "bucketfgtotal",
              "FGTotal_file/Screenshot_1.jpg"
            );
            #endregion

            // 
            Navigation.PushAsync(new Perfil());
        }
    }
}