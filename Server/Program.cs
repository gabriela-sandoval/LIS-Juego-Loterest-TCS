using System;
using System.ServiceModel;
using Host = System.ServiceModel.ServiceHost;
using ServiceHost = ServerServices.ServiceHost;

namespace Server
{
    internal static class Program
    {
        public static void Main()
        {
            var host = new Host(typeof(ServiceHost));
            try
            {
                host.Open();
                Console.WriteLine("Press <Enter> to terminate the service.");
                Console.ReadLine();
                host.Close();
            }
            catch (CommunicationException e)
            {
                Console.WriteLine("An exception occurred: {0}", e.Message);
                host.Abort();
            }
        }
    }
}