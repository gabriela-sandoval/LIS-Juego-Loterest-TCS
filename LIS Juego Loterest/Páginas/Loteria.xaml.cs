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
    }
}
