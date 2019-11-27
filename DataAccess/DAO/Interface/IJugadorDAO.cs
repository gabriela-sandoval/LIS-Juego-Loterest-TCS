using DataAccess.Exception;
using DataModel.Model;

namespace DataAccess.DAO.Interface
{
    public interface IJugadorDAO
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <exception cref="DAOException"></exception>
        /// <returns></returns>
        Jugador GetJugadorConCredenciales(string username, string password);
        int GetTotalJugadores();
    }
}