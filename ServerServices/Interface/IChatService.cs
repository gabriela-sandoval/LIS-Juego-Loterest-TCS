using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace ServerServices.Interface
{
    /// <summary>
    ///     Contrato para el servicio Chat
    /// </summary>
    [ServiceContract(CallbackContract = typeof(IChatServiceCallback), SessionMode = SessionMode.Required)]
    public interface IChatService
    {
        /// <summary>
        ///     Realiza una solicitud de conexión al chat, proporcionando la id de sesión.
        /// </summary>
        /// <param name="sessionId">Id de la sesión del cliente</param>
        [OperationContract(IsOneWay = true)]
        void Connect(string sessionId);

        /// <summary>
        ///     Realiza una solicitud de conexión al chat, proporcionando un nombre de usuario.
        /// </summary>
        /// <param name="username">Nombre de usuario</param>
        /// <returns>Id de la sesión del cliente</returns>
        [Obsolete]
        [OperationContract]
        string ConnectWithUsername(string username);

        [OperationContract]
        List<string> GetConnectedUsers();

        /// <summary>
        ///     Envía un mensaje al chat, proporcionando la id de sesión. Envía a todos los usuarios conectados
        ///     el mensaje, excepto quien lo envía.
        /// </summary>
        /// <param name="sessionId">Id de la sesión del cliente</param>
        /// <param name="message">Mensaje del cliente</param>
        [OperationContract(IsOneWay = true)]
        void SendMessage(string sessionId, string message);

        /// <summary>
        ///     Realiza una solicitud de desconexión del chat, proporcionando la id de sesión.
        /// </summary>
        /// <param name="sessionId">Id de la sesión del cliente</param>
        [OperationContract]
        void Disconnect(string sessionId);
    }
}