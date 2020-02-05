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
using Windows.UI.Xaml;

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
        private String _srcKeyImage;
        //private MediaElement mysong = new MediaElement(); //Solamente para el sonido

        #region Constructores
        public ClsMainPageVM()
        {
            _mazmorra = new ClsTablero();
            _player = new ClsPlayer();
            _alien = new ClsAlien();
            _stats = new List<ClsStats>();
            _stats = new List<ClsStats>(list.listadoStats());
            _keyFound = false;
            _srcKeyImage = "/Assets/black_key.png";
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

        public String SrcKeyImage
        {
            get
            {
                return _srcKeyImage;
            }
            set
            {
                _srcKeyImage = value;
                NotifyPropertyChanged("SrcKeyImage");
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

            //if (x + 1 <= 7 && y - 1 >= 0)//Foco derecha superior del personaje 
            //{
            //    _mazmorra.Tablero.ElementAt(8 * (y - 1) + (x + 1)).DarkImage = "";
            //}

            //if (x - 1 >= 0 && y - 1 >= 0)//Foco izquierda superior del personaje
            //{
            //    _mazmorra.Tablero.ElementAt(8 * (y - 1) + (x - 1)).DarkImage = "";
            //}

            //if (x + 1 <= 7 && y + 1 <= 7)//Foco derecha inferior del personaje 
            //{
            //    _mazmorra.Tablero.ElementAt(8 * (y + 1) + (x + 1)).DarkImage = "";
            //}

            //if (x - 1 >= 0 && y + 1 <= 7)//Foco izquierda inferior del personaje
            //{
            //    _mazmorra.Tablero.ElementAt(8 * (y + 1) + (x - 1)).DarkImage = "";
            //}
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

        /// <summary>
        /// Comentario: Este método nos permite reiniciar la mazmorra.
        /// </summary>
        public void newDungeon()
        {
            _mazmorra = new ClsTablero();
            NotifyPropertyChanged("Mazmorra");
            //_player = new ClsPlayer(_player.Ammo);
            _player.Position = new ClsPunto(0, 0);
            _alien = new ClsAlien();
            _keyFound = false;
            _srcKeyImage = "/Assets/black_key.png";
            NotifyPropertyChanged("SrcKeyImage");
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
                        _player.Position.Y--;//Subimos al personaje
                        handlerPlayer();
                    }
                    break;
                case 'd'://Down
                    if (_player.Position.Y < 7)
                    {
                        _mazmorra.Tablero.ElementAt(actualPosition).CharacterImage = "";
                        _player.Position.Y++;//Bajamos al personaje
                        handlerPlayer();
                    }
                    break;
                case 'r'://Right
                    if (_player.Position.X < 7)
                    {
                        _mazmorra.Tablero.ElementAt(actualPosition).CharacterImage = "";
                        _player.Position.X++; //Movemos el personaje a la Derecha
                        handlerPlayer();
                    }
                    break;
                case 'l'://Left
                    if (_player.Position.X > 0)
                    {
                        _mazmorra.Tablero.ElementAt(actualPosition).CharacterImage = "";
                        _player.Position.X--;//Movemos el personaje a la izquierda
                        handlerPlayer();
                    }
                    break;
            }

        }
        private void handlerPlayer() {
            ChangeImageToDark();//Oscurecemos el tableor
            focoPersonaje();//Mostramos el foco del personaje
            int actualPosition = 8 * (_player.Position.Y) + (_player.Position.X);
            _mazmorra.Tablero.ElementAt(actualPosition).DarkImage = "/Assets/personaje.gif";//Mostramos al personaje

            switch (_mazmorra.Tablero.ElementAt(actualPosition).RowObject)
            {
                case 2:
                    if (_keyFound)//Si la casilla es la trampilla y el personaje tiene la llave
                    {
                        //Ganas la partida
                        _completedDungeons++;
                        NotifyPropertyChanged("CompletedDungeons");
                        newDungeon();
                    }
                    break;
                case 3:
                    if (!_mazmorra.Tablero.ElementAt(actualPosition).Chest.Open)
                    {
                        switch (_mazmorra.Tablero.ElementAt(actualPosition).Chest.ChestReward)
                        {
                            case 1://Contiene una llave
                                this._keyFound = true;
                                _srcKeyImage = "/Assets/golden_key.png";
                                NotifyPropertyChanged("SrcKeyImage");
                                break;
                            case 2://Contiene munición
                                this._player.Ammo++;
                                NotifyPropertyChanged("Player");
                                break;
                            case 3://Contiene cristales
                                   //Mover al alien cerca
                                ambush();
                                break;
                        }
                    }
                    _mazmorra.Tablero.ElementAt(actualPosition).Chest.Open = true;
                    _mazmorra.Tablero.ElementAt(actualPosition).LightImage = "/Assets/chestOpen.png";
                    break;
            }
            //moveAlien();//Movemos al alien
            encuentro();
            moveAlienIA();
        }
        #endregion

        #region Métodos Alien
        //public void moveAlien()//Fuera
        //{
        //    Random random = new Random();
        //    int actualPosition = 8 * (_alien.Position.Y) + (_alien.Position.X);
        //    bool moved = false;
        //    _mazmorra.Tablero.ElementAt(actualPosition).CharacterImage = "";
        //    do
        //    {
        //        switch (random.Next(1, 9))
        //        {
        //            case 1://El alien se intenta mover hacia arriba
        //                if (_alien.Position.Y > 0)
        //                {
        //                    _alien.Position.Y--;
        //                    handlerAlien();
        //                }
        //                break;
        //            case 2://El alien se intenta mover hacia abajo
        //                if (_alien.Position.Y < 7)
        //                {
        //                    _alien.Position.Y++;
        //                    handlerAlien();
        //                }
        //                break;
        //            case 3://El alien se intenta mover a la izquierda
        //                if (_alien.Position.X > 0)
        //                {
        //                    _alien.Position.X--;
        //                    handlerAlien();
        //                }
        //                break;
        //            case 4://El alien se intenta mover a la derecha
        //                if (_alien.Position.X < 7)
        //                {
        //                    _alien.Position.X++;
        //                    handlerAlien();
        //                }
        //                break;
        //            case 5://El alien se intenta mover a la derecha superior
        //                if (_alien.Position.X < 7 && _alien.Position.Y > 0)
        //                {
        //                    _alien.Position = new ClsPunto(++_alien.Position.X, --_alien.Position.Y);
        //                    handlerAlien();
        //                }
        //                break;
        //            case 6://El alien se intenta mover a la izquierda superior
        //                if (_alien.Position.X > 0 && _alien.Position.Y > 0)
        //                {
        //                    _alien.Position = new ClsPunto(--_alien.Position.X, --_alien.Position.Y);
        //                    handlerAlien();
        //                }
        //                break;
        //            case 7://El alien se intenta mover a la derecha inferior
        //                if (_alien.Position.X < 7 && _alien.Position.Y < 7)
        //                {
        //                    _alien.Position = new ClsPunto(++_alien.Position.X, ++_alien.Position.Y);
        //                    handlerAlien();
        //                }
        //                break;
        //            case 8://El alien se intenta mover a la derecha inferior
        //                if (_alien.Position.X > 0 && _alien.Position.Y < 7)
        //                {
        //                    _alien.Position = new ClsPunto(--_alien.Position.X, ++_alien.Position.Y);
        //                    handlerAlien();
        //                }
        //                break;
        //        }

        //    } while (!moved);//Mientras no se haya movido

        //    void handlerAlien()
        //    {
        //        int postPosition = 8 * (_alien.Position.Y) + (_alien.Position.X);
        //        if (_mazmorra.Tablero.ElementAt(postPosition).DarkImage.Equals(""))//Si el alien se encuentra en un foco del personaje
        //            _mazmorra.Tablero.ElementAt(postPosition).CharacterImage = _alien.SrcImage;
        //        moved = true;

        //        //if (_alien.Position.X == _player.Position.X && _alien.Position.Y == _player.Position.Y)//Sería un equals en el futuro
        //        /*if (_alien.Position.Equals(_player.Position))
        //        {
        //            if (_player.Ammo > 0)
        //            {
        //                _player.Ammo--;
        //                alienEscape();//El alien escapa
        //                //Inserta sonido disparo
        //                //playSounds(1);
        //            }
        //            else
        //            {
        //                //Inserta sonido muerte personaje
        //                //playSounds(2);
        //                var frame = (Frame)Window.Current.Content;
        //                frame.Navigate(typeof(PantallaFinal));
        //            }
        //        }*/
        //        encuentro();
        //    }
        //}

        public void encuentro()
        {
            if (_alien.Position.Equals(_player.Position))
            {
                if (_player.Ammo > 0)
                {
                    _player.Ammo--;
                    alienEscape();//El alien escapa
                                  //Inserta sonido disparo
                    //playSounds(1);
                }
                else
                {
                    //Inserta sonido muerte personaje
                    //playSounds(2);
                    var frame = (Frame)Window.Current.Content;
                    frame.Navigate(typeof(PantallaFinal));
                    frame.BackStack.Clear();
                }
            }
        }

        public void moveAlienIA()
        {
            Random random = new Random();
            bool moved = false;
            _mazmorra.Tablero.ElementAt(8 * (_alien.Position.Y) + (_alien.Position.X)).CharacterImage = "";
            if (_player.Position.Equals(_alien.Position))
            {
                encuentro();
            }
            else
            {
                if (random.Next(1, 10) == 1)
                {
                    do
                    { 
                        _alien.Position = new ClsPunto(random.Next(0, 8), random.Next(0, 8));
                    } while (_player.Position.Equals(_alien.Position));//Si se teletransporta a la posición del jugador
                }
                else
                {
                    do
                    {
                        switch (random.Next(1, 4))
                        {
                            case 1:
                                if (_player.Position.X > _alien.Position.X)
                                {
                                    _alien.Position.X++;
                                }
                                else
                                {
                                    _alien.Position.X--;
                                }
                                moved = true;

                                break;
                            case 2:
                                if (_player.Position.Y > _alien.Position.Y)
                                {
                                    _alien.Position.Y++;
                                }
                                else
                                {
                                    _alien.Position.Y--;
                                }
                                moved = true;
                                break;
                            case 3:
                                if (_player.Position.X > _alien.Position.X && _player.Position.Y > _alien.Position.Y)
                                {
                                    _alien.Position = new ClsPunto(_alien.Position.X + 1, _alien.Position.Y + 1);
                                    moved = true;
                                }
                                else
                                {
                                    if (_player.Position.X < _alien.Position.X && _player.Position.Y < _alien.Position.Y)
                                    {
                                        _alien.Position = new ClsPunto(_alien.Position.X - 1, _alien.Position.Y - 1);
                                        moved = true;
                                    }
                                    else
                                    {
                                        if (_player.Position.X > _alien.Position.X && _player.Position.Y < _alien.Position.Y)
                                        {
                                            _alien.Position = new ClsPunto(_alien.Position.X + 1, _alien.Position.Y - 1);
                                            moved = true;
                                        }
                                        else
                                        {
                                            if (_player.Position.X < _alien.Position.X && _player.Position.Y > _alien.Position.Y)
                                            {
                                                _alien.Position = new ClsPunto(_alien.Position.X - 1, _alien.Position.Y + 1);
                                                moved = true;
                                            }
                                        }
                                    }
                                }
                                break;
                        }
                    } while (!moved);

                }
                handlerAlien();
            }

            void handlerAlien()
            {
                int postPosition = 8 * (_alien.Position.Y) + (_alien.Position.X);
                if (_mazmorra.Tablero.ElementAt(postPosition).DarkImage.Equals(""))//Si el alien se encuentra en un foco del personaje
                    _mazmorra.Tablero.ElementAt(postPosition).CharacterImage = _alien.SrcImage;

                encuentro();
                //TODO Borrar cuando funcione correctamente
                //if (_alien.Position.Equals(_player.Position))
                //{
                //    if (_player.Ammo > 0)
                //    {
                //        _player.Ammo--;
                //        alienEscape();//El alien escapa
                //        //playSounds(1);
                //    }
                //    else
                //    {
                //        //playSounds(2);
                //        var frame = (Frame)Window.Current.Content;
                //        frame.Navigate(typeof(PantallaFinal));
                //    }
                //}
            }
        }

        /// <summary>
        /// Comentario: Este método nos permite que el alien escape cuando reciba un tiro.
        /// </summary>
        public void alienEscape()
        {
            if (_mazmorra.Tablero.ElementAt(63).CharacterImage.Equals(""))
            {
                _alien.Position = new ClsPunto(7, 7);
            }
            else
            {
                _alien.Position = new ClsPunto(0, 0);
            }
        }

        /// <summary>
        /// Comentario: Este método nos permite acercar al alien hacia el personaje.
        /// </summary>
        public void ambush()
        {
            Random random = new Random();
            bool moved = false;

            _mazmorra.Tablero.ElementAt(8 * (_alien.Position.Y) + (_alien.Position.X)).CharacterImage = "";
            do
            {
                switch (random.Next(1, 9))
                {
                    case 1://El alien se intenta posicionar arriba del personaje
                        if (_player.Position.Y > 0)
                        {
                            _alien.Position = new ClsPunto(_player.Position.X, _player.Position.Y - 1);
                            moved = true;
                        }
                        break;
                    case 2://El alien se intenta posicionar abajo del personaje
                        if (_player.Position.Y < 7)
                        {
                            _alien.Position = new ClsPunto(_player.Position.X, _player.Position.Y + 1);
                            moved = true;
                        }
                        break;
                    case 3://El alien se intenta posicionar a la izquierda del personaje
                        if (_player.Position.X > 0)
                        {
                            _alien.Position = new ClsPunto(_player.Position.X -1, _player.Position.Y);
                            moved = true;
                        }
                        break;
                    case 4://El alien se intenta posicionar a la derecha del personaje
                        if (_player.Position.X < 7)
                        {
                            _alien.Position = new ClsPunto(_player.Position.X +1, _player.Position.Y);
                            moved = true;
                        }
                        break;
                    case 5://El alien se intenta posicionar a la derecha superior del personaje
                        if (_player.Position.X < 7 && _player.Position.Y > 0)
                        {
                            _alien.Position = new ClsPunto(_player.Position.X +1, _player.Position.Y - 1);
                            moved = true;
                        }
                        break;
                    case 6://El alien se intenta posicionar a la izquierda superior del personaje
                        if (_player.Position.X > 0 && _player.Position.Y > 0)
                        {
                            _alien.Position = new ClsPunto(_player.Position.X -1, _player.Position.Y - 1);
                            moved = true;
                        }
                        break;
                    case 7://El alien se intenta posicionar a la derecha inferior del personaje
                        if (_player.Position.X < 7 && _player.Position.Y < 7)
                        {
                            _alien.Position = new ClsPunto(_player.Position.X +1, _player.Position.Y + 1);
                            moved = true;
                        }
                        break;
                    case 8://El alien se intenta posicionar a la derecha inferior del personaje
                        if (_player.Position.X > 0 && _player.Position.Y < 7)
                        {
                            _alien.Position = new ClsPunto(_player.Position.X -1, _player.Position.Y + 1);
                            moved = true;
                        }
                        break;
                }

            } while (!moved);//Mientras no se haya movido
            _mazmorra.Tablero.ElementAt(8 * (_alien.Position.Y) + (_alien.Position.X)).CharacterImage = _alien.SrcImage;
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
            //return mysong;
            mysong.Play();
        }

        private void alertaProximidad() {
            //Cogemos las coordenadas del jugador y del enemigo
            int playerPosX = _player.Position.X;
            int playerPosY = _player.Position.Y;
            int enemyPosX = _alien.Position.X;
            int enemyPosY = _alien.Position.Y;

            //si esta en la misma linea
            if (((playerPosX - enemyPosX) <= -1) || ((playerPosX - enemyPosX) >= 1)) {
                if (((playerPosY - enemyPosY) <= -1) || ((playerPosY - enemyPosY) >= 1)) {
                    //Sonido fuerte
                }
            }else if (((playerPosX - enemyPosX) <= -2) || ((playerPosX - enemyPosX) >= 2)) {
                if (((playerPosY - enemyPosY) <= -2) || ((playerPosY - enemyPosY) >= 2)) {
                    //Sonido medio
                }
            }
        }
        #endregion
    }
}
