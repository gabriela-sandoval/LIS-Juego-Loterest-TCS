using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LIS_Juego_Loterest.Controles
{
    /// <summary>
    /// Lógica de interacción para RegistrarJugador.xaml
    /// </summary>
    public partial class RegistrarJugador
    {
        public event EventHandler<RegisterPlayerArgs> RegisterPlayerButtonClicked;

        public RegistrarJugador()
        {
            InitializeComponent();
        }

        private void OnRegisterPlayerInputTextChanged(object sender, RoutedEventArgs routedEventArgs)
        {
            
        }

        private void RegisterPlayerButtonClick(object sender, EventArgs eventArgs)
        {
            
        }

        public class RegisterPlayerArgs : EventArgs
        {
            public string Username { get; }
            public string Email { get; }
            public string Password { get; }

            public RegisterPlayerArgs(string username, string email, string password)
            {
                Username = username;
                Email = email;
                Password = password;
            }
        }

        private void SiguienteButton_Click(object sender, RoutedEventArgs e)
        {

        }


    }
}
