using System.ServiceModel;

namespace ServerServices.Interface
{
    [ServiceContract(CallbackContract = typeof(IChatServiceCallback))]
    public interface IChatService
    {
        [OperationContract(IsOneWay = true)]
        void Connect(string userGuid);
        
        [OperationContract(IsOneWay = true)]
        void SendMessage(string userGuid, string message);
    }
}