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

            if (y+1 <= 7)//Foco debajo del personaje
            {
                _mazmorra.Tablero.ElementAt(8 * (y+2) + (x)).LightImage = _mazmorra.Tablero.ElementAt(8 * (y+2) + (x)).DarkImage;
            }

            if (y-1 >= 0)//Foco arriba del personaje
            {
                _mazmorra.Tablero.ElementAt(8 * (y) + (x)).LightImage = _mazmorra.Tablero.ElementAt(8 * (y) + (x)).DarkImage;
            }

            if (x + 1 <= 7)//Foco derecha del personaje 
            {
                _mazmorra.Tablero.ElementAt(8 * (y + 1) + (x+1)).LightImage = _mazmorra.Tablero.ElementAt(8 * (y + 1) + (x+1)).DarkImage;
            }

            if (x - 1 >= 0)//Foco izquierda del personaje
            {
                _mazmorra.Tablero.ElementAt(8 * (y + 1) + (x-1)).LightImage = _mazmorra.Tablero.ElementAt(8 * (y + 1) + (x - 1)).DarkImage;
            }     
        }
        

        public void ChangeImageToDark() {
            for (int i = 0; i < _mazmorra.Tablero.Count; i++) {
                //TODO renombrar el nombre de las imagenes Dark.
                _mazmorra.Tablero.ElementAt(i).DarkImage = ""; //Cambiarla por la misma imagen pero oscurecida
            }
            
        }
        #endregion
    }
}
