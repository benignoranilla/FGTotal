﻿using FGTotal.Model;
using FGTotal.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace FGTotal.ViewModel
{
    public class EditarViewModel : ViewModelBase
    {
        public EditarViewModel()
        {
            ObtenerPerfilSeguidor();
        }

        WebApiClientService webapi = new WebApiClientService();

        private ObservableCollection<EditarModel> perfil;

        public ObservableCollection<EditarModel> Perfil
        {
            get { return perfil; }
            set { perfil = value; OnPropertyChanged(); }
        }

        public async Task ObtenerPerfilSeguidor()
        {
            Perfil = await webapi.ObtenerPerfilSeguidorGet<ObservableCollection<EditarModel>>();

            var _list = Perfil;
        }
    }
}
