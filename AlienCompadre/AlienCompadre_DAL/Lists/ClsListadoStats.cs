using AlienCompadre_DAL.Connection;
using AlienCompadre_Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienCompadre_DAL.Lists{
    public class ClsListadoStats{
        /// <summary>
        /// Obtiene un listado de un tamaño concreto de las estadisticas de los jugadores
        /// </summary>
        /// <param name="numJugadores">Numero de jugadores que componen la lista</param>
        /// <returns>Listado de estadisticas</returns>
        public List<ClsStats> listadoStats(int numJugadores){
            List<ClsStats> listado = new List<ClsStats>();
            ClsMyConnection connection = new ClsMyConnection();
            SqlConnection conn = connection.getConnection();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector = null;
            ClsStats oStats;

            try{
                miComando.CommandText = "SELECT TOP " + numJugadores +" * FROM stats ORDER BY score DESC";
                miComando.Connection = conn;
                miLector = miComando.ExecuteReader();
                //Si hay lineas en el lector
                if (miLector.HasRows){
                    while (miLector.Read()){
                        oStats = new ClsStats();
                        oStats.Name = (miLector["name"] is DBNull) ? "Anonimo" : (string)miLector["name"];
                        oStats.Score = (int)miLector["score"];
                        listado.Add(oStats);
                    }
                }
            }catch (Exception exSql){
                throw exSql;
            }finally{
                if (miLector != null){
                    miLector.Close();
                }

                if (conn != null){
                    connection.closeConnection(ref conn);
                }
            }

            return listado;
        }
    }
}
