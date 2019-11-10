using System;
using System.ServiceModel;
using System.Windows;
using LIS_Juego_Loterest.Util;
using ServerServices;
using ServerServices.Interface;
using ServerServices.Model;

namespace LIS_Juego_Loterest
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ILoginServiceCallback
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
                _loginService.RequestLogin(username, contraseña);
            }
            catch (CommunicationException ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void OnLoginSuccess(string guid)
        {
            Console.WriteLine(guid);
            
            Menú menú = new Menú();
            menú.Show();

            this.Close();
        }

        public void OnLoginError(string message)
        {
            Console.WriteLine(message);
        }
    }
}