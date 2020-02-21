using AlienCompadre_BL.HandlerBL;
using AlienCompadre_Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AlienCompadre.ViewModel {
    public class ClsPantallaFinalVM : INotifyPropertyChanged {
        #region Propiedades privadas
        private ClsStats estadisticas;
        #endregion

        #region constructor por defecto
        public ClsPantallaFinalVM() {
            estadisticas = new ClsStats();
        }
        #endregion

        #region Propiedades publicas
        public ClsStats Estadisticas {
            get {
                return estadisticas;
            }
            set {
                estadisticas = value;
                NotifyPropertyChanged("Estadisticas");
            }
        }
        #endregion

        #region Metodos añadidos
        /// <summary>
        /// Sube los datos de la partida al servidor.
        /// </summary>
        /// <returns></returns>
        public int subirDatosPartida() {
            int filas = 0;

            ClsHandlerBL handler = new ClsHandlerBL();
            try {
                filas = handler.insertarStats_BL(Estadisticas);
            } catch (Exception e) {

            }
            
            return filas;
        }
        #endregion

        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "") {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
