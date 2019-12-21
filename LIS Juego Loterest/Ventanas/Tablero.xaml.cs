using System.Windows;
using LIS_Juego_Loterest.Interface;

namespace LIS_Juego_Loterest.Páginas
{
    /// <summary>
    /// Lógica de interacción para Tablero.xaml
    /// </summary>
    public partial class Tablero : IPageListener
    {
        private IPageManager _pageManager;
        
        public Tablero()
        {
            InitializeComponent();
        }

        private void ButtonSeleccionarTablero_Click(object sender, RoutedEventArgs e)
        {
            _pageManager.CambiarPantalla<Loteria>();
        }

        private void ButtonRegresar_Click(object sender, RoutedEventArgs e)
        {
            _pageManager.CambiarPantalla<Menú>();
        }


        public void SetPageManager(IPageManager pageManager)
        {
            _pageManager = pageManager;
        }
    }
}
