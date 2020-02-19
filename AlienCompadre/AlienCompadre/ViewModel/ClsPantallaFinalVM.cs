using AlienCompadre_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienCompadre.ViewModel {
    public class ClsPantallaFinalVM {
        #region Propiedades privadas
        private ClsStats estadisticas;
        #endregion

        #region constructor por defecto
        public ClsPantallaFinalVM() {
            estadisticas = new ClsStats();
        }
        #endregion

        #region Propiedades publicas
        public ClsStats Estadicticas {
            get {
                return estadisticas;
            }
            set {
                estadisticas = value;
            }
        }
        #endregion
    }
}
