using System.Windows;
using System.Windows.Controls;
using LIS_Juego_Loterest.Interface;

namespace LIS_Juego_Loterest.Páginas
{
    /// <summary>
    /// Lógica de interacción para Puntaje.xaml
    /// </summary>
    public partial class Puntaje : IPageListener
    {
        private IPageManager _pageManager;
        
        public Puntaje()
        {
            InitializeComponent();
        }

        private void TextBoxUserName_Copy1_TextChanged(object sender, TextChangedEventArgs e)
        {

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
