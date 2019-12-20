using System.Windows;
using LIS_Juego_Loterest.Interface;

using DataModel;
using DataModel.Model;
using System.ServiceModel;
using ServerServices;

namespace LIS_Juego_Loterest.Páginas
{
    /// <summary>
    /// Lógica de interacción para Verificación.xaml
    /// </summary>
    public partial class Verificación : Window
    {
        private IPageManager _pageManager;
        private string codigoVerificacion;
        private UsuarioJugador cuentaCreada;

        public Verificación(string codigoVerificacionJugador, UsuarioJugador jugadorCreado)
        { 
            InitializeComponent();
            codigoVerificacion = codigoVerificacionJugador;
            cuentaCreada = jugadorCreado;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            _pageManager.CambiarPantalla<Menú>();
        }

        public void SetPageManager(IPageManager pageManager)
        {
            _pageManager = pageManager;
        }

        private void VerificarButton_Click(object sender, RoutedEventArgs e)
        {
            string codigoVerificacionIngresado = VerificacionTextBox.Text.Trim();

            if (ValidarCodigoIngresado(codigoVerificacion))
            {
                if (string.Equals(codigoVerificacionIngresado, codigoVerificacion))
                {
                    RegistrarJugador();
                }
                else
                {
                    MessageBox.Show(Application.Current.Resources["CodigoIncorrecto"].ToString());
                }

            }
            else
            {
                MessageBox.Show(Application.Current.Resources["DatosInvalidosVerificacion"].ToString());
            }
        }

        private bool ValidarCodigoIngresado(string codigoVerificacion)
        {
            bool codigoValido = false;

            if (codigoVerificacion != "")
            {
                codigoValido = true;
                return codigoValido;
            }
            else
            {
                return codigoValido;
            }
        }

        private void RegistrarJugador()
        {
            try
            {
                InstanceContext instanceContext = new InstanceContext(this);
                GameServices loginService = new GameServices(instanceContext);
                Jugador jugador = new Jugador()
                {
                    NombreJugador = cuentaCreada.NombreJugador,
                    CorreoElectronicoJugador = cuentaCreada.CorreoElectronicoJugador,
                    ContraseñaJugador = cuentaCreada.ContraseñaJugador,
                    puntajeJugador = 0
                };

                loginService.CrearCuenta(jugador);
                loginService.IniciarSesion(cuentaCreada.NombreJugador, cuentaCreada.ContraseñaJugador);
            } catch(EndpointNotFoundException)
            {
                MessageBox.Show(Application.Current.Resources["Operación inválida"].ToString());
            }
        }
    }
}
