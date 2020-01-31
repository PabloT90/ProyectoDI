using AlienCompadre.Models;
using AlienCompadre_Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AlienCompadre.ViewModel
{
    public class ClsMainPageVM : INotifyPropertyChanged
    {
        private ClsTablero _mazmorra;
        private ClsPlayer _player;
        private int _completedDungeons;

        #region Constructores
        public ClsMainPageVM()
        {
            _mazmorra = new ClsTablero();
            _player = new ClsPlayer();
        }
        #endregion

        #region Propiedades Públicas
        public ClsTablero Mazmorra
        {
            get
            {
                return _mazmorra;
            }
            set
            {
                _mazmorra = value;
                NotifyPropertyChanged("Mazmorra");
            }
        }

        public ClsPlayer Player
        {
            get
            {
                return _player;
            }
            set
            {
                _player = value;
                NotifyPropertyChanged("Player");
            }
        }

        public int CompletedDungeons
        {
            get
            {
                return _completedDungeons;
            }
            set
            {
                _completedDungeons = value;
                NotifyPropertyChanged("CompletedDungeons");
            }
        }
        #endregion

        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region Métodos Mazmorra
        /*
         Interfaz
         Nombre: focoPersonaje
         Comentario: Este método nos permite mostrar y ocultar las casillas adyacentes del jugador
         cuando este se mueva.
         Cabecera: private void focoPersonaje()
         Entrada:
            -int movimiento
         Postcondiciones: El método modifica el estado del tablero.
         */
        private void focoPersonaje()
        {
            int x = _player.Position.X;
            int y = _player.Position.Y;

            if (y+1 <= 7)
            {
                _mazmorra.Tablero.ElementAt(8 * (y+2) + (x)).ShownImage = _mazmorra.Tablero.ElementAt(8 * (y+2) + (x)).HideImage;
            }

            if (y-1 >= 0)
            {
                _mazmorra.Tablero.ElementAt(8 * (y) + (x)).ShownImage = _mazmorra.Tablero.ElementAt(8 * (y) + (x)).HideImage;
            }

            if (x + 1 <= 7)
            {
                _mazmorra.Tablero.ElementAt(8 * (y + 1) + (x+1)).ShownImage = _mazmorra.Tablero.ElementAt(8 * (y + 1) + (x+1)).HideImage;
            }

            if (x - 1 >= 0)
            {
                _mazmorra.Tablero.ElementAt(8 * (y + 1) + (x-1)).ShownImage = _mazmorra.Tablero.ElementAt(8 * (y + 1) + (x - 1)).HideImage;
            }     
        }

        #endregion
    }
}
