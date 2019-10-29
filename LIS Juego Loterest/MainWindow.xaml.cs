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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LIS_Juego_Loterest
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonSiguienteIniciarSesion_Click(object sender, RoutedEventArgs e)
        {
            Verificación form = new Verificación();
            form.ShowDialog();
            //Aceptado = false;
            //if(PasswordBoxContraseniaCrearCuenta.Password.Equals("Gabriela"))
            //{
               // Aceptado = true;
           // }
            //Para cerrar la ventana
            //DialogResult = true;
        }

        private void ButtonIngresarIniciarSesion_Click(object sender, RoutedEventArgs e)
        {
            Menú menu = new Menú();
            menu.ShowDialog();
        }

        public bool Aceptado { get; set; }
    }
}
