using System.ServiceModel;
using ServerServices.Model.Enum;

namespace ServerServices.Interface
{
    /// <summary>
    ///     Contrato para el callback del servicio Register.
    /// </summary>
    [ServiceContract]
    public interface IRegisterServiceCallback
    {
        /// <summary>
        ///     Evento que sucede cuando hay una respuesta a la solicitud de registro de usuario.
        /// </summary>
        /// <param name="replyCode">Código de respuesta</param>
        /// <param name="message">Mensaje de respuesta</param>
        [OperationContract(IsOneWay = true)]
        void OnRegisterResponse(RegisterRequestReplyCode replyCode, string message);
    }
}