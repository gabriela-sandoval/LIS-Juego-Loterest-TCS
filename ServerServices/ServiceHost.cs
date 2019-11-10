using System.ServiceModel;

namespace ServerServices
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public partial class ServiceHost
    {
    }
}