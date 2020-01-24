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
         Comentario: Este método nos permite mostrar y ocultar las casillas adyacentes y verticales del jugador
         cuando este se mueva, cambiando al personaje de casilla.
         Cabecera: private void focoPersonaje(char movimiento)
         Entrada:
            -int movimiento
         Precondiciones:
            -movimiento debe ser igual a 'u'(up), 'b'(below), 'l'(left) o 'r'(right)
         Postcondiciones: El método modifica el estado del tablero.
         */
        private void focoPersonaje(char movimiento)
        {
            int x = _player.Position.X;
            int y = _player.Position.Y;

            switch (movimiento)
            {
                case 'u':
                    if(y > 0)//Si existen casillas superiores
                    {
                        _mazmorra.Tablero.ElementAt(8 * (y + 1) - x).Image = "//Assets/dark"+_mazmorra.Tablero.ElementAt(8 * (y + 1) - x).Image.Substring(5, 1)+".png";//Esto va a doler
                    }
                    break;
                case 'b':

                    break;
                case 'l':

                    break;
                case 'r':

                    break;
            }
        }

        #endregion
    }
}
