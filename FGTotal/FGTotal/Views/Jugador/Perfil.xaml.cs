

using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        //vate async void Camara_Clicked(object sender, EventArgs e)
        //
        //
        // MediaFile file = null;
        // await CrossMedia.Current.Initialize();
        //
        // if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
        // {
        //     await DisplayAlert("No camara", "Camara no Habilitada", "Ok");
        //     return;
        // }
        //
        // file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
        // {
        //     SaveToAlbum = true,
        //     Name = "COP.jpg"
        // });
        //
        // if (file == null)
        //     return;
        //
        //
        //
        // //Agregando Imagen
        //if (Foto1.Source == null)
        //{
        //    Foto1.Source = ImageSource.FromStream(() =>
        //    {
        //        var stream = file.GetStream();
        //        file.Dispose();
        //        return stream;
        //    });
        //}
            //else if (image2.Source == null)
            //{
            //    image2.Source = ImageSource.FromStream(() =>
            //    {
            //        var stream = file.GetStream();
            //        file.Dispose();
            //        return stream;
            //    });
            //}
            //else if (image3.Source == null)
            //{
            //    image3.Source = ImageSource.FromStream(() =>
            //    {
            //        var stream = file.GetStream();
            //        file.Dispose();
            //        return stream;
            //    });
            //}
            //else if (image4.Source == null)
            //{
            //    image4.Source = ImageSource.FromStream(() =>
            //    {
            //        var stream = file.GetStream();
            //        file.Dispose();
            //        return stream;
            //    });
            //}
            //else if (image5.Source == null)
            //{
            //    image5.Source = ImageSource.FromStream(() =>
            //    {
            //        var stream = file.GetStream();
            //        file.Dispose();
            //        return stream;
            //    });
            //}
            //else if (image6.Source == null)
            //{
            //    image6.Source = ImageSource.FromStream(() =>
            //    {
            //        var stream = file.GetStream();
            //        file.Dispose();
            //        return stream;
            //    });
            //}

            //Imagen

        //}

        private async void Camara_Clicked (object sender, EventArgs e)
        {
            var foto = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions());

            if(foto != null)
            {
                Foto.Source = ImageSource.FromStream(() =>
                {
                    return foto.GetStream();
                });
            }
        }
    }
}