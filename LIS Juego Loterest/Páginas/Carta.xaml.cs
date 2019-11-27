using System.Windows;
using LIS_Juego_Loterest.Interface;

namespace LIS_Juego_Loterest.Páginas
{
    /// <summary>
    /// Lógica de interacción para Carta.xaml
    /// </summary>
    public partial class Carta : IPageListener
    {
        private IPageManager _pageManager;
        
        public Carta()
        {
            InitializeComponent();
        }

        private void ButtonSeleccionarTablero_Click(object sender, RoutedEventArgs e)
        {
            _pageManager.CambiarPantalla<AlAzar>();
        }

        public void SetPageManager(IPageManager pageManager)
        {
            _pageManager = pageManager;
        }
    }
}
