using System;
using System.Collections.Generic;
using System.Text;

namespace FGTotal.Model
{
    public class DmModel
    {
        public int idDM { get; set; }
        public int idSeguidor { get; set; }
        public string descripcionSeguidor { get; set; }
        public int idJugador { get; set; }
        public string descripcionJugador { get; set; }
        public int idTipoDm { get; set; }
        public string descripcionTipoDm { get; set; }
        public string ultimoMensaje { get; set; }
        public string idEstadosDmSe { get; set; }
        public string descripcionEstadoDmSe { get; set; }
        public string idEstadoDmJu { get; set; }
        public string usuario { get; set; }
        public string mensaje { get; set; }
        public string nombreEmisor { get; set; }

    }
}
