using System;
using System.ServiceModel;
using System.Windows;
using LIS_Juego_Loterest.Util;
using ServerServices.Interface;

namespace LIS_Juego_Loterest
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        /// <summary>
        ///     Interfaz del servicio de Login que se conecta al servidor.
        /// </summary>
        private readonly ILoginService _loginService;
        
        public MainWindow()
        {
            InitializeComponent();
            _loginService = ClientFactory.CreateDuplexChannel<ILoginService, ILoginServiceCallback>(this);
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
            try
            {
                _loginService.LoginRequest(username, contraseña);
            }
            catch (CommunicationException ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}