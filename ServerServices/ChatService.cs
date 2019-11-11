using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using ServerServices.Interface;
using ServerServices.Model;
using ServerServices.Util;

namespace ServerServices
{
    public partial class ServiceHost : IChatService
    {
        /// <summary>
        ///     Lista de Clientes conectados al chat.
        /// </summary>
        private readonly List<Client<IChatServiceCallback>> _chatClients = new List<Client<IChatServiceCallback>>();

        public void Connect(string sessionId)
        {
            var client = _chatClients.FirstOrDefault(c => c.SessionId == sessionId);
            if (client == null)
            {
                // El cliente no tiene una sesión iniciada.
            }
            else
            {
                // Todos los demás clientes
                var clients = _chatClients.Where(c => c.SessionId != sessionId);

                // Notificar a los demás clientes
                foreach (var c in clients)
                {
                    var proxy = c.GetCallbackProxy();
                    proxy.OnPlayerConnect(client.Username);
                }
            }
        }

        public string ConnectWithUsername(string username)
        {
            var sessionId = Guid.NewGuid().ToString();
            var operationContext = new OperationContextWrapper<IChatServiceCallback>(OperationContext.Current);
            var client = new Client<IChatServiceCallback>(operationContext)
            {
                Username = username,
                SessionId = sessionId
            };
            _chatClients.Add(client);
            OperationContext.Current.Channel.Closed += delegate { Disconnect(sessionId); };
            OperationContext.Current.Channel.Faulted += delegate { Disconnect(sessionId); };

            Console.WriteLine($"{username} connected. ({sessionId})");
            Console.WriteLine($"{_chatClients.Count} clients connected.");

            // Todos los demás clientes
            var clients = _chatClients.Where(c => c.SessionId != sessionId);

            // Notificar a los demás clientes
            foreach (var c in clients)
            {
                var proxy = c.GetCallbackProxy();
                proxy.OnPlayerConnect(client.Username);
            }

            return sessionId;
        }

        public List<string> GetConnectedUsers()
        {
            return _chatClients.Select(e => e.Username).ToList();
        }

        public void SendMessage(string sessionId, string message)
        {
            // Cliente que envía el mensaje
            var client = _chatClients.FirstOrDefault(c => c.SessionId == sessionId);
            if (client == null) return;

            Console.WriteLine($"{client.Username}: {message}");

            // Enviar mensaje a todos los clientes
            foreach (var c in _chatClients)
            {
                var proxy = c.GetCallbackProxy();
                proxy.OnPlayerMessage(client.Username, message);
            }
        }

        public void Disconnect(string sessionId)
        {
            // Cliente que envía el mensaje
            var client = _chatClients.FirstOrDefault(c => c.SessionId == sessionId);
            if (client == null) return;

            _chatClients.Remove(client);
            Console.WriteLine($"{client.Username} disconnected.");
            Console.WriteLine($"{_chatClients.Count} clients connected.");

            // Todos los demás clientes
            var clients = _chatClients.Where(c => c.SessionId != sessionId);

            // Enviar mensaje a los demás clientes
            foreach (var c in clients)
            {
                var proxy = c.GetCallbackProxy();
                proxy.OnPlayerDisconnect(client.Username);
            }
        }
    }
}