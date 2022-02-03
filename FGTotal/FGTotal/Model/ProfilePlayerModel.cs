using System;
using System.Collections.Generic;
using System.Text;

namespace FGTotal.Model
{
    public class ProfilePlayerModel
    {
        public int idPublicacion { get; set; }
        public string titulo { get; set; }
        public string descripcion { get; set; }
        public string rImagen { get; set; }
        public string nombresUsuario { get; set; }
        public DateTime fechaCreacion { get; set; }
    }
}
