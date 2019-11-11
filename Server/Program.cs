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
                Console.WriteLine("\n");
                Console.WriteLine(" Configuration Name: " + host.Description.ConfigurationName);
                Console.WriteLine(" End point address: " + host.Description.Endpoints[0].Address);
                Console.WriteLine(" End point binding: " + host.Description.Endpoints[0].Binding.Name);
                Console.WriteLine(" End point contract: " + host.Description.Endpoints[0].Contract.ConfigurationName);
                Console.WriteLine(" End point name: " + host.Description.Endpoints[0].Name);
                Console.WriteLine(" End point lisent uri: " + host.Description.Endpoints[0].ListenUri);
                Console.WriteLine(" \nName:" + host.Description.Name);
                Console.WriteLine(" Namespace: " + host.Description.Namespace);
                Console.WriteLine(" Service Type: " + host.Description.ServiceType);
                Console.WriteLine("\n");
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