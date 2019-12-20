using System;
using System.ServiceModel;
using System.Windows;
using DataModel.Model;

using ServerServices;
using VerificacionCorreo;

namespace LIS_Juego_Loterest.Páginas
{
    /// <summary>
    /// Lógica de interacción para InicioSesión.xaml
    /// </summary>

    [CallbackBehavior(UseSynchronizationContext = false)]
    public partial class InicioSesión : Window
    {
        //private PuntajeJugador jugador;

        public InicioSesión()
        {
            InitializeComponent();
        }

        private void IniciarSesionButton_Click(object sender, RoutedEventArgs e)
        {
            string NombreJugador = NombreTextBoxIniciarSesion.Text.Trim();
            string ContraseñaJugador = ContaseñaTextBoxIniciarSesion.Password.Trim();

                try
            {
                InstanceContext instanceContext = new InstanceContext(this);
                GameServices loginService = new GameServices(instanceContext);

                if(ValidarDatosIngresadosInicioDeSesion(NombreJugador, ContraseñaJugador))
                {
                    loginService.IniciarSesion(NombreJugador, ContraseñaJugador);
                }
                else
                {
                    MessageBox.Show(Application.Current.Resources["Datos inválidos, intente nuevamente"].ToString());
                }

            }
            catch (EndpointNotFoundException)
            {
                MessageBox.Show(Application.Current.Resources["OperacionInvalida"].ToString());
            }
        }

        private bool ValidarDatosIngresadosInicioDeSesion(string nombreJugador, string contraseñaJugador)
        {
            bool datosValidos = false;

            if (nombreJugador != "" && contraseñaJugador != "")
            {
                datosValidos = true;
                return datosValidos;
            }
            else
            {
                return datosValidos;
            }
        }


        private void SiguienteButton_Click(object sender, RoutedEventArgs e)
        {
            EnvioDeCorreo correo = new EnvioDeCorreo();
            string codigoVerificacion = GenerarCodigoVerificacion().ToString();
            string nombreJugador = NombreTextBoxCrearCuenta.Text.Trim();
            string correoJugador = CorreoTextBoxCrearCuenta.Text.Trim();
            string contraseñaJugador = ContraseñaBoxCrearCuenta.Password.Trim();
            string repetirContraseñaJugador = RepetirContraseñaBoxCrearCuenta.Password.Trim();

            if (contraseñaJugador == repetirContraseñaJugador)
            {
                if (ValidarDatosIngresadosRegistro(nombreJugador, correoJugador, contraseñaJugador))
                {
                    if (ValidarCorreo(correoJugador))
                    {
                        if (correo.EnviarCorreo(correoJugador, codigoVerificacion))
                        {
                            UsuarioJugador usuarioJugador = new UsuarioJugador()
                            {
                                NombreJugador = nombreJugador,
                                CorreoElectronicoJugador = correoJugador,
                                ContraseñaJugador = contraseñaJugador
                            };

                            Verificación verificación = new Verificación(codigoVerificacion, usuarioJugador);
                            DesplegarVentana(verificación);
                        }
                        else
                        {
                            MessageBox.Show(Application.Current.Resources["Error envio de correo"].ToString());
                        }
                    }
                    else
                    {
                        MessageBox.Show(Application.Current.Resources["Correo invalido"].ToString());
                    }
                }
                else
                {
                    MessageBox.Show(Application.Current.Resources["Datos invalidos"].ToString());
                }
            }
            else
            {
                MessageBox.Show(Application.Current.Resources["Las contraseñas no coinciden"].ToString());
            }
        }

        private void DesplegarVentana(Window ventana)
        {
            ventana.Show();
        }

        private int GenerarCodigoVerificacion()
        {
            int codigoDeVerificacion;
            Random numeroAleatorio = new Random();
            codigoDeVerificacion = numeroAleatorio.Next(100000, 999999);
            return codigoDeVerificacion;
        }

        private bool ValidarDatosIngresadosRegistro(string nombreJugador, string correoJugador, string contraseñaJugador)
        {
            bool datosValidos = false;

            if ((nombreJugador != "") && (correoJugador != "") && (contraseñaJugador != ""))
            {
                datosValidos = true;
                return datosValidos;
            }
            else
            {
                return datosValidos;
            }
        }

        private bool ValidarCorreo(String correoJugador)
        {
            bool datosValidos = false;

            if ((correoJugador.Contains("@gmail.com")) || 
                (correoJugador.Contains("@hotmail.com")) || 
                (correoJugador.Contains("@outlook.com")))
            {
                datosValidos = true;
                return datosValidos;
            }
            else
            {
                return datosValidos;
            }
        }

        private void LoginControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void RegistrarJugador_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
