using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace LIS_Juego_Loterest
{
    /// <summary>
    /// Lógica de interacción para App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static ConexionBaseDeDatos ConexionBaseDeDatos =
            new ConexionBaseDeDatos();

        public static ConexionBaseDeDatos ConexionBaseDeDatos1
        {
            get { return App.ConexionBaseDeDatos; }
        }

        private static Jugador jugadorEnLinea;

        public static Jugador JugadorEnLinea
        {
            get { return App.jugadorEnLinea; }
            set { App.jugadorEnLinea = value; }
        }
    }
}
