using FGTotal.Model;
using FGTotal.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace FGTotal.ViewModel
{
    public class SearchViewModel : ViewModelBase
    {
        public SearchViewModel()
        {
            ConsultaBuscarJugador();
        }
        WebApiClientService webApi = new WebApiClientService();

        private ObservableCollection<SearchModel> perfilUsuario;

        public ObservableCollection<SearchModel> PerfilUsuario
        {
            get { return perfilUsuario; }
            set { perfilUsuario = value; OnPropertyChanged(); }
        }

        public async Task ConsultaBuscarJugador()
        {

            PerfilUsuario = await webApi.ObtenerPerfilUsuarioGet<ObservableCollection<SearchModel>>();

            var _list = PerfilUsuario;

        }
    }
}
