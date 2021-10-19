
using FGTotal.ViewModel;
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

namespace FGTotal.Views.Seguidor
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Prueba : ContentPage
    {
        public Prueba()
        {
            InitializeComponent();

            // BindingContext = dvm = new DmViewModel();
        }

        private DmViewModel dvm;

        //private async Task<T> executeRequestPost<T>(objectParams)
        //{
        //    WsModel log = new WsModel
        //    {
        //        idSeguidor = 4,
        //        idJugador = 6
        //    };
        //    Uri RequestUri = new Uri("http://projectwebapiloadbalancer-1962764078.us-east-2.elb.amazonaws.com/api/DM/ObtenerDetalleMensaje/J");
        //
        //    var Client = new HttpClient();
        //    var json = JsonConvert.SerializeObject(log);
        //    var ContentJson = new StringContent(json, Encoding.UTF8, "application/json");
        //    var Response = await Client.PostAsync(RequestUri, ContentJson);
        //    if (Response.StatusCode == System.Net.HttpStatusCode.OK)
        //    {
        //        return dvm;
        //    }
        //}
    }
}