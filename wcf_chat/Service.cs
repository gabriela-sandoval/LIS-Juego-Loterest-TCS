using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;


namespace WcfServices
{
  
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Service : IService
    {
        List<ServerUser> users = new List<ServerUser>();
        int nextId = 1;

        public int Connect(string nameUserConnect)
        {
            
            ServerUser user = new ServerUser() {
                idUser = nextId,
                nameUser = nameUserConnect,
                operationContext = OperationContext.Current
            };
            nextId++;

            SendMsg(user.nameUser + " se conectó al chat.",0);
            Console.WriteLine("Usuario conectado: " + user.nameUser);
            // Notificar a todos los clientes excepto el que se conectó, cuál
            // es el username del nuevo cliente.
            users.Add(user);
            return user.idUser;
        }

        public void Disconnect(int idUserDisconnect)
        {
            var user = users.FirstOrDefault(i => i.idUser == idUserDisconnect);
            if (user!=null)
            {
                users.Remove(user);
                SendMsg(user.nameUser + " se desconectó del chat.",0);
                Console.WriteLine("Usuario desconectado: " + user.nameUser);
            }
        }

        public void SendMsg(string mensage, int idUser)
        {
            foreach (var item in users)
            {
                string answer = "";

                var user = users.FirstOrDefault(i => i.idUser == idUser);
                if (user != null)
                {
                    answer += user.nameUser + " (" + DateTime.Now.ToShortTimeString() + "): ";
                }
                answer += mensage;
                item.operationContext.GetCallbackChannel<IServerChatCallback>().MsgCallback(answer);
            }
        }

        public int ConnectUser(string nameUserConnect)
        {

            ServerUser user = new ServerUser()
            {
                idUser = nextId,
                nameUser = nameUserConnect,
                operationContext = OperationContext.Current
            };
            nextId++;

            SendMsg(user.nameUser, 0);
            users.Add(user);
            return user.idUser;
        }

        public void DisconnectUser(int idUserDisconnect)
        {
            var user = users.FirstOrDefault(i => i.idUser == idUserDisconnect);
            if (user != null)
            {
                users.Remove(user);
            }
        }
    }
}
