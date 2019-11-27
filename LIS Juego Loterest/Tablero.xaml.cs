using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using AccessData;

namespace LIS_Juego_Loterest
{
    /// <summary>
    /// Lógica de interacción para Tablero.xaml
    /// </summary>
    public partial class Tablero : Window
    {
        public Tablero()
        {
            InitializeComponent();
            Refresh();
        }

        private void ButtonSeleccionarTablero_Click(object sender, RoutedEventArgs e)
        {
            Loteria loteria = new Loteria();
            loteria.Show();
        }

        private void ButtonRegresar_Click(object sender, RoutedEventArgs e)
        {
            Menú menu = new Menú();
            menu.Show();
        }

        public void Refresh()
        {
            List<AccessData.ViewModel.CartaViewModel> listaCartas = new List<AccessData.ViewModel.CartaViewModel>();
            using (JuegoLoterestEntities baseDeDatos = new JuegoLoterestEntities())
            {
                listaCartas = (from d in baseDeDatos.Carta
                               select new AccessData.ViewModel.CartaViewModel
                               {
                                   IdCarta = d.idCarta,
                                   NombreCarta = d.nombreCarta,
                                   ImagenCarta = d.imagenCarta
                               }).ToList();
            }
            DataGridTablero.ItemsSource = listaCartas;
        }
        
    }
}
