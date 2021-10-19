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

namespace FGTotal.ViewModel
{
    public class DmViewModel : ViewModelBase

    {
        public DmViewModel()
        {
            ConsultaListaDmPost();
        }
        WebApiClientService webApi = new WebApiClientService();

        private ObservableCollection<DmModel> listaDm;

        public ObservableCollection<DmModel> ListaDm
        {
            get { return listaDm; }
            set { listaDm = value; OnPropertyChanged(); }
        }

        //private string idSeguidor,idJugador;
        //
        //public string ID
        //{
        //    get { return idSeguidor; idJugador; }
        //    set { idSeguidor = value; idJugador = value; OnPropertyChanged(); }
        //}

        //public ICommand ConsultaListaDmPostCommand { get; set; }
        //
        //public DmViewModel()
        //{
        //    ConsultaListaDmPostCommand = new Command(async () => await ConsultaListaDmPost());
        //}

        public async Task ConsultaListaDmPost()
        {
            var paramsPost = new { idSeguidor = 4, idJugador = 6 };
            ListaDm = await webApi.executeRequestPost<ObservableCollection<DmModel>>(paramsPost);
        }

    }
}
