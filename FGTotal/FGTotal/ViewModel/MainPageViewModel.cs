using FGTotal.ViewModel;
using System.Collections.ObjectModel;
using FGTotal.Model;
using System.Threading.Tasks;
using FGTotal.Services;
using System.Net.Http;
using Newtonsoft.Json;

namespace FGTotal.ViewModel
{
    public class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel()
        {
            Initialize();
        }
        public ObservableCollection<WsModel> Mensajes
        {
            get { return mensajes; }
            set { SetProperty(ref mensajes, value); }
        }

        private ObservableCollection<WsModel> mensajes;

        private async Task Initialize()
        {
            IsBusy = true;
            HttpResponseMessage response = await HttpClientService.Instance.GetAsync("Dm/ObtenerBandejaMensaje/7");
            if (response.IsSuccessStatusCode)
            {
                string rawMessage = await response.Content.ReadAsStringAsync();
                Mensajes = JsonConvert.DeserializeObject<ObservableCollection<WsModel>>(rawMessage);
            }

            IsBusy = false;
        }
    }
}
