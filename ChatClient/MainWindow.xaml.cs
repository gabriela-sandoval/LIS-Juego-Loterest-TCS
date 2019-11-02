using ChatClient.ServiceChat;
using System.Windows;
using System.Windows.Input;

namespace ChatClient
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IServiceChatCallback
    {
        bool isConnected = false;
        ServiceChatClient client;
        int ID;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        void ConnectUser()
        {
            if (!isConnected)
            {
                try
                {
                    client = new ServiceChatClient(new System.ServiceModel.InstanceContext(this));
                    ID = client.Connect(textBoxUserName.Text);
                    textBoxUserName.IsEnabled = false;
                    buttonConectadoDesconectado.Content = "Desconectarme";
                    isConnected = true;
                } catch(System.Exception ex)
                {
                    MessageBox.Show("Error al conectar con el host, no se encuentra disponible, intente en otro momento.", "Error de host");
                }
            }
        }

        void DisconnectUser()
        {
            if (isConnected)
            {
                client.Disconnect(ID);
                client = null;
                textBoxUserName.IsEnabled = true;
                buttonConectadoDesconectado.Content = "Conectarme";
                isConnected = false;
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (isConnected)
            {
                DisconnectUser();
            }
            else
            {
                ConnectUser();
            }

        }

        public void MsgCallback(string msg)
        {
            listBoxChat.Items.Add(msg);
            listBoxChat.ScrollIntoView(listBoxChat.Items[listBoxChat.Items.Count - 1]);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DisconnectUser();
        }

        private void TextBoxMensaje_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (client != null)
                {
                    client.SendMsg(textBoxMensaje.Text, ID);
                    textBoxMensaje.Text = string.Empty;
                }
            }
        }

        private void ButtonEnviar_Click(object sender, RoutedEventArgs e)
        {
            if (client != null)
            {
                client.SendMsg(textBoxMensaje.Text, ID);
                textBoxMensaje.Text = string.Empty;
            }
        }
    }
}
