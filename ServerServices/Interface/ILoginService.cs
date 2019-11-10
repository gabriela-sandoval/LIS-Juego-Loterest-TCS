using System.ServiceModel;

namespace ServerServices.Interface
{
    /// <summary>
    ///     Contrato para el servicio Login
    /// </summary>
    [ServiceContract(CallbackContract = typeof(ILoginServiceCallback))]
    public interface ILoginService
    {
        
        /// <summary>
        ///     Realiza una solicitud de inicio de sesión en el servidor, donde el cliente proporciona su usuario
        ///     y su contraseña.
        /// </summary>
        /// <param name="username">Usuario del cliente</param>
        /// <param name="password">Contraseña del cliente</param>
        [OperationContract(IsOneWay = true)]
        void RequestLogin(string username, string password);

        /// <summary>
        ///     Solicita el cierre de sesión de un cliente en el servidor.
        /// </summary>
        /// <param name="sessionId">Id de la sesión del cliente</param>
        [OperationContract]
        void Logout(string sessionId);
    }
}