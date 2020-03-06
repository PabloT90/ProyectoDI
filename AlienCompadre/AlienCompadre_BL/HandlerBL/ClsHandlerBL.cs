using AlienCompadre_DAL.Handler;
using AlienCompadre_Entities;
using System;

namespace AlienCompadre_BL.HandlerBL {
    public class ClsHandlerBL {

        /// <summary>
        /// Inserta las estadisticas de la partida en la base de datos.
        /// </summary>
        /// <param name="stats">Estadisticas de la partida</param>
        /// <returns> Numero de filas afectadas</returns>
        public int insertarStats_BL(ClsStats stats) {
            int filas = 0;
            ClsHandlerDAL manejadora = new ClsHandlerDAL();

            try {
                filas = manejadora.insertarStats_DAL(stats);
            } catch (Exception e) {

            }
            
            return filas;
        }
    }
}
