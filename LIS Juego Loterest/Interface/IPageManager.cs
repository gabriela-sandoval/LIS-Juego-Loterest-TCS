using System.Windows.Controls;

namespace LIS_Juego_Loterest.Interface
{
    /// <summary>
    ///     Interfaz que proporciona la habilidad de cambiar de pantalla en una ventana.
    /// </summary>
    public interface IPageManager
    {
        /// <summary>
        ///     Realiza un cambio de página en la ventana que implemente esta interfaz. Acomoda el tamaño de la ventana
        ///     al tamaño de la página y regresa una referencia a la instancia recién creada.
        /// </summary>
        /// <typeparam name="T">Tipo de página, que implemente IPageListener</typeparam>
        /// <returns>La instancia de la página</returns>
        T CambiarPantalla<T>() where T : Page, IPageListener, new();
    }
}