using System.ServiceModel;

namespace ServerServices.Util
{
    /// <summary>
    ///     Clase envoltoria para OperationContext que contiene una única referencia al canal de callback del tipo de
    ///     servicio especificado.
    /// </summary>
    /// <typeparam name="TCallback">Tipo de callback de servicio</typeparam>
    public class OperationContextWrapper<TCallback>
    {
        /// <summary>
        ///     Contexto de operación de WCF.
        /// </summary>
        private readonly OperationContext _operationContext;

        /// <summary>
        ///     Canal de callback del servicio.
        /// </summary>
        private TCallback _callback;

        public OperationContextWrapper(OperationContext operationContext)
        {
            _operationContext = operationContext;
        }

        /// <summary>
        ///     Devuelve el canal de callback del servicio. Lo inicializa si es necesario.
        /// </summary>
        /// <returns>Canal de callback del servicio</returns>
        public TCallback GetCallback()
        {
            if (_callback == null) _callback = _operationContext.GetCallbackChannel<TCallback>();

            return _callback;
        }
    }
}