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

using ChatClient.ServiceChat;

namespace LIS_Juego_Loterest
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool isConnected = false;
        ServiceChatClient client;
        int ID;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonSiguienteIniciarSesion_Click(object sender, RoutedEventArgs e)
        {

                        Verificación verificación = new Verificación();
                        verificación.Show();

                        this.Close();

        }

        private void ButtonIngresarIniciarSesion_Click(object sender, RoutedEventArgs e)
        {
            
                    Menú menú = new Menú();
                    menú.Show();

                    this.Close();
        }



    }
}
