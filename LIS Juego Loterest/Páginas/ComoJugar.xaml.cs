using LIS_Juego_Loterest.Interface;

namespace LIS_Juego_Loterest.Páginas
{
    /// <summary>
    /// Lógica de interacción para ComoJugar.xaml
    /// </summary>
    public partial class ComoJugar : IPageListener
    {
        private IPageManager _pageManager;
        
        public ComoJugar()
        {
            InitializeComponent();
        }

        public void SetPageManager(IPageManager pageManager)
        {
            _pageManager = pageManager;
        }
    }
}
