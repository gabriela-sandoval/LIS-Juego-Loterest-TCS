using System;
using System.Collections.Generic;
using System.ServiceModel;
using DataModel;
using System.Linq;
using System.Threading;

namespace ServerServices
{
    /// <summary>
    /// La clase GameServices se encarga de realizar las operaciones 
    /// de los metodos implementados por la interfaz.
    /// </summary>
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single, InstanceContextMode = InstanceContextMode.Single)]

    public class GameServices : IGameServices
    {
        readonly Dictionary<IGameServiceCallback, string> jugadoresConectados = new Dictionary<IGameServiceCallback, string>();
        private IGameServiceCallback gameChannel;
        private readonly InstanceContext instanceContext;

        /// <summary>
        /// Constructor que se encarga de llamar al cliente.
        /// </summary>
        public GameServices()
        {

        }

        /// <summary>
        /// Operación de interfaz IGameServices.
        /// </summary>
        /// <param name="gameServiceCreator"></param>
        public GameServices(IGameServiceCallback gameServiceCallbackCreator)
        {
            this.gameChannel = gameServiceCallbackCreator ?? throw new ArgumentNullException("gameServiceCallbackCreator");

        }

        public GameServices(InstanceContext instanceContext)
        {
            this.instanceContext = instanceContext;
        }

        /// <summary>
        /// Agrega un Jugador a la base de datos
        /// </summary>
        /// <return>
        /// Objeto de tipo Jugador para operaciones.
        /// </return>
        /// <exception cref="System.InvalidOperationException">
        /// Se lanza cuando un parámetro es máximo y el otro es mayor que cero.
        /// </exception>
        /// <param name="jugador">
        /// Objeto de tipo jugador
        /// </param>
        public void CrearCuenta(Jugador jugador)
        {
            try
            {
                Console.WriteLine("LoterestEntities");
                LoterestEntities loterestEntities = new LoterestEntities();
                LoterestEntities baseDatos = loterestEntities;
                Console.WriteLine("LoterestEntities2");
                Jugador cuentaJugador = (from per in baseDatos.Jugador where per.NombreJugador == jugador.NombreJugador select per).First();
                Console.WriteLine("Consulta - Creación de cuenta");

                if (cuentaJugador != null)
                {
                    OperationContext.Current.GetCallbackChannel<IGameServiceCallback>().Respuesta("El nombre de usuario se encuentra registrado");
                }
            }
            catch (InvalidOperationException)
            {
                LoterestEntities baseDatos = new LoterestEntities();
                baseDatos.Jugador.Add(jugador);
                baseDatos.SaveChanges();
                Console.WriteLine("Se ha registrado un nuevo jugador: " + jugador.NombreJugador);
                baseDatos.Dispose();
            }
        }

        /// <summary>
        /// Requiere dos valores para poder ingresar al sistema.
        /// </summary>
        /// <returns>
        /// Objeto tipo jugador.
        /// </returns>
        /// <exception cref="System.InvalidOperationException">
        /// Se lanza cuando un parámetro es máximo y el otro es mayor que cero.
        /// </exception>
        /// <param name="NombreJugador">
        /// Nombre del jugador de tipo String.
        /// </param>
        /// <param name="ContraseñaJugador">
        /// Contraseña del jugador de tipo String.
        /// </param>
        public void IniciarSesion(string nombreJugador, string contraseñaJugador)
        {
            try
            {
                LoterestEntities baseDatos = new LoterestEntities();
                var cuentaJugador = (from per in baseDatos.Jugador where per.NombreJugador == nombreJugador && per.ContraseñaJugador == contraseñaJugador select per).First();
                OperationContext.Current.GetCallbackChannel<IGameServiceCallback>().MostrarCuentaJugador(cuentaJugador);
                var conexion = OperationContext.Current.GetCallbackChannel<IGameServiceCallback>();
                jugadoresConectados[conexion] = nombreJugador;

                Console.WriteLine(cuentaJugador.NombreJugador + ": ha iniciado sesión");
                Console.WriteLine("Puntaje: " + cuentaJugador.puntajeJugador);
                baseDatos.Dispose();
            }
            catch (InvalidOperationException)
            {
                OperationContext.Current.GetCallbackChannel<IGameServiceCallback>().Respuesta("El nombre de usuario o contraseña son incorrectos, intente nuevamente");
            }
        }

        /// <summary>
        /// Permite cerrar sesión, requiere de un nombre de jugador para hacerlo.
        /// </summary>
        /// <param name="nombreJugador">
        /// Recibe el nombre del jugador al cerrar la sesión
        /// </param>
        public void CerrarSesion(string nombreJugador)
        {
            var conexion = OperationContext.Current.GetCallbackChannel<IGameServiceCallback>();
            jugadoresConectados[conexion] = nombreJugador;
            Console.WriteLine(nombreJugador + ": se ha desconectado");
        }

        /// <summary>
        /// Retorna un mensaje de tipo string
        /// </summary>
        /// <param name="nombreJugador">
        /// Nombre del jugador
        /// </param>
        /// <param name="mensajeJugador">
        /// Mensaje que envía el jugador
        /// </param>
        /// <param name="nombreRemitente">
        /// Nombre de la persona a enviar el mensaje
        /// </param>
        public void EnviarMensajeChat(string nombreJugador, string mensajeJugador, string nombreRemitente)
        {
            string mensajeChat = nombreJugador + ": " + mensajeJugador;
            Thread.Sleep(50);
            var conexion = OperationContext.Current.GetCallbackChannel<IGameServiceCallback>();
            foreach (var destinatario in jugadoresConectados)
            {
                if (destinatario.Value.Equals(nombreJugador))
                {
                    if (destinatario.Key == conexion)
                    {
                        continue;
                    }
                    else
                    {
                        destinatario.Key.MensajeChat(mensajeChat);
                    }
                }
            }
        }

        /// <summary>
        /// Registro de puntaje que requiere el nombre del jugador y el puntaje.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">
        /// Se lanza cuando un parámetro es máximo y el otro es mayor que cero.
        /// </exception>
        /// <param name="nombreJugador"></param>
        /// <param name="puntajeJugador"></param>
        public void RegistrarPuntajeMaximo(string nombreJugador, int puntajeJugador)
        {
        //    try
        //    {
        //        LoterestEntities baseDatos = new LoterestEntities();
        //        var cuentaJugador = (from per in baseDatos.Jugador where per.NombreJugador == nombreJugador select per).First();
        //        switch (cuentaJugador.puntajeJugador)
        //        {
        //            case null:
        //                cuentaJugador.puntajeJugador = puntajeJugador;
        //                baseDatos.SaveChanges();
        //                Console.WriteLine("Se ha registrado un nuevo puntaje al jugador: " + nombreJugador);
        //                break;
        //            default:
        //                if (cuentaJugador.puntajeJugador < puntajeJugador)
        //                {
        //                    cuentaJugador.puntajeJugador = puntajeJugador;
        //                    baseDatos.SaveChanges();
        //                    Console.WriteLine("Se ha registrado un nuevo puntaje a: " + nombreJugador);
        //                }
        //                else
        //                {
        //                    Console.WriteLine("El puntaje anterior era más alto que el actual");
        //                }

        //                break;
        //        }
        //        baseDatos.Dispose();
        //    }
        //    catch (InvalidOperationException)
        //    {
        //        OperationContext.Current.GetCallbackChannel<IGameServiceCallback>().Respuesta("Ocurrió un error al intentar registrar el puntaje");
        //    }
        }

        /// <summary>
        /// Muestra una lista de puntajes.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">
        /// Se lanza cuando un parámetro es máximo y el otro es mayor que cero.
        /// </exception>
        public void SolicitarPuntajes()
        {
            //try
            //{
            //    List<PuntajeJugador> puntajes = new List<PuntajeJugador>();
            //    using (var cuentaJugador = new LoterestEntities())
            //    {
            //        var cuentasJugadores = from jugador in cuentaJugador.Jugador
            //                               orderby jugador.puntajeJugador descending
            //                               select jugador;
            //        foreach (var valor in cuentasJugadores)
            //        {
            //            if (valor.puntajeJugador == null)
            //            {
            //                continue;
            //            }
            //            puntajes.Add(new PuntajeJugador(valor.NombreJugador, valor.puntajeJugador));
            //            Console.WriteLine(valor.NombreJugador + "=" + valor.puntajeJugador);
            //        }
            //    }
            //    OperationContext.Current.GetCallbackChannel<IGameServiceCallback>().MostrarPuntajeJugador(puntajes);
            //}
            //catch (InvalidOperationException)
            //{
            //    OperationContext.Current.GetCallbackChannel<IGameServiceCallback>().Respuesta("Ocurrió un error al intentar mostrar el puntaje, intentelo más tarde");
            //}
        }

        /// <summary>
        /// Finaliza la partida.
        /// </summary>
        /// <param name="nombreJugador">
        /// Nombre del jugador
        /// </param>
        /// <param name="nombreRemitente">
        /// Nombre del jugador que recibe
        /// </param>
        public void FinalizarPartida(string nombreJugador, string nombreRemitente)
        {
            var conexion = OperationContext.Current.GetCallbackChannel<IGameServiceCallback>();
            foreach (var jugadorPerdedor in jugadoresConectados)
            {
                if (jugadorPerdedor.Value.Equals(nombreRemitente))
                {
                    if (jugadorPerdedor.Key == conexion)
                    {
                        continue;
                    }
                    else
                    {
                        jugadorPerdedor.Key.RecibirFinPartida("El jugador: " + nombreJugador + "ha ganado la partida");
                    }
                }
            }

        }
    }
}