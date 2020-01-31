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
                //TODO conseguir quitar el .png de la URL de las fotos.
                _mazmorra.Tablero.ElementAt(i).DarkImage = ""; //Cambiarla por la misma imagen pero oscurecida
            }
            
        }
        #endregion

        #region Métodos Personaje
        /// <summary>
        /// Comentario: Este método intentará mover a un personaje por el tablero, si el movimiento
        /// es válido, el método modificará la posición del personaje y su foco en el mapa.
        /// </summary>
        /// <param name="movement"></param>
        public void tryMoveCharacter(char movement)
        {
            switch (movement)
            {
                case 'u'://Up
                    if (_player.Position.Y > 0)
                    {
                        _player.Position.Y = _player.Position.Y - 1;//Subimos al personaje
                        ChangeImageToDark();//Oscurecemos el tablero.
                        //Necesitamos mostrar al personaje por pantalla (A ver si lo hacemos con id o no)
                        focoPersonaje();
                    }
                    break;
                case 'd'://Down
                    if (_player.Position.Y < 7)
                    {
                        _player.Position.Y = _player.Position.Y + 1;//Bajamos al personaje
                        ChangeImageToDark();//Oscurecemos el tablero.
                        //Necesitamos mostrar al personaje por pantalla (A ver si lo hacemos con id o no)
                        focoPersonaje();
                    }
                    break;
                case 'r'://Right
                    if (_player.Position.X < 7)
                    {
                        _player.Position.X = _player.Position.X + 1;//Movemos el personaje a la Derecha (_player.Position.X++)
                        ChangeImageToDark();//Oscurecemos el tablero.
                        //Necesitamos mostrar al personaje por pantalla (A ver si lo hacemos con id o no)
                        focoPersonaje();
                    }
                    break;
                case 'l'://Left
                    if (_player.Position.X > 0)
                    {
                        _player.Position.X = _player.Position.X - 1;//Movemos el personaje a la izquierda (_player.Position.X--)
                        ChangeImageToDark();//Oscurecemos el tablero.
                        //Necesitamos mostrar al personaje por pantalla (A ver si lo hacemos con id o no)
                        focoPersonaje();
                    }
                    break;
            }
        }
        #endregion
    }
}
