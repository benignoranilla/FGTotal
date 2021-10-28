using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using FGTotal.Services;
using FGTotal.Model;
using Xamarin.Essentials;

namespace FGTotal.ViewModel
{
    public class DmViewModel : ViewModelBase

    {
        public DmViewModel()
        {
            //ConsultaListaDmPost();
            ObtenerBandejaMensajes();
        }
        WebApiClientService webApi = new WebApiClientService();

        private ObservableCollection<DmModel> listaDm;

        public ObservableCollection<DmModel> ListaDm
        {
            get { return listaDm; }
            set { listaDm = value; OnPropertyChanged(); }
        }
       //public async Task ConsultaListaDmPost()
       //{
       //
       //    var paramsPost = new { idSeguidor = int.Parse(Preferences.Get("id", string.Empty)), idJugador = 11 };
       //    ListaDm = await webApi.executeRequestPost<ObservableCollection<DmModel>>(paramsPost);
       //}

        public async Task ObtenerBandejaMensajes()
        {
            
                ListaDm = await webApi.ObtenerBandejaMensajeJugadorGet<ObservableCollection<DmModel>>();

                var _list = ListaDm;
            
        }

    }
}
