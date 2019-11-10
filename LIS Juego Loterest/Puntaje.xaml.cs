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
    /// Lógica de interacción para Puntaje.xaml
    /// </summary>
    public partial class Puntaje : Window
    {
        public Puntaje()
        {
            InitializeComponent();
        }

        private void TextBoxUserName_Copy1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ButtonRegresar_Click(object sender, RoutedEventArgs e)
        {
            Menú menú = new Menú();
            menú.Show();
            this.Close();
        }
    }
}
