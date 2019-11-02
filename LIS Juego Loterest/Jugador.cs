using System;

namespace LIS_Juego_Loterest
{
    public class Jugador
    {
        private int id;
        private String nombreJugador;
        private String correoElectronico;
        private String contrasenia;

        public int Id {
            get { return id; }
            set { id = value; }
        }

        public string NombreJugador
        {
            get { return nombreJugador; }
            set { nombreJugador = value; }
        }

        public string CorreoElectronico
        {
            get { return correoElectronico; }
            set { correoElectronico = value; }
        }
        public string Contrasenia
        {
            get { return contrasenia; }
            set { contrasenia = value; }
        }

        //Constructores
        public Jugador (int id, String nombreJugador, String correoElectronico, String contrasenia)
        {
            this.Id = id;
            this.NombreJugador = nombreJugador;
            this.CorreoElectronico = correoElectronico;
            this.Contrasenia = contrasenia;
        }
    }
}
