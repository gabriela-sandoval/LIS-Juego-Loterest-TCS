using LIS_Juego_Loterest.Interface;

namespace LIS_Juego_Loterest.Páginas
{
    /// <summary>
    /// Lógica de interacción para Perdiste.xaml
    /// </summary>
    public partial class Perdiste : IPageListener
    {
        private IPageManager _pageManager;
        
        public Perdiste()
        {
            InitializeComponent();
        }

        public void SetPageManager(IPageManager pageManager)
        {
            _pageManager = pageManager;
        }
    }
}
