using ServerServices.Util;

namespace ServerServices.Model
{
    /// <summary>
    ///     Representa un cliente conectado al servidor.
    /// </summary>
    /// <typeparam name="TCallback">Tipo de callback de servicio</typeparam>
    public class Client<TCallback>
    {
        /// <summary>
        ///     Wrapper del contexto de operación de WCF del cliente.
        /// </summary>
        private readonly OperationContextWrapper<TCallback> _operationContext;

        public Client(OperationContextWrapper<TCallback> operationContext)
        {
            _operationContext = operationContext;
        }

        /// <summary>
        ///     Id (Guid) de la sesión del cliente.
        /// </summary>
        public string SessionId { get; set; }

        /// <summary>
        ///     Nombre de usuario del cliente.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        ///     Devuelve el canal de callback del servicio.
        /// </summary>
        /// <returns>Canal de callback del servicio</returns>
        public TCallback GetCallbackProxy()
        {
            return _operationContext.GetCallback();
        }
    }
}