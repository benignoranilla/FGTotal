using FGTotal.Model;
using FGTotal.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace FGTotal.ViewModel
{
    public class ProfilePlayerViewModel : ViewModelBase
    {
        public ProfilePlayerViewModel()
        {
            ConsultaPerfilGet();
        }
        WebApiClientService webApi = new WebApiClientService();

        private ObservableCollection<ProfilePlayerModel> perfilUsuario;

        public ObservableCollection<ProfilePlayerModel> PerfilUsuario
        {
            get { return perfilUsuario; }
            set { perfilUsuario = value; OnPropertyChanged(); }
        }

        public async Task ConsultaPerfilGet()
        {

            PerfilUsuario = await webApi.ObtenerPerfilUsuarioGet<ObservableCollection<ProfilePlayerModel>>();

            var _list = PerfilUsuario;

        }
    }
}
