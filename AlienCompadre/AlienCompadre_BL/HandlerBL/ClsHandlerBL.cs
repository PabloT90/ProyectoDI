using AlienCompadre_DAL.Handler;
using AlienCompadre_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienCompadre_BL.HandlerBL {
    public class ClsHandlerBL {

        /// <summary>
        /// Inserta las estadisticas de la partida en la base de datos.
        /// </summary>
        /// <param name="stats">Stadisticas de la partida</param>
        /// <returns> Numero de filas afectadas</returns>
        public int insertarStats_BL(ClsStats stats) {
            int filas;
            ClsHandlerDAL manejadora = new ClsHandlerDAL();

           filas = manejadora.insertarStats_DAL(stats);

            return filas;
        }
    }
}
