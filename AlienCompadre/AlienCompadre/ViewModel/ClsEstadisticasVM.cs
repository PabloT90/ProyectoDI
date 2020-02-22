using AlienCompadre_BL.Lists;
using AlienCompadre_Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AlienCompadre.ViewModel {
    public class ClsEstadisticasVM : INotifyPropertyChanged {

        #region Propiedades privadas
        private List<ClsStats> listaEstadisticas; //Para la lista de jugadores
        private int numeroJugadores; //Para el filtrado de la lista
        #endregion

        #region constructor por defecto
        public ClsEstadisticasVM() {
            //Recibimos la lista de estadisticas
            numeroJugadores = 100;
            obtenerListaJugadores();
        }
        #endregion

        #region Propiedades publicas
        public List<ClsStats> Estadisticas {
            get {
                return listaEstadisticas;
            }
            set {
                listaEstadisticas = value;
                NotifyPropertyChanged("Estadisticas");
            }
        }

        public int NumeroJugadores {
            get {
                return numeroJugadores;
            }
            set {
                if (numeroJugadores != value) { //Asi evitamos que se recargue la lista cuando se pulsa sobre el mismo valor.
                    numeroJugadores = value;
                    obtenerListaJugadores();
                    NotifyPropertyChanged("NumeroJugadores");
                }
            }
        }
        #endregion

        #region Metodos añadidos
        /// <summary>
        /// Obtiene una lista de jugadores.
        /// </summary>
        private void obtenerListaJugadores() {
            try {
                ClsListadosStatsBL listados = new ClsListadosStatsBL();
                Estadisticas = listados.listadoStats(numeroJugadores);
            } catch (Exception e) {
                throw e;
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
