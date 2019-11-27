using System;
using System.Linq;
using DataAccess.DAO.Interface;
using DataAccess.Exception;
using DataModel;
using DataModel.Model;

namespace DataAccess.DAO
{
    public class JugadorDAO : IJugadorDAO
    {
        public Jugador GetJugadorConCredenciales(string username, string password)
        {
            using (var db = new DatabaseContext())
            {
                var jugador = db.Jugador.FirstOrDefault(j => j.Nombre == username && j.Contraseña == password);
                if (jugador != null) return jugador;

                throw new DAOException($"El usuario '{username}' no existe en nuestra base de datos");
            }
        }

        public int GetTotalJugadores()
        {
            using (var db = new DatabaseContext())
            {
                return db.Jugador.Count();
            }
        }
    }
}