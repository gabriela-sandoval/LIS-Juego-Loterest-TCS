namespace ServerServices.Model.Enum
{
    public enum LoginRequestReplyCode
    {
        /// <summary>
        ///     Inicio de sesión exitoso.
        /// </summary>
        Success,

        /// <summary>
        ///     El nombre de usuario no existe.
        /// </summary>
        UsernameDoesNotExist,

        /// <summary>
        ///     La contraseña es incorrecta.
        /// </summary>
        PasswordIncorrect,

        /// <summary>
        ///     Se requiere código de verificación.
        /// </summary>
        VerificationCodeRequired,

        /// <summary>
        ///     El usuario tiene una sesión activa.
        /// </summary>
        AlreadyLoggedIn,

        /// <summary>
        ///     Error en la base de datos.
        /// </summary>
        DatabaseError,

        /// <summary>
        ///     Error general.
        /// </summary>
        GeneralError
    }
}