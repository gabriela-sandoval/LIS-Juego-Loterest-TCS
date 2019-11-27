using System;
using System.ServiceModel;
using DataAccess.DAO;
using DataAccess.DAO.Interface;
using DataAccess.Exception;
using ServerServices.Interface;
using ServerServices.Model.Enum;
using ServerServices.Util;

namespace ServerServices
{
    public partial class ServiceHost : ILoginService
    {
        private readonly IJugadorDAO _jugadorDAO = new JugadorDAO();

        public void LoginRequest(string username, string password)
        {
            Console.WriteLine($"Solicitud de inicio de sesión del usuario '{username}'");
            var operationContext = new OperationContextWrapper<ILoginServiceCallback>(OperationContext.Current);
            var loginCallback = operationContext.GetCallback();
            
            // TODO Verificar que no exista una sesión activa.

            try
            {
                var jugador = _jugadorDAO.GetJugadorConCredenciales(username, password);
                var sessionId = Guid.NewGuid().ToString();

                loginCallback.OnLoginSuccess(sessionId);
            }
            catch (DAOException e)
            {
                loginCallback.OnLoginError(LoginRequestReplyCode.GeneralError, e.Message);
            }
        }

        public void RegisterRequest(string username, string password, string email)
        {
        }

        public void VerificationRequest(string username, string code)
        {
        }

        public void ResetPasswordRequest(string usernameOrEmail)
        {
        }

        public void Logout(string sessionId)
        {
        }
    }
}