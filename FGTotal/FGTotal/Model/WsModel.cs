using System;
using System.Collections.Generic;
using System.Text;

namespace FGTotal.Model
{
    public class WsModel
    {

        //Login
       
        private int id;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        //public string id { get; set; }
        public string usuario { get; set; }

        public string contrasena { get; set; }

        public string correo { get; set; }

        public string tipousuario { get; set; }

        // Publicación
        public string descripcion { get; set; }

        public string titulo { get; set; }

        public int idUsuario { get; set; }

        public string idTipoPublicacion { get; set; }

        // DM Premium
        public string Mensaje { get; set; }

        public string idSeguidor { get; set; }

        public int idJugador { get; set; }

        public int idTipoDm { get; set; }

        public string idMetodoPago { get; set; }

        // Bandeja de Entrada

        public int cantidadMensajes { get; set; }

        public int MyProperty { get; set; }
    }
}

