using AlienCompadre.Models;
using AlienCompadre_BL.Lists;
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
        private ClsAlien _alien;
        private int _completedDungeons;
        private List<ClsStats> _stats;
        private ClsListadosStatsBL list = new ClsListadosStatsBL();

        #region Constructores
        public ClsMainPageVM()
        {
            _mazmorra = new ClsTablero();
            _player = new ClsPlayer();
            _alien = new ClsAlien();
            _stats = new List<ClsStats>();
            _stats = new List<ClsStats>(list.listadoStats()); 
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

        public ClsAlien Alien
        {
            get
            {
                return _alien;
            }
            set
            {
                _alien = value;
                NotifyPropertyChanged("Alien");
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

        public List<ClsStats> Stats
        {
            get
            {
                return _stats;
            }
            set
            {
                _stats = value;
                NotifyPropertyChanged("Stats");
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
                //_mazmorra.Tablero.ElementAt(8 * (y+2) + (x)).LightImage = _mazmorra.Tablero.ElementAt(8 * (y+2) + (x)).DarkImage;
                _mazmorra.Tablero.ElementAt(8 * (y + 1) + (x)).DarkImage = "";
            }

            if (y-1 >= 0)//Foco arriba del personaje
            {
                //_mazmorra.Tablero.ElementAt(8 * (y) + (x)).LightImage = _mazmorra.Tablero.ElementAt(8 * (y) + (x)).DarkImage;
                _mazmorra.Tablero.ElementAt(8 * (y-1) + (x)).DarkImage = "";
            }

            if (x + 1 <= 7)//Foco derecha del personaje 
            {
                //_mazmorra.Tablero.ElementAt(8 * (y + 1) + (x+1)).LightImage = _mazmorra.Tablero.ElementAt(8 * (y + 1) + (x+1)).DarkImage;
                _mazmorra.Tablero.ElementAt(8 * (y ) + (x + 1)).DarkImage = "";
            }

            if (x - 1 >= 0)//Foco izquierda del personaje
            {
                //_mazmorra.Tablero.ElementAt(8 * (y + 1) + (x-1)).LightImage = _mazmorra.Tablero.ElementAt(8 * (y + 1) + (x - 1)).DarkImage;
                _mazmorra.Tablero.ElementAt(8 * (y ) + (x - 1)).DarkImage = "";
            }

            if (x + 1 <= 7 && y - 1 >= 0)//Foco derecha superior del personaje 
            {
                _mazmorra.Tablero.ElementAt(8 * (y-1) + (x + 1)).DarkImage = "";
            }

            if (x - 1 >= 0 && y - 1 >= 0)//Foco izquierda superior del personaje
            {
                _mazmorra.Tablero.ElementAt(8 * (y-1) + (x - 1)).DarkImage = "";
            }

            if (x + 1 <= 7 && y + 1 <= 7)//Foco derecha inferior del personaje 
            {
                _mazmorra.Tablero.ElementAt(8 * (y + 1) + (x + 1)).DarkImage = "";
            }

            if (x - 1 >= 0 && y + 1 <= 7)//Foco izquierda inferior del personaje
            {
                _mazmorra.Tablero.ElementAt(8 * (y + 1) + (x - 1)).DarkImage = "";
            }
        }
        
        public void ChangeImageToDark() {
            for (int i = 0; i < _mazmorra.Tablero.Count; i++) {
                if (_mazmorra.Tablero.ElementAt(i).DarkImage == "") {
                    String ruta = _mazmorra.Tablero.ElementAt(i).LightImage;
                    ruta = ruta.Substring(0, ruta.Length - 4);
                    _mazmorra.Tablero.ElementAt(i).DarkImage = ruta + "dark.png";
                }
                
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
            int x = _player.Position.X;
            int y = _player.Position.Y;
            switch (movement)
            {
                case 'u'://Up
                    if (_player.Position.Y > 0)
                    {
                        _mazmorra.Tablero.ElementAt(8 * (y) + (x)).CharacterImage = "";
                        _player.Position.Y = _player.Position.Y - 1;//Subimos al personaje
                        handlerPlayer();
                    }
                    break;
                case 'd'://Down
                    if (_player.Position.Y < 7)
                    {
                        _mazmorra.Tablero.ElementAt(8 * (y) + (x)).CharacterImage = "";
                        _player.Position.Y = _player.Position.Y + 1;//Bajamos al personaje
                        handlerPlayer();
                    }
                    break;
                case 'r'://Right
                    if (_player.Position.X < 7)
                    {
                        _mazmorra.Tablero.ElementAt(8 * (y) + (x)).CharacterImage = "";
                        _player.Position.X = _player.Position.X + 1;//Movemos el personaje a la Derecha (_player.Position.X++)
                        handlerPlayer();
                    }
                    break;
                case 'l'://Left
                    if (_player.Position.X > 0)
                    {
                        _mazmorra.Tablero.ElementAt(8 * (y) + (x)).CharacterImage = "";
                        _player.Position.X = _player.Position.X - 1;//Movemos el personaje a la izquierda (_player.Position.X--)
                        handlerPlayer();
                    }
                    break;
            }

        }
        private void handlerPlayer() {
            ChangeImageToDark();
            focoPersonaje();
            _mazmorra.Tablero.ElementAt(8 * (_player.Position.Y) + (_player.Position.X)).DarkImage = "/Assets/player.png";
            moveAlien();
        }
        #endregion

        #region Métodos Alien
        public void moveAlien()
        {
            Random random = new Random();
            bool moved = false;

            do
            {
                switch (random.Next(1, 9))
                {
                    case 1://El alien se intenta mover hacia arriba
                        if (_alien.Position.Y > 0)
                        {
                            _mazmorra.Tablero.ElementAt(8 * (_alien.Position.Y) + (_alien.Position.X)).CharacterImage = "";
                            _alien.Position.Y = _alien.Position.Y - 1;
                            hadlerAlien();
                        }
                        break;
                    case 2://El alien se intenta mover hacia abajo
                        if (_alien.Position.Y < 7)
                        {
                            _mazmorra.Tablero.ElementAt(8 * (_alien.Position.Y) + (_alien.Position.X)).CharacterImage = "";
                            _alien.Position.Y = _alien.Position.Y + 1;
                            hadlerAlien();
                        }
                        break;
                    case 3://El alien se intenta mover a la izquierda
                        if (_alien.Position.X > 0)
                        {
                            _mazmorra.Tablero.ElementAt(8 * (_alien.Position.Y) + (_alien.Position.X)).CharacterImage = "";
                            _alien.Position.X = _alien.Position.X - 1;
                            hadlerAlien();
                        }
                        break;
                    case 4://El alien se intenta mover a la derecha
                        if (_alien.Position.X < 7)
                        {
                            _mazmorra.Tablero.ElementAt(8 * (_alien.Position.Y) + (_alien.Position.X)).CharacterImage = "";
                            _alien.Position.X = _alien.Position.X + 1;
                            hadlerAlien();
                        }
                        break;
                    case 5://El alien se intenta mover a la derecha superior
                        if (_alien.Position.X < 7 && _alien.Position.Y > 0)
                        {
                            _mazmorra.Tablero.ElementAt(8 * (_alien.Position.Y) + (_alien.Position.X)).CharacterImage = "";
                            _alien.Position.X = _alien.Position.X + 1;
                            _alien.Position.Y = _alien.Position.Y - 1;
                            hadlerAlien();
                        }
                        break;
                    case 6://El alien se intenta mover a la izquierda superior
                        if (_alien.Position.X > 0 && _alien.Position.Y > 0)
                        {
                            _mazmorra.Tablero.ElementAt(8 * (_alien.Position.Y) + (_alien.Position.X)).CharacterImage = "";
                            _alien.Position.X = _alien.Position.X - 1;
                            _alien.Position.Y = _alien.Position.Y - 1;
                            hadlerAlien();
                        }
                        break;
                    case 7://El alien se intenta mover a la derecha inferior
                        if (_alien.Position.X < 7 && _alien.Position.Y < 7)
                        {
                            _mazmorra.Tablero.ElementAt(8 * (_alien.Position.Y) + (_alien.Position.X)).CharacterImage = "";
                            _alien.Position.X = _alien.Position.X + 1;
                            _alien.Position.Y = _alien.Position.Y + 1;
                            hadlerAlien();
                        }
                        break;
                    case 8://El alien se intenta mover a la derecha inferior
                        if (_alien.Position.X > 0 && _alien.Position.Y < 7)
                        {
                            _mazmorra.Tablero.ElementAt(8 * (_alien.Position.Y) + (_alien.Position.X)).CharacterImage = "";
                            _alien.Position.X = _alien.Position.X - 1;
                            _alien.Position.Y = _alien.Position.Y + 1;
                            hadlerAlien();
                        }
                        break;
                }

            } while (!moved);

            void hadlerAlien()
            {
                if (_mazmorra.Tablero.ElementAt(8 * (_alien.Position.Y) + (_alien.Position.X)).DarkImage.Equals(""))
                    _mazmorra.Tablero.ElementAt(8 * (_alien.Position.Y) + (_alien.Position.X)).CharacterImage = _alien.SrcImage;
                moved = true;

                if (_alien.Position.X == _player.Position.X && _alien.Position.Y == _player.Position.Y)//Sería un equals en el futuro
                {
                    if (_player.Ammo > 0)
                    {
                        _player.Ammo = _player.Ammo - 1;
                        alienEscape();//El alien escapa
                        //Inserta sonido disparo
                    }
                    else
                    {
                        //Inserta sonido muerte personaje
                    }
                }
            }
        }

        public void alienEscape()
        {
            if (_mazmorra.Tablero.ElementAt(63).CharacterImage.Equals(""))
            {
                _alien.Position.X = 7;
                _alien.Position.Y = 7;
            }
            else
            {
                _alien.Position.X = 0;
                _alien.Position.Y = 0;
            }
        }
        #endregion
    }
}
