using System;
using System.ServiceModel;
using DataAccess.DAO;

namespace ServerServices
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public partial class ServiceHost
    {
        public ServiceHost()
        {
            var jugadorDAO = new JugadorDAO();
            var jugadores = jugadorDAO.GetTotalJugadores();
            Console.WriteLine($"Hay {jugadores} en la base de datos.");
        }
    }
}