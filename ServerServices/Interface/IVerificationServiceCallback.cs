using System.ServiceModel;
using ServerServices.Model.Enum;

namespace ServerServices.Interface
{
    /// <summary>
    ///     Contrato para el callback del servicio Verification.
    /// </summary>
    [ServiceContract]
    public interface IVerificationServiceCallback
    {
        /// <summary>
        ///     Evento que sucede cuando hay una respuesta a la solicitud de verificación.
        /// </summary>
        /// <param name="replyCode">Código de respuesta</param>
        [OperationContract(IsOneWay = true)]
        void OnVerificationResponse(VerificationRequestReplyCode replyCode);
    }
}