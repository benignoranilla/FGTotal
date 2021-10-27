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
            IsBusy = true;
            HttpResponseMessage response = await HttpClientService.Instance.GetAsync("/DM/ObtenerDetalleMensaje/S");
            if (response.IsSuccessStatusCode)
            {
                string rawMessage = await response.Content.ReadAsStringAsync();
                DetalleDm = JsonConvert.DeserializeObject<ObservableCollection<DmModel>>(rawMessage);
            }

            IsBusy = false;

            var paramsPost = new { idSeguidor = int.Parse(Preferences.Get("id", string.Empty)), idJugador = 11 };
            DetalleDm = await webApi.executeRequestPost<ObservableCollection<DmModel>>(paramsPost);
        }
    }
}
