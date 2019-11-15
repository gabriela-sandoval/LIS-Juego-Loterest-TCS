using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LIS_Juego_Loterest
{
    /// <summary>
    /// Lógica de interacción para Menú.xaml
    /// </summary>
    public partial class Menú : Page
    {
        public Menú()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Tablero tablero = new Tablero();
            //tablero.Show();

            //this.Close();
        }

        private void ButtonAlAzar_Click(object sender, RoutedEventArgs e)
        {
            //Carta carta = new Carta();
            //carta.Show();

            //this.Close();
        }

        private void ButtonIdioma_Click(object sender, RoutedEventArgs e)
        {
            //Idioma idioma = new Idioma();
            //idioma.ShowDialog();
        }

        private void ButtonComoJugar_Click(object sender, RoutedEventArgs e)
        {
            //ComoJugar comoJugar = new ComoJugar();
            //comoJugar.ShowDialog();
        }

        private void ButtonAcercaDe_Click(object sender, RoutedEventArgs e)
        {
            //AcercaDe acercaDe = new AcercaDe();
            //acercaDe.ShowDialog();
        }

        private void ButtonSalir_Click(object sender, RoutedEventArgs e)
        {
            //Salir salir = new Salir();
            //salir.ShowDialog();
        }

        private void ButtonPuntaje_Click(object sender, RoutedEventArgs e)
        {
            //Puntaje puntaje = new Puntaje();
            //puntaje.Show();

            //this.Close();
        }
    }
}
