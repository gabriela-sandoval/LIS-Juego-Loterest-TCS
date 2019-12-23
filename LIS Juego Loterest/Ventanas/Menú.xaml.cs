using System;
using System.Windows;

/// <summary>
/// Ventana Menú.
/// Muestra todas las opciones posibles que existen dentro del juego.
/// </summary>
namespace LIS_Juego_Loterest.Ventanas
{
    public partial class Menú : Window
    {
        
        public Menú()
        {
            InitializeComponent();
        }

        private void CambioDeVentana(Window ventanaAbrir, Window ventanaCerrar)
        {
            ventanaAbrir.Show();
            ventanaCerrar.Close();
        }

        private void ButtonAlAzar_Click(object sender, RoutedEventArgs e)
        {
            Carta carta = new Carta();
            CambioDeVentana(carta, this);
        }

        private void ButtonIdioma_Click(object sender, RoutedEventArgs e)
        {
            Idioma idioma = new Idioma();
            CambioDeVentana(idioma, this);
        }

        private void ButtonComoJugar_Click(object sender, RoutedEventArgs e)
        {
            ComoJugar comoJugar = new ComoJugar();
            CambioDeVentana(comoJugar, this);
        }

        private void ButtonAcercaDe_Click(object sender, RoutedEventArgs e)
        {
            AcercaDe acercaDe = new AcercaDe();
            CambioDeVentana(acercaDe, this);
        }

        private void ButtonSalir_Click(object sender, RoutedEventArgs e)
        {
            Salir salir = new Salir();
            CambioDeVentana(salir, this);
        }

        private void ButtonPuntaje_Click(object sender, RoutedEventArgs e)
        {
            Puntaje puntaje = new Puntaje();
            CambioDeVentana(puntaje, this);
        }

        private void ChatButton_Click(object sender, RoutedEventArgs e)
        {
            SalaChat salaChat = new SalaChat();
            CambioDeVentana(salaChat, this);
        }

        private void ButtonLoteria_Click(object sender, RoutedEventArgs e)
        {
            Tablero tablero = new Tablero();
            CambioDeVentana(tablero, this);
        }
    }
}
