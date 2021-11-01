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
    public class ProfileViewModel : ViewModelBase
    {
        public ProfileViewModel()
        {
            ConsultaPerfilGet();
        }
        WebApiClientService webApi = new WebApiClientService();

        private ObservableCollection<ProfileModel> perfilUsuario;

        public ObservableCollection<ProfileModel> PerfilUsuario
        {
            get { return perfilUsuario; }
            set { perfilUsuario = value; OnPropertyChanged(); }
        }

        public async Task ConsultaPerfilGet()
        {

            PerfilUsuario = await webApi.ObtenerPerfilUsuarioGet<ObservableCollection<ProfileModel>>();

            var _list = PerfilUsuario;

        }
    }
}
