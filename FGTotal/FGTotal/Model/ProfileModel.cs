using System;
using System.Collections.Generic;
using System.Text;

namespace FGTotal.Model
{
    public class ProfileModel
    {
        public int id { get; set; }
        public string usuario { get; set; }
        public string rFotoPerfil { get; set; }
        public string rFotoPortada { get; set; }
        public string usuarioAlternativo { get; set; }
        public string descripcionPerfil { get; set; }
        public int cantidadSeguidos { get; set; }

    }
}
