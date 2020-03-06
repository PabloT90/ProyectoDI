using AlienCompadre_BL.HandlerBL;
using AlienCompadre_Entities;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AlienCompadre.ViewModel {
    public class ClsPantallaFinalVM : INotifyPropertyChanged {
        #region Propiedades privadas
        private ClsStats estadisticas;
        private String mensaje;
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

        public String Mensaje {
            get {
                return mensaje;
            }set {
                mensaje = value;
                NotifyPropertyChanged("Mensaje");
            }
        }
        #endregion

        #region Metodos añadidos
        /// <summary>
        /// Sube los datos de la partida al servidor.
        /// </summary>
        /// <returns></returns>
        public int subirDatosPartida() {
            int filas;

            ClsHandlerBL handler = new ClsHandlerBL();
            try {
                filas = handler.insertarStats_BL(Estadisticas);
            } catch (Exception e) {
                throw e;
            }

            notificarSubida(filas);
            
            return filas;
        }

        /// <summary>
        /// Notifica si se ha podido insertar o no las estadisticas
        /// </summary>
        private void notificarSubida(int filasAfectadas) {
            if (filasAfectadas == 1) {
                Mensaje = "Datos almacenados con exito.";
            } else {
                Mensaje = "No se han podido almacenar los datos.";
            }
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
