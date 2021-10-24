using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FGTotal
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Views.Seguidor.SendMensaje());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
