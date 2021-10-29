using FGTotal.Model;
using FGTotal.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace FGTotal.ViewModel
{
    public class DetalleMensajeViewModel : ViewModelBase
    {
        public DetalleMensajeViewModel()
        {
            ConsultaDetalleDmPost();
        }
        WebApiClientService webApi = new WebApiClientService();

        private ObservableCollection<DmModel> detalleDm;

        public ObservableCollection<DmModel> DetalleDm
        {
            get { return detalleDm; }
            set { detalleDm = value; OnPropertyChanged(); }
        }

        public async Task ConsultaDetalleDmPost()
        {
             var paramsPost = new { idJugador = int.Parse(Preferences.Get("idJugador", string.Empty)), idSeguidor = int.Parse(Preferences.Get("idSeguidor",string.Empty)) };
            DetalleDm = await webApi.executeRequestPost<ObservableCollection<DmModel>>(paramsPost);
        }
    }
}
