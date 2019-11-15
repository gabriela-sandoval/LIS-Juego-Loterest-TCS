using System.Windows;
using LIS_Juego_Loterest.Interface;

namespace LIS_Juego_Loterest.Páginas
{
    /// <summary>
    /// Lógica de interacción para Al_azar.xaml
    /// </summary>
    public partial class AlAzar : IPageListener
    {
        private IPageManager _pageManager;
        
        public AlAzar()
        {
            InitializeComponent();
        }

        private void ButtonLoteria_Click(object sender, RoutedEventArgs e)
        {
            _pageManager.CambiarPantalla<Perdiste>();
        }

        public void SetPageManager(IPageManager pageManager)
        {
            _pageManager = pageManager;
        }
    }
}
