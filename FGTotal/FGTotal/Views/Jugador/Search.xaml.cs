using FGTotal.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FGTotal.Views.Jugador
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Search : ContentPage
    {
        public Search()
        {
            InitializeComponent();

            ResultadosBusqueda = new ObservableCollection<string>(sourceItems);

            BindingContext = this;
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
            await Navigation.PushModalAsync(new Perfil());
        }
        //private async void TapGestureRecognizer_Tapped_4(object sender, EventArgs e)
        //{
        //    SearchModel log = new SearchModel
        //    {
        //        busqueda = busqueda.Text
        //    };
        //
        //    Uri RequestUri = new Uri("http://projectwebapi-1533273939.us-east-2.elb.amazonaws.com/api/Usuarios/ObtenerJugadoresBuscar");
        //
        //    var Client = new HttpClient();
        //    var json = JsonConvert.SerializeObject(log);
        //    var ContentJson = new StringContent(json, Encoding.UTF8, "application/json");
        //    var Response = await Client.PostAsync(RequestUri, ContentJson);
        //    if (Response.StatusCode == System.Net.HttpStatusCode.OK)
        //    {
        //
        //    }
        //
        //    }

        protected override bool OnBackButtonPressed()
        {
            return false;
        }

        private readonly string[] sourceItems = new[] { "Jugador01", "Jugador02", "Jugador03", "Jugador04", "Jugador05", "Jugador06" };

        public ObservableCollection<string> ResultadosBusqueda { get; set; }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            var searchText = e.NewTextValue;

            if (string.IsNullOrWhiteSpace(searchText))
            {
                searchText = string.Empty;
            }

            searchText = searchText.ToLowerInvariant();

            var filteredItems = sourceItems.Where(value => value.ToLowerInvariant().Contains(searchText)).ToList();

            if (string.IsNullOrWhiteSpace(searchText))
            {
                filteredItems = sourceItems.ToList();
            }

            foreach (var value in sourceItems)
            {
                if (!filteredItems.Contains(value))
                {
                    ResultadosBusqueda.Remove(value);
                }
                else if (!ResultadosBusqueda.Contains(value))
                {
                    ResultadosBusqueda.Add(value);
                }
            }
        }
    }
}