using LIS_Juego_Loterest.Interface;

namespace LIS_Juego_Loterest.Páginas
{
    /// <summary>
    /// Lógica de interacción para Idioma.xaml
    /// </summary>
    public partial class Idioma : IPageListener
    {
        private IPageManager _pageManager;
        
        public Idioma()
        {
            InitializeComponent();
        }

        public void SetPageManager(IPageManager pageManager)
        {
            _pageManager = pageManager;
        }
    }
}
