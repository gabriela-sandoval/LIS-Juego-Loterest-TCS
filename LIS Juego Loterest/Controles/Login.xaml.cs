using System;
using System.Windows;

namespace LIS_Juego_Loterest.Controles
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login
    {
        public event EventHandler<LoginArgs> LoginButtonClicked;

        public Login()
        {
            InitializeComponent();
        }
        
        private void OnLoginInputTextChanged(object sender, RoutedEventArgs routedEventArgs)
        {
            var username = UsernameTextBox.Text.Trim();
            var password = PasswordBox.Password.Trim();
            
            // Habilitar el botón "Iniciar sesión" si ambos campos contienen texto.
            LoginButton.IsEnabled = !(string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password));
        }

        private void OnLoginButtonClick(object sender, EventArgs eventArgs)
        {
            // Deshabilitar campos de texto y botón.
            UsernameTextBox.IsEnabled = false;
            PasswordBox.IsEnabled = false;
            LoginButton.IsEnabled = false;
            
            var username = UsernameTextBox.Text;
            var password = PasswordBox.Password;
            var loginArgs = new LoginArgs(username, password);
            LoginButtonClicked?.Invoke(this, loginArgs);
        }
        
        public class LoginArgs : EventArgs
        {
            public string Username { get; }
            public string Password { get; }
            
            public LoginArgs(string username, string password)
            {
                Username = username;
                Password = password;
            }
        }

        private void OnLoginInputTextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }
    }
}
