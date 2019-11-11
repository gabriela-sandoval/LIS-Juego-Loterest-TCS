namespace ServerServices.Model.Enum
{
    public enum RegisterRequestReplyCode
    {
        /// <summary>
        ///     Código de verificación requerido.
        /// </summary>
        VerificationCodeRequired,

        /// <summary>
        ///     Nombre de usuario ya ha sido registrado anteriormente.
        /// </summary>
        UsernameAlreadyUsed,

        /// <summary>
        ///     Correo electrónico ya ha sido registrado anteriormente.
        /// </summary>
        EmailAlreadyUsed,

        /// <summary>
        ///     La contraseña es de muy baja seguridad.
        /// </summary>
        PasswordLowSecurity,

        /// <summary>
        ///     Error en la base de datos.
        /// </summary>
        DatabaseError,

        /// <summary>
        ///     Error general.
        /// </summary>
        GeneralError,

        /// <summary>
        ///     Error en la validación de campos.
        /// </summary>
        ValidationError
    }
}