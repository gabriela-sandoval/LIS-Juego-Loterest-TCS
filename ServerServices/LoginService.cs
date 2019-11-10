using System;
using System.Linq;
using System.ServiceModel;
using ServerServices.Interface;
using ServerServices.Model;

namespace ServerServices
{
    public partial class ServiceHost : ILoginService
    {
        public void RequestLogin(string username, string password)
        {
            Console.WriteLine("Request login from " + username);
            var operationContext = OperationContext.Current;
            var loginCallback = GetCallbackChannel<ILoginServiceCallback>(operationContext);
            // TODO Verificar que no exista una sesión activa.
            // TODO Verificar si la combinación existe en base de datos
            
            var client = new Client(operationContext)
            {
                SessionId = Guid.NewGuid().ToString(),
                Username = username
            };
            
            _clients.Add(client);
            
            loginCallback.OnLoginSuccess(client.SessionId);
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