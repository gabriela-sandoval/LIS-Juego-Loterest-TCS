using System.ServiceModel;

namespace ServerServices.Interface
{
    /// <summary>
    ///     Contrato para el servicio Login
    /// </summary>
    [ServiceContract(CallbackContract = typeof(ILoginServiceCallback))]
    public interface ILoginService
    {
        /// <summary>
        ///     Realiza una solicitud de inicio de sesión en el servidor, donde el cliente proporciona su nombre de
        ///     usuario y su contraseña.
        /// </summary>
        /// <param name="username">Nombre de suario del cliente</param>
        /// <param name="password">Contraseña del cliente</param>
        [OperationContract(IsOneWay = true)]
        void LoginRequest(string username, string password);

        /// <summary>
        ///     Realiza una solicitud de registro de usuario, donde el cliente proporciona su nombre de usuario, una
        ///     contraseña y su correo electrónico.
        /// </summary>
        /// <param name="username">Nombre de usuario del cliente</param>
        /// <param name="password">Contraseña del cliente</param>
        /// <param name="email">Correo electrónico del cliente</param>
        [OperationContract(IsOneWay = true)]
        void RegisterRequest(string username, string password, string email);

        /// <summary>
        ///     Realiza una solicitud de verificación de cuenta, donde el cliente proporciona su nombre de usuario y
        ///     el código de verificación que se le envío por correo electrónico.
        /// </summary>
        /// <param name="username">Nombre de usuario del cliente</param>
        /// <param name="code">Código de verificación</param>
        [OperationContract(IsOneWay = true)]
        void VerificationRequest(string username, string code);

        /// <summary>
        ///     Realiza una solicitud de reestablecimiento de contraseña, donde el cliente proporciona su nombre de
        ///     usuario o correo electrónico.
        /// </summary>
        /// <param name="usernameOrEmail">Nombre de usuario o correo electrónico del cliente</param>
        [OperationContract(IsOneWay = true)]
        void ResetPasswordRequest(string usernameOrEmail);

        /// <summary>
        ///     Solicita el cierre de sesión de un cliente en el servidor.
        /// </summary>
        /// <param name="sessionId">Id de la sesión del cliente</param>
        [OperationContract]
        void Logout(string sessionId);
    }
}