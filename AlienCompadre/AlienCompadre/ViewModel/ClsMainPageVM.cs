using AlienCompadre.Models;
using AlienCompadre.Views;
using AlienCompadre_BL.Lists;
using AlienCompadre_Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

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
        private bool _keyFound;

        #region Constructores
        public ClsMainPageVM()
        {
            _mazmorra = new ClsTablero();
            _player = new ClsPlayer();
            _alien = new ClsAlien();
            _stats = new List<ClsStats>();
            _stats = new List<ClsStats>(list.listadoStats());
            _keyFound = false;
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
            int actualPosition = 8 * (_player.Position.Y) + (_player.Position.X); ;
            switch (movement)
            {
                case 'u'://Up
                    if (_player.Position.Y > 0)
                    {
                        _mazmorra.Tablero.ElementAt(actualPosition).CharacterImage = "";
                        _player.Position.Y = _player.Position.Y - 1;//Subimos al personaje
                        handlerPlayer();
                    }
                    break;
                case 'd'://Down
                    if (_player.Position.Y < 7)
                    {
                        _mazmorra.Tablero.ElementAt(actualPosition).CharacterImage = "";
                        _player.Position.Y = _player.Position.Y + 1;//Bajamos al personaje
                        handlerPlayer();
                    }
                    break;
                case 'r'://Right
                    if (_player.Position.X < 7)
                    {
                        _mazmorra.Tablero.ElementAt(actualPosition).CharacterImage = "";
                        _player.Position.X = _player.Position.X + 1;//Movemos el personaje a la Derecha (_player.Position.X++)
                        handlerPlayer();
                    }
                    break;
                case 'l'://Left
                    if (_player.Position.X > 0)
                    {
                        _mazmorra.Tablero.ElementAt(actualPosition).CharacterImage = "";
                        _player.Position.X = _player.Position.X - 1;//Movemos el personaje a la izquierda (_player.Position.X--)
                        handlerPlayer();
                    }
                    break;
            }

        }
        private void handlerPlayer() {
            ChangeImageToDark();//Oscurecemos el tableor
            focoPersonaje();//Mostramos el foco del personaje
            int actualPosition = 8 * (_player.Position.Y) + (_player.Position.X);
            _mazmorra.Tablero.ElementAt(actualPosition).DarkImage = "/Assets/player.png";//Mostramos al personaje
            if (_mazmorra.Tablero.ElementAt(actualPosition).RowObject == 3)   //Comprobamos si el personaje se ha parado en un cofre
            {
                switch(_mazmorra.Tablero.ElementAt(actualPosition).ChestReward)
                {
                    case 1://Contiene una llave
                        this._keyFound = true;
                        break;
                    case 2://Contiene munición
                        this._player.Ammo++;
                        break;
                    case 3://Contiene cristales
                        //Mover al alien cerca
                        break;
                }
            }

            if (_mazmorra.Tablero.ElementAt(8 * (_player.Position.Y) + (_player.Position.X)).RowObject == 2 && _keyFound)//Si la casilla es la trampilla y el personaje tiene la llave
            {
                //Ganas la partida
            }
            moveAlien();//Movemos al alien
        }
        #endregion

        #region Métodos Alien
        public void moveAlien()
        {
            Random random = new Random();
            int actualPosition = 8 * (_alien.Position.Y) + (_alien.Position.X);
            bool moved = false;
            do
            {
                switch (random.Next(1, 9))
                {
                    case 1://El alien se intenta mover hacia arriba
                        if (_alien.Position.Y > 0)
                        {
                            _mazmorra.Tablero.ElementAt(actualPosition).CharacterImage = "";
                            _alien.Position.Y = _alien.Position.Y - 1;
                            hadlerAlien();
                        }
                        break;
                    case 2://El alien se intenta mover hacia abajo
                        if (_alien.Position.Y < 7)
                        {
                            _mazmorra.Tablero.ElementAt(actualPosition).CharacterImage = "";
                            _alien.Position.Y = _alien.Position.Y + 1;
                            hadlerAlien();
                        }
                        break;
                    case 3://El alien se intenta mover a la izquierda
                        if (_alien.Position.X > 0)
                        {
                            _mazmorra.Tablero.ElementAt(actualPosition).CharacterImage = "";
                            _alien.Position.X = _alien.Position.X - 1;
                            hadlerAlien();
                        }
                        break;
                    case 4://El alien se intenta mover a la derecha
                        if (_alien.Position.X < 7)
                        {
                            _mazmorra.Tablero.ElementAt(actualPosition).CharacterImage = "";
                            _alien.Position.X = _alien.Position.X + 1;
                            hadlerAlien();
                        }
                        break;
                    case 5://El alien se intenta mover a la derecha superior
                        if (_alien.Position.X < 7 && _alien.Position.Y > 0)
                        {
                            _mazmorra.Tablero.ElementAt(actualPosition).CharacterImage = "";
                            //_alien.Position.X = _alien.Position.X + 1;
                            //_alien.Position.Y = _alien.Position.Y - 1;
                            _alien.Position = new ClsPunto(_alien.Position.X + 1, _alien.Position.Y - 1);
                            hadlerAlien();
                        }
                        break;
                    case 6://El alien se intenta mover a la izquierda superior
                        if (_alien.Position.X > 0 && _alien.Position.Y > 0)
                        {
                            _mazmorra.Tablero.ElementAt(actualPosition).CharacterImage = "";
                            //_alien.Position.X = _alien.Position.X - 1;
                            //_alien.Position.Y = _alien.Position.Y - 1;
                            _alien.Position = new ClsPunto(_alien.Position.X - 1, _alien.Position.Y - 1);
                            hadlerAlien();
                        }
                        break;
                    case 7://El alien se intenta mover a la derecha inferior
                        if (_alien.Position.X < 7 && _alien.Position.Y < 7)
                        {
                            _mazmorra.Tablero.ElementAt(actualPosition).CharacterImage = "";
                            //_alien.Position.X = _alien.Position.X + 1;
                            //_alien.Position.Y = _alien.Position.Y + 1;
                            _alien.Position = new ClsPunto(_alien.Position.X + 1, _alien.Position.Y + 1);
                            hadlerAlien();
                        }
                        break;
                    case 8://El alien se intenta mover a la derecha inferior
                        if (_alien.Position.X > 0 && _alien.Position.Y < 7)
                        {
                            _mazmorra.Tablero.ElementAt(actualPosition).CharacterImage = "";
                            //_alien.Position.X = _alien.Position.X - 1;
                            //_alien.Position.Y = _alien.Position.Y + 1;
                            _alien.Position = new ClsPunto(_alien.Position.X - 1, _alien.Position.Y + 1);
                            hadlerAlien();
                        }
                        break;
                }

            } while (!moved);//Mientras no se haya movido

            void hadlerAlien()
            {
                if (_mazmorra.Tablero.ElementAt(actualPosition).DarkImage.Equals(""))//Si el alien se encuentra en un foco del personaje
                    _mazmorra.Tablero.ElementAt(actualPosition).CharacterImage = _alien.SrcImage;
                moved = true;

                if (_alien.Position.X == _player.Position.X && _alien.Position.Y == _player.Position.Y)//Sería un equals en el futuro
                {
                    if (_player.Ammo > 0)
                    {
                        _player.Ammo = --_player.Ammo;
                        alienEscape();//El alien escapa
                        //Inserta sonido disparo
                        //playSounds(1);
                    }
                    else
                    {
                        //Inserta sonido muerte personaje
                        //playSounds(2);
                        Frame fr = new Frame();
                        fr.Navigate(typeof(PantallaFinal)); //No funciona
                    }
                }
            }
        }

        public void alienEscape()
        {
            if (_mazmorra.Tablero.ElementAt(63).CharacterImage.Equals(""))
            {
                //_alien.Position.X = 7;
                //_alien.Position.Y = 7;
                _alien.Position = new ClsPunto(7, 7);
            }
            else
            {
                //_alien.Position.X = 0;
                //_alien.Position.Y = 0;
                _alien.Position = new ClsPunto(0, 0);
            }
        }
        #endregion

        #region Para el sonido
        private async void playSounds(int numero)
        {
            MediaElement mysong = new MediaElement();
            Windows.Storage.StorageFolder folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("Sounds");
            String archivoMusica = "";
            switch (numero)
            {
                case 1:
                    archivoMusica = "4gun1.wav";
                    break;
                case 2:
                    archivoMusica = "grito.mp3";
                    break;
            }
            Windows.Storage.StorageFile file = await folder.GetFileAsync(archivoMusica);
            var stream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
            mysong.SetSource(stream, file.ContentType);
            mysong.Play();
        }
        #endregion
    }
}
