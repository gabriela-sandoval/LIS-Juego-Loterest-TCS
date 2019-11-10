using System.Collections.Generic;
using System.ServiceModel;
using ServerServices.Model;

namespace ServerServices
{
    public partial class ServiceHost
    {
        /// <summary>
        ///     Lista de Clientes conectados al servidor con una sesión válida.
        /// </summary>
        private List<Client> _clients = new List<Client>();

        private static T GetCallbackChannel<T>(OperationContext operationContext)
        {
            return operationContext.GetCallbackChannel<T>();
        }
    }
}