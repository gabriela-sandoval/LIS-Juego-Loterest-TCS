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
using System.Windows.Shapes;
using System.Windows.Threading;
using LIS_Juego_Loterest.Interface;
using LIS_Juego_Loterest.Páginas;

namespace LIS_Juego_Loterest
{
    /// <summary>
    /// Lógica de interacción para Loteria.xaml
    /// </summary>
    public partial class Loteria : IPageListener
    {
        private IPageManager _pageManager;
        
        public Loteria()
        {
            InitializeComponent();
        }

        private void ButtonRegresar_Click(object sender, RoutedEventArgs e)
        {
            _pageManager.CambiarPantalla<Menú>();
        }

        private void ButtonLoteria_Click(object sender, RoutedEventArgs e)
        {
            _pageManager.CambiarPantalla<Ganaste>();
        }

        public void SetPageManager(IPageManager pageManager)
        {
            _pageManager = pageManager;
        }

        private void Loteria1_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private int increment = 0;
        private void DispatcherTimerTickSeconds(object sender, EventArgs e)
        {
            increment++;
            TiempoLabel.Content = increment.ToString();
        }
    }
}
