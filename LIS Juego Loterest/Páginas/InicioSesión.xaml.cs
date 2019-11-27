using System;
using System.ServiceModel;
using System.Windows;
using LIS_Juego_Loterest.Controles;
using LIS_Juego_Loterest.Interface;
using LIS_Juego_Loterest.Util;
using ServerServices.Interface;
using ServerServices.Model.Enum;

namespace LIS_Juego_Loterest.Páginas
{
    /// <summary>
    /// Lógica de interacción para InicioSesión.xaml
    /// </summary>
    public partial class InicioSesión : ILoginServiceCallback, IPageListener
    {
        /// <summary>
        ///     Interfaz del servicio de Login que se conecta al servidor.
        /// </summary>
        private readonly ILoginService _loginService;

        private IPageManager _pageManager;
        
        public InicioSesión()
        {
            InitializeComponent();
            _loginService = ClientFactory.CreateDuplexChannel<ILoginService, ILoginServiceCallback>(this);
        }

        private void OnLoginButtonClick(object sender, Login.LoginArgs loginArgs)
        {
            var username = loginArgs.Username;
            var contraseña = loginArgs.Password;
            try
            {
                _loginService.LoginRequest(username, contraseña);
            }
            catch (CommunicationException ex)
            {
                OnLoginError(LoginRequestReplyCode.GeneralError, ex.Message);
            }
        }

        public void OnLoginSuccess(string sessionId)
        {
            var menú = _pageManager.CambiarPantalla<Menú>();
            Console.WriteLine(sessionId);
        }

        public void OnLoginError(LoginRequestReplyCode replyCode, string message)
        {
            // Rehabilitar campos de texto y botón
            LoginControl.EmailTextBox.IsEnabled = true;
            LoginControl.PasswordBox.IsEnabled = true;
            LoginControl.LoginButton.IsEnabled = true;

            MessageBox.Show(message);
        }

        public void SetPageManager(IPageManager pageManager)
        {
            _pageManager = pageManager;
        }

        private void LoginControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void LoginControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {

        }
    }
}
