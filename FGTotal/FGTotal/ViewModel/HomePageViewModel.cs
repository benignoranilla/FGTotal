using FGTotal.ViewModel;
using System.Collections.ObjectModel;
using FGTotal.Model;
using System.Threading.Tasks;
using FGTotal.Services;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace FGTotal.ViewModel
{
    public class HomePageViewModel : ViewModelBase
    {
        public HomePageViewModel()
        {
            TimeLineGet();
        }

        WebApiClientService webApi = new WebApiClientService();

        private ObservableCollection<ProfilePlayerModel> timeLine;

        public ObservableCollection<ProfilePlayerModel> TimeLine
        {
            get { return timeLine; }
            set { timeLine = value; OnPropertyChanged(); }
        }


        public async Task TimeLineGet()
        {

            TimeLine = await webApi.ObtenerUltimasPublicaciones<ObservableCollection<ProfilePlayerModel>>();

            var _list = TimeLine;

        }

    }
}
