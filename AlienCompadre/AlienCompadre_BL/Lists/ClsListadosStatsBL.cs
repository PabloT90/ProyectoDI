using AlienCompadre_DAL.Lists;
using AlienCompadre_Entities;
using System.Collections.Generic;

namespace AlienCompadre_BL.Lists
{
    public class ClsListadosStatsBL
    {
        /// <summary>
        /// Obtiene un listado de un tamaño concreto de las estadisticas de los jugadores
        /// </summary>
        /// <param name="numJugadores">Numero de jugadores que componen la lista</param>
        /// <returns>Listado de estadisticas</returns>
        public List<ClsStats> listadoStats(int numJugadores)
        {
            ClsListadoStats list = new ClsListadoStats();
            return list.listadoStats(numJugadores);
        }
    }
}
