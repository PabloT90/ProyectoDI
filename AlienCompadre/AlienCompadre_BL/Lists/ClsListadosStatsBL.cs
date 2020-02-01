using AlienCompadre_DAL.Lists;
using AlienCompadre_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienCompadre_BL.Lists
{
    public class ClsListadosStatsBL
    {
        /// <summary>
        /// Es el intermedario entre la UI y la capa DAL
        /// </summary>
        /// <returns>El listado de Stats</returns>
        public List<ClsStats> listadoStats()
        {
            ClsListadoStats list = new ClsListadoStats();
            return list.listadoStats();
        }
    }
}
