using System.Windows;
using System.Windows.Input;
using ChatClient.ServiceChat;
using LIS_Juego_Loterest.Interface;

namespace LIS_Juego_Loterest.Páginas
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class SalaChat : IPageListener, IServiceChatCallback
    {
        private IPageManager _pageManager;
        
        bool isConnected = false;
        ServiceChatClient client;
        int ID;
        public SalaChat()
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
                }
                catch (System.Exception ex)
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
                listBoxJugadoresDisponibles.Items.Remove(textBoxUserName.Text);
                listBoxJugadoresDisponibles.ScrollIntoView(listBoxJugadoresDisponibles.Items[listBoxJugadoresDisponibles.Items.Count - 1]);
            }
            else
            {
                ConnectUser();
                listBoxJugadoresDisponibles.Items.Add(textBoxUserName.Text);
                listBoxJugadoresDisponibles.ScrollIntoView(listBoxJugadoresDisponibles.Items[listBoxJugadoresDisponibles.Items.Count - 1]);
            }

            //using (Model baseDeDatos = new Model.JuegoLoterest())
            //{
            //    var oJugador = new Model.Jugador();
            //    oJugador.nombre = textBoxNombreDeUsuarioCrearCuenta.Text;
            //    oUsuario.email = textBoxCorreoElectronicoCrearCuenta.Text;
            //    oUsuario.contrasena = PasswordBoxContraseniaCrearCuenta.Password;

            //    db.Usuarios.Add(oUsuario);
            //    db.SaveChanges();
            //}

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

        private void ListBoxJugadoresDisponibles_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            ConnectUser();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
        }

        public void SetPageManager(IPageManager pageManager)
        {
            _pageManager = pageManager;
        }
    }
}
