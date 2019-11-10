using System.ServiceModel;

namespace ServerServices.Interface
{
    [ServiceContract]
    public interface ILoginServiceCallback
    {
        [OperationContract(IsOneWay = true)]
        void OnLoginSuccess(string guid);
        
        [OperationContract(IsOneWay = true)]
        void OnLoginError(string message);
    }
}