using System;
using System.ServiceModel;

namespace ServerServices.Model
{
    public class Client
    {
        public string SessionId { get; set; }
        public string Username { get; set; }
        private readonly OperationContext _operationContext;

        public Client(OperationContext operationContext)
        {
            _operationContext = operationContext;
        }

        public T GetCallbackProxy<T>() where T : class
        {
            return _operationContext.GetCallbackChannel<T>();
        }
    }
}