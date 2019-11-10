using System.ServiceModel;
using ServerServices.Model.Enum;

namespace ServerServices.Interface
{
    /// <summary>
    ///     Contrato para el callback del servicio Login.
    /// </summary>
    [ServiceContract]
    public interface ILoginServiceCallback
    {
        /// <summary>
        ///     Evento que sucede cuando el inicio de sesión fue exitoso.
        /// </summary>
        /// <param name="sessionId">Id de la sesión del cliente</param>
        [OperationContract(IsOneWay = true)]
        void OnLoginSuccess(string sessionId);

        /// <summary>
        ///     Evento que sucede cuando hubo un error al realizar un inicio de sesión.
        /// </summary>
        /// <param name="replyCode">Código de respuesta</param>
        /// <param name="message">Mensaje del error</param>
        [OperationContract(IsOneWay = true)]
        void OnLoginError(LoginRequestReplyCode replyCode, string message);

        /// <summary>
        ///     Evento que sucede cuando hay una respuesta a la solicitud de registro de usuario.
        /// </summary>
        /// <param name="replyCode">Código de respuesta</param>
        /// <param name="message">Mensaje de respuesta</param>
        [OperationContract(IsOneWay = true)]
        void OnRegisterResponse(RegisterRequestReplyCode replyCode, string message);

        /// <summary>
        ///     Evento que sucede cuando hay una respuesta a la solicitud de verificación.
        /// </summary>
        /// <param name="replyCode">Código de respuesta</param>
        [OperationContract(IsOneWay = true)]
        void OnVerificationResponse(VerificationRequestReplyCode replyCode);
    }
}