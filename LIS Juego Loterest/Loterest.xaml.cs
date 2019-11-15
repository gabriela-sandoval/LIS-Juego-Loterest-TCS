
using System.Windows;
using System.Windows.Controls;
using LIS_Juego_Loterest.Interface;
using LIS_Juego_Loterest.Páginas;

namespace LIS_Juego_Loterest
{
    /// <summary>
    /// Lógica de interaOnSizeChangedterest.xaml
    /// </summary>
    public partial class Loterest : IPageManager
    {
        public Loterest()
        {
            InitializeComponent();
            CambiarPantalla<InicioSesión>();
        }

        private void OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            ChangePageSize(e);
        }

        private void ChangePageSize(SizeChangedEventArgs e = null)
        {
            var page = (FrameworkElement) Content;
            if (e != null)
            {
                page.Width = e.NewSize.Width;
                page.Height = e.NewSize.Height;
            }
            else
            {
                page.Width = Width;
                page.Height = Height;
            }
        }

        public T CambiarPantalla<T>() where T : Page, IPageListener, new()
        {
            var page = new T();
            page.SetPageManager(this);
            Content = page;
            ChangePageSize();
            return page;
        }
    }
}
