using System.Windows;
using System.Windows.Input;

namespace LIS_Juego_Loterest.Ventanas
{
    public partial class SalaChat : Window
    {
        public SalaChat()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        void ConnectUser()
        {
            
        }

        void DisconnectUser()
        {
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
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
            
        }

        private void ButtonEnviar_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void ListBoxJugadoresDisponibles_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            ConnectUser();
        }

        private void JugarButton_Click(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
