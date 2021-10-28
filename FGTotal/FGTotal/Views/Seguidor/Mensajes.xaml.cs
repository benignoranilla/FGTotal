using FGTotal.Model;
using FGTotal.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FGTotal.Views.Seguidor
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Mensajes : ContentPage
    {
        public Mensajes()
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
            await Navigation.PushModalAsync(new Account());
        }

        private async void TapGestureRecognizer_Tapped_4(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Mensajes());
        }

        private async void TapGestureRecognizer_Tapped_5(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Novedades());
        }
        //private async void TapGestureRecognizer_Tapped_6(object sender, EventArgs e)
        //{
        //    await Navigation.PushModalAsync(new Novedades());
        //}

        private async void MensajeSeleccionado (object sender, ItemTappedEventArgs e)
        {
            var id = e.Item as DmModel;
            var idJugador = $"{id.idSeguidor}";
            Preferences.Get("idJugador", string.Empty);

            await Navigation.PushModalAsync(new SendMensaje());

          
        }

        //protected override bool OnBackButtonPressed()
        //{
        //    return false;
        //}


    }
}