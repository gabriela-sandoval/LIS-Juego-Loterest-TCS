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
            try
            {
                App.JugadorEnLinea =
                    App.ConexionBaseDeDatos1.LoguearUsuario
                    (textBoxCorreoElectronicoIniciarSesion.Text, passwordBoxContraseniaIniciarSesion.Password);

                if(App.JugadorEnLinea != null)
                {
                    Menú menú = new Menú();
                    menú.Show();

                    this.Close();
                }
                else
                {
                    MessageBox.Show("El correo electrónico o contraseña son incorrectos", 
                        "No se puede iniciar sesión", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió una excepción: "  + ex.Message);
            }
        }

    }
}
