using System.Collections.ObjectModel;
using System.ServiceModel;
using System.Windows;
using System.Windows.Input;
using ServerServices.Interface;

namespace ChatClient
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : IChatServiceCallback
    {
        private readonly IChatService _chatService;
        private readonly ObservableCollection<string> _clients = new ObservableCollection<string>();
        private readonly ObservableCollection<string> _messages = new ObservableCollection<string>();
        private string _sessionId;
        
        public MainWindow()
        {
            InitializeComponent();
            var duplexChannelFactory = new DuplexChannelFactory<IChatService>(new InstanceContext(this), "*");
            _chatService = duplexChannelFactory.CreateChannel();
            listBoxJugadoresDisponibles.ItemsSource = _clients;
            listBoxChat.ItemsSource = _messages;
        }

        private bool IsConnected()
        {
            return !string.IsNullOrEmpty(_sessionId);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (IsConnected())
                {
                    _chatService.Disconnect(_sessionId);
                    _sessionId = null;
                    _clients.Clear();
                    _messages.Clear();
                }
                else
                {
                    var username = textBoxUserName.Text;
                    _sessionId = _chatService.ConnectWithUsername(username);
                    _messages.Add($"{username} se ha unido al chat.");
                    var connectedUsers = _chatService.GetConnectedUsers();
                    foreach (var connectedUser in connectedUsers)
                    {
                        _clients.Add(connectedUser);
                    }
                }
            } catch
            {
                MessageBox.Show("El servidor no se encuentra disponible, intente nuevamente", "Servidor no encontrado", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _chatService.Disconnect(_sessionId);

        }

        private void TextBoxMensaje_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ButtonEnviar_Click(sender, e);
            }
        }

        private void ButtonEnviar_Click(object sender, RoutedEventArgs e)
        {
            var message = textBoxMensaje.Text;
            if (!string.IsNullOrWhiteSpace(message))
            {
                _chatService.SendMessage(_sessionId, message);
                textBoxMensaje.Clear();
            }
        }

        public void OnPlayerConnect(string username)
        {
            _clients.Add(username);
            AddMessageToChat($"{username} se conectó.");
        }

        public void OnPlayerMessage(string username, string message)
        {
            AddMessageToChat($"{username}: {message}");
        }

        public void OnPlayerDisconnect(string username)
        {
            _clients.Remove(username);
            AddMessageToChat($"{username} se desconectó.");
        }

        private void AddMessageToChat(string message)
        {
            _messages.Add(message);
            listBoxChat.ScrollIntoView(listBoxChat.Items[listBoxChat.Items.Count - 1]);
        }
    }
}
