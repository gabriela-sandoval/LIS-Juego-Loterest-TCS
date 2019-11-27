using System;
using System.ServiceModel;
using LIS_Juego_Loterest.Controles;
using LIS_Juego_Loterest.Util;
using ServerServices.Interface;
using ServerServices.Model.Enum;

namespace LIS_Juego_Loterest.Páginas
{
    /// <summary>
    /// Lógica de interacción para InicioSesión.xaml
    /// </summary>
    public partial class InicioSesión : ILoginServiceCallback
    {
        /// <summary>
        ///     Interfaz del servicio de Login que se conecta al servidor.
        /// </summary>
        private readonly ILoginService _loginService;

        private readonly Loterest.IPageManager _pageManager;
        
        public InicioSesión(Loterest.IPageManager pageManager)
        {
            InitializeComponent();
            _loginService = ClientFactory.CreateDuplexChannel<ILoginService, ILoginServiceCallback>(this);
            _pageManager = pageManager;
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
            var menú = new Menú();
            _pageManager.ChangePage(menú);
            Console.WriteLine(sessionId);
        }

        public void OnLoginError(LoginRequestReplyCode replyCode, string message)
        {
            // Rehabilitar campos de texto y botón
            LoginControl.EmailTextBox.IsEnabled = true;
            LoginControl.PasswordBox.IsEnabled = true;
            LoginControl.LoginButton.IsEnabled = true;
            
            Console.WriteLine(message);
        }

        public void OnRegisterResponse(RegisterRequestReplyCode replyCode, string message)
        {
            
        }

        public void OnVerificationResponse(VerificationRequestReplyCode replyCode)
        {
            
        }

        private void LoginControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {

        }
    }
}
