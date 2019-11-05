using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace LIS_Juego_Loterest
{
    public class ConexionBaseDeDatos
    {
        //private String conexionBaseDeDatos = Properties.Settings.Default.ConexionBaseDeDatos;

        //public Jugador LoguearUsuario(String correoElectronico, String contrasenia)
        //{
        //    SqlConnection sqlConnection;
        //    SqlCommand sqlCommand;
        //    SqlDataReader sqlDataReader;

        //    sqlConnection = new SqlConnection(conexionBaseDeDatos);
        //    sqlCommand = new SqlCommand("SELECT * FROM Jugador WHERE correoElectronico= @p1 AND contrasenia = @p2", sqlConnection);
        //    sqlCommand.CommandType = CommandType.Text;
        //    sqlCommand.Parameters.AddWithValue("@p1", correoElectronico);
        //    sqlCommand.Parameters.AddWithValue("@p2", contrasenia);

        //    try
        //    {
        //        sqlConnection.Open();
        //        sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.SingleRow);

        //        if (sqlDataReader.Read())
        //        {
        //            Jugador jugador =
        //                new Jugador(
        //                    (int)sqlDataReader["id"],
        //                    (String)sqlDataReader["nombreJugador"],
        //                    (String)sqlDataReader["correoElectronico"],
        //                    (String)sqlDataReader["contrasenia"]
        //                );
        //            return jugador;
        //        }
        //        else
        //        {
        //            return null;
        //        }
        //    }
        //    finally
        //    {
        //        sqlConnection.Close();
        //    }

        //}

        //public Jugador RegistrarUsuario(String nombreJugador, String correoElectronico, String contrasenia)
        //{
        //    SqlConnection sqlConnection;

        //    sqlConnection = new SqlConnection(conexionBaseDeDatos);
        //    String query = "INSERT INTO Jugador (nombreJugador, correoElectronico, contrasenia) values " +
        //        "@nombreJugador, @correoElectronico, @contrasenia";

        //    sqlConnection.Open();
        //    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
        //    sqlCommand.Parameters.AddWithValue("@nombreJugador", nombreJugador);
        //    sqlCommand.Parameters.AddWithValue("@correoElectronico", correoElectronico);
        //    sqlCommand.Parameters.AddWithValue("@contrasenia", contrasenia);
        //    sqlCommand.ExecuteNonQuery();

        //    Jugador jugador = new Jugador(nombreJugador, correoElectronico, contrasenia);

        //    return jugador;
        }
    }

