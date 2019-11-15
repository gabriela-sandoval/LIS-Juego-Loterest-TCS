using System.ComponentModel.DataAnnotations;

namespace DataModel.Model
{
    public class Jugador
    {
        [Key]
        public int IdJugador { get; set; }
        public string Nombre { get; set; }
        public string Contraseña { get; set; }
        public string CorreoElectrónico { get; set; }
    }
}