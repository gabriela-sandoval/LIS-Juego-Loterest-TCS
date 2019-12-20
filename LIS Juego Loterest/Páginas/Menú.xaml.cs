using System.Windows;
using LIS_Juego_Loterest.Interface;

namespace LIS_Juego_Loterest.Páginas
{
    /// <summary>
    /// Lógica de interacción para Menú.xaml
    /// </summary>
    public partial class Menú : IPageListener
    {
        private IPageManager _pageManager;
        
        public Menú()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _pageManager.CambiarPantalla<Tablero>();;
        }

        private void ButtonAlAzar_Click(object sender, RoutedEventArgs e)
        {
            _pageManager.CambiarPantalla<Carta>();
        }

        private void ButtonIdioma_Click(object sender, RoutedEventArgs e)
        {
            _pageManager.CambiarPantalla<Idioma>();
        }

        private void ButtonComoJugar_Click(object sender, RoutedEventArgs e)
        {
            _pageManager.CambiarPantalla<ComoJugar>();
        }

        private void ButtonAcercaDe_Click(object sender, RoutedEventArgs e)
        {
           // _pageManager.CambiarPantalla<AcercaDe>();
        }

        private void ButtonSalir_Click(object sender, RoutedEventArgs e)
        {
            _pageManager.CambiarPantalla<Salir>();
        }

        private void ButtonPuntaje_Click(object sender, RoutedEventArgs e)
        {
            _pageManager.CambiarPantalla<Puntaje>();
        }

        public void SetPageManager(IPageManager pageManager)
        {
            _pageManager = pageManager;
        }

        private void ChatButton_Click(object sender, RoutedEventArgs e)
        {
            _pageManager.CambiarPantalla<SalaChat>();
        }
    }
}
