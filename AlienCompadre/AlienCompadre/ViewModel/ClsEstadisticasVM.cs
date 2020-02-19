using AlienCompadre_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienCompadre.ViewModel {
    public class ClsEstadisticasVM {

        #region Propiedades privadas
        private List<ClsStats> listaEstadisticas;
        #endregion

        #region constructor por defecto
        public ClsEstadisticasVM() {
            listaEstadisticas = new List<ClsStats>();
        }
        #endregion

        #region Propiedades publicas
        public List<ClsStats> Estadisticas {
            get {
                return listaEstadisticas;
            }
            set {
                listaEstadisticas = value;
            }
        }
        #endregion
    }
}
