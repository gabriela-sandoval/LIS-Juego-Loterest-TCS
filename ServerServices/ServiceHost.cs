using System;
using System.Linq;
using System.ServiceModel;
using DataModel;

namespace ServerServices
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public partial class ServiceHost
    {
        private DatabaseContext _database;
        
        public ServiceHost()
        {
            _database = new DatabaseContext();
            var jugadores = _database.Jugador.ToArray();
            Console.WriteLine($"Hay {jugadores.Length} en la base de datos.");
        }
    }
}