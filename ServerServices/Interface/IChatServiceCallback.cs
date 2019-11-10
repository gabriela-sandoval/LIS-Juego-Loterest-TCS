using System.ServiceModel;

namespace ServerServices.Interface
{
    [ServiceContract]
    public interface IChatServiceCallback
    {
        [OperationContract(IsOneWay = true)]
        void OnPlayerConnect(string guid);
        
        [OperationContract(IsOneWay = true)]
        void OnPlayerMessage(string guid, string message);
        
        [OperationContract(IsOneWay = true)]
        void OnPlayerDisconnect(string guid);
    }
}