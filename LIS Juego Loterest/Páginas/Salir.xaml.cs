using LIS_Juego_Loterest.Interface;

namespace LIS_Juego_Loterest.Páginas
{
    /// <summary>
    /// Lógica de interacción para Salir.xaml
    /// </summary>
    public partial class Salir : IPageListener
    {
        private IPageManager _pageManager;
        
        public Salir()
        {
            InitializeComponent();
        }

        public void SetPageManager(IPageManager pageManager)
        {
            _pageManager = pageManager;
        }
    }
}
