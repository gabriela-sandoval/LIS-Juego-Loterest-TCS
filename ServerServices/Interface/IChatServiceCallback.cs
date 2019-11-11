using System.ServiceModel;

namespace ServerServices.Interface
{
    /// <summary>
    ///     Contrato para el callback del servicio Chat.
    /// </summary>
    [ServiceContract]
    public interface IChatServiceCallback
    {
        /// <summary>
        ///     Ocurre cuando un cliente se conecta al chat. Avisa a todos los clientes conectados.
        /// </summary>
        /// <param name="username">Nombre de usuario del cliente</param>
        [OperationContract(IsOneWay = true)]
        void OnPlayerConnect(string username);

        /// <summary>
        ///     Ocurre cuando un cliente envía un mensaje al chat. Envía el mismo mensaje a todos los clientes
        ///     conectados, excepto quien envía el mensaje.
        /// </summary>
        /// <param name="username">Nombre de usuario del cliente</param>
        /// <param name="message">Mensaje del cliente</param>
        [OperationContract(IsOneWay = true)]
        void OnPlayerMessage(string username, string message);

        /// <summary>
        ///     Ocurre cuando un cliente se desconecta del chat. Avisa a todos los clientes conectados.
        /// </summary>
        /// <param name="username">Nombre de usuario del cliente</param>
        [OperationContract(IsOneWay = true)]
        void OnPlayerDisconnect(string username);
    }
}