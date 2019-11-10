using ServerServices.Interface;

namespace ServerServices
{
    public partial class ServiceHost: IChatService, IChatServiceCallback
    {
        public void Connect(string userGuid)
        {
            throw new System.NotImplementedException();
        }

        public void SendMessage(string userGuid, string message)
        {
            throw new System.NotImplementedException();
        }

        public void OnPlayerConnect(string guid)
        {
            throw new System.NotImplementedException();
        }

        public void OnPlayerMessage(string guid, string message)
        {
            throw new System.NotImplementedException();
        }

        public void OnPlayerDisconnect(string guid)
        {
            throw new System.NotImplementedException();
        }
    }
}