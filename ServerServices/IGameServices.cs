using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using DataModel;
using ServerServices.ServerServices;

namespace ServerServices
{
    /// <summary>
    /// Interfaz IGameServices se encarga de especificar los métodos que un jugador puede realizar
    /// en el servidor.
    /// </summary>
    [ServiceContract(CallbackContract = typeof(IGameServiceCallback))]
    public interface IGameServices
    {
        [OperationContract(IsOneWay = true)]
        void CrearCuenta(Jugador jugador);

        [OperationContract(IsOneWay = true)]
        void IniciarSesion(string nombreJugador, string contraseñaJugador);

        [OperationContract(IsOneWay = true)]
        void CerrarSesion(string nombreJugador);

        [OperationContract(IsOneWay = true)]
        void EnviarMensajeChat(string nombreJugador, string mensajeJugador, string nombreRemitente);

        [OperationContract(IsOneWay = true)]
        void RegistrarPuntajeMaximo(string nombreJugador, int puntajeMaximo);

        [OperationContract(IsOneWay = true)]
        void SolicitarPuntajes();

        [OperationContract(IsOneWay = true)]
        void FinalizarPartida(string nombreJugador, string nombreRemitente);
    }

    /// <summary>
    /// Interfaz IGameServiceCallback se encarga de especificar los métodos que un jugador puede realizar
    /// en el servidor.
    /// </summary>
    [ServiceContract]
    public interface IGameServiceCallback
    {
        [OperationContract(IsOneWay = true)]
        void MensajeChat(string mensajeJugador);

        [OperationContract(IsOneWay = true)]
        void Respuesta(string mensajeJugador);

        [OperationContract(IsOneWay = true)]
        void MostrarCuentaJugador(Jugador jugador);

        [OperationContract(IsOneWay = true)]
        void MostrarPuntajeJugador(List<PuntajeJugador> puntajes);

        [OperationContract(IsOneWay = true)]
        void RecibirFinPartida(string mensajeJugador);
    }

    namespace ServerServices
    {
        [DataContract]
        public class PuntajeJugador
        {
            [DataMember]
            private string nombreJugador;

            [DataMember]
            private long? puntajeJugador;

            public PuntajeJugador(string nombreJugador, long? puntajeJugador)
            {
                this.nombreJugador = nombreJugador;
                this.puntajeJugador = puntajeJugador;
            }
        }
    }
}