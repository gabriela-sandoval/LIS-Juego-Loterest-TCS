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
    /// Lógica de interacción para Tablero.xaml
    /// </summary>
    public partial class Tablero : Window
    {
        public Tablero()
        {
            InitializeComponent();
        }

        private void ButtonSeleccionarTablero_Click(object sender, RoutedEventArgs e)
        {
            Loteria loteria = new Loteria();
            loteria.Show();
        }

        private void ButtonRegresar_Click(object sender, RoutedEventArgs e)
        {
            Menú menu = new Menú();
            menu.Show();
        }
    }
}
