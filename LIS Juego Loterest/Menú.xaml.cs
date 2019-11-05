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
    public partial class Menú : Window
    {
        public Menú()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Tablero tablero = new Tablero();
            tablero.Show();

            this.Close();
        }

        private void ButtonAlAzar_Click(object sender, RoutedEventArgs e)
        {
            Carta carta = new Carta();
            carta.Show();

            this.Close();
        }
    }
}
