using System.ServiceModel;

namespace LIS_Juego_Loterest.Util
{
    /// <summary>
    ///     Clase de utilería que ayuda con la creación de canales hacia el servidor.
    /// </summary>
    public static class ClientFactory
    {
        
        /// <summary>
        ///     Crea un canal dúplex para el servicio e implementación de callback proporcionados.
        /// </summary>
        /// <param name="callbackImplementation">Implementación del callback</param>
        /// <typeparam name="TService">Tipo de servicio</typeparam>
        /// <typeparam name="TCallback">Tipo de callback de servicio</typeparam>
        /// <returns>Canal dúplex hacia el servidor</returns>
        public static TService CreateDuplexChannel<TService, TCallback>(TCallback callbackImplementation)
        {
            var instanceContext = new InstanceContext(callbackImplementation);
            var channelFactory = new DuplexChannelFactory<TService>(instanceContext, "*");
            return channelFactory.CreateChannel();
        }
        
    }
}