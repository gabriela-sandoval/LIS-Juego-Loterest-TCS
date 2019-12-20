using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Model
{
    public class UsuarioJugador
    {
        public string NombreJugador { get; set; }
        public string CorreoElectronicoJugador { get; set; }
        public string ContraseñaJugador { get; set; }
        public int PuntajeJugador { get; set; }
        public Tabla Tabla { get; set; }
    }
}
