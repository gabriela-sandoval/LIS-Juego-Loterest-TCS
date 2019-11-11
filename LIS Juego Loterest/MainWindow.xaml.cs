using System.Windows;

namespace LIS_Juego_Loterest
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonSiguienteIniciarSesion_Click(object sender, RoutedEventArgs e)
        {
            Verificación verificación = new Verificación();
            verificación.Show();

            this.Close();
        }

        private void ButtonIngresarIniciarSesion_Click(object sender, RoutedEventArgs e)
        {
            var username = "usuario";
            var contraseña = "contraseña";
        }
    }
}