using AlienCompadre_DAL.Connection;
using AlienCompadre_Entities;
using System.Data;
using System.Data.SqlClient;

namespace AlienCompadre_DAL.Handler {
    public class ClsHandlerDAL {

       /// <summary>
       /// Inserta las estadisticas de la partida en la base de datos.
       /// </summary>
       /// <param name="stats">Stadisticas de la partida</param>
       /// <returns> Numero de filas afectadas</returns>
        public int insertarStats_DAL(ClsStats stats) {
            int filas = 0;

            ClsMyConnection gestConexion = new ClsMyConnection();
            SqlConnection conexion = gestConexion.getConnection();
            SqlCommand miComando = new SqlCommand();

            //Definir los parametros del comando
            miComando.CommandText = "INSERT INTO stats(name, score) values (@nombre, @puntos)";

            //Añadimos los parametros
            if (stats.Name != "") {
                miComando.Parameters.Add("@nombre", SqlDbType.VarChar).Value = stats.Name;
            } else {
                miComando.Parameters.Add("@nombre", SqlDbType.Int).Value = "null";
            }
            
            miComando.Parameters.Add("@puntos", SqlDbType.VarChar).Value = stats.Score;

            miComando.Connection = conexion;
            filas = miComando.ExecuteNonQuery();
            //Cerramos la conexion
            gestConexion.closeConnection(ref conexion);

            return filas;
        }
    }
}
