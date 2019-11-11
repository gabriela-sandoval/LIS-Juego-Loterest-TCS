using System;
using System.Windows;
using System.Windows.Controls;
using LIS_Juego_Loterest.Páginas;

namespace LIS_Juego_Loterest
{
    /// <summary>
    /// Lógica de interaOnSizeChangedterest.xaml
    /// </summary>
    public partial class Loterest : Loterest.IPageManager
    {
        public Loterest()
        {
            InitializeComponent();
            var inicioSesión = new InicioSesión(this);
            ChangePage(inicioSesión);
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
        
        public void ChangePage(Window window)
        {
            Content = window.Content;
            ChangePageSize();
        }
        
        public void ChangePage(Page page)
        {
            Content = page;
            ChangePageSize();
        }
        
        public interface IPageManager
        {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="page"></param>
            [Obsolete("Método de prueba.")]
            void ChangePage(Window page);
            void ChangePage(Page page);
        }
    }
}
