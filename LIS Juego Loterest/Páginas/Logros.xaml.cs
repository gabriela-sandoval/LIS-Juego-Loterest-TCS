using LIS_Juego_Loterest.Interface;

namespace LIS_Juego_Loterest.Páginas
{
    /// <summary>
    /// Lógica de interacción para Logros.xaml
    /// </summary>
    public partial class Logros : IPageListener
    {
        private IPageManager _pageManager;
        
        public Logros()
        {
            InitializeComponent();
        }

        public void SetPageManager(IPageManager pageManager)
        {
            _pageManager = pageManager;
        }
    }
}
