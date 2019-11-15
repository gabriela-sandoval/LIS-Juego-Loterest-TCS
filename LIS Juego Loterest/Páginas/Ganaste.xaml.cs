using System.Windows;
using LIS_Juego_Loterest.Interface;

namespace LIS_Juego_Loterest.Páginas
{
    /// <summary>
    /// Lógica de interacción para Ganaste.xaml
    /// </summary>
    public partial class Ganaste : IPageListener
    {
        private IPageManager _pageManager;
        
        public Ganaste()
        {
            InitializeComponent();
        }

        private void ButtonAceptar_Click(object sender, RoutedEventArgs e)
        {
            _pageManager.CambiarPantalla<Menú>();
        }

        public void SetPageManager(IPageManager pageManager)
        {
            _pageManager = pageManager;
        }
    }
}
