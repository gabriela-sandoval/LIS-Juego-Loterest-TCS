using System.Windows;
using System.Windows.Input;
using LIS_Juego_Loterest.Interface;

namespace LIS_Juego_Loterest.Páginas
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class SalaChat : IPageListener
    {
        private IPageManager _pageManager;
        
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
        }

        public void SetPageManager(IPageManager pageManager)
        {
            _pageManager = pageManager;
        }
    }
}
