using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using ServerServices.Interface;
using ServerServices.Model;
using ServerServices.Util;

namespace ServerServices
{
    public partial class ServiceHost : ILoginService
    {
        /// <summary>
        ///     Lista de Clientes conectados al servidor con una sesión válida.
        /// </summary>
        private readonly List<Client<ILoginServiceCallback>> _clients = new List<Client<ILoginServiceCallback>>();

        public void LoginRequest(string username, string password)
        {
            Console.WriteLine("Request login from " + username);
            var operationContext = new OperationContextWrapper<ILoginServiceCallback>(OperationContext.Current);
            var loginCallback = operationContext.GetCallback();
            // TODO Verificar que no exista una sesión activa.
            // TODO Verificar si la combinación existe en base de datos

            var client = new Client<ILoginServiceCallback>(operationContext)
            {
                SessionId = Guid.NewGuid().ToString(),
                Username = username
            };

            _clients.Add(client);

            loginCallback.OnLoginSuccess(client.SessionId);
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
            // Buscar algún cliente que su sessionId coincida.
            var client = _clients.FirstOrDefault(c => c.SessionId == sessionId);

            // Quitamos el cliente de la lista de clientes.
            _clients.Remove(client);
        }
    }
}