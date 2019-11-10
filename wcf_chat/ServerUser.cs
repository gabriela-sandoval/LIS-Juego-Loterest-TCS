using System.ServiceModel;
namespace WcfServices
{
    public class ServerUser
    {
        public int idUser { get; set; }

        public string nameUser { get; set; }

        public OperationContext operationContext { get; set; }
    }
}
