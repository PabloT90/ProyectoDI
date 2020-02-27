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

//TODO: tenemos 2 reiniciar juego? -.-

namespace AlienCompadre.ViewModel
{
    public class ClsMainPageVM : INotifyPropertyChanged
    {
        private ClsTablero _mazmorra;
        private ClsPlayer _player;
        private ClsAlien _alien;
        private int _completedDungeons;
        private bool _keyFound;
        private String _srcKeyImage;
        private bool _repeat;
        private string _imageBlood;
        private int proximidad;
        private Boolean modoBroma;

        //Propiedades para controlar los sonidos
        private string sonidoArma;
        private String sonidoPartidaTerminada;
        private String sonidoProximidadCerca;
        private String sonidoPuerta;
        private String sonidoProximidadLejos;
        private String sonidoLlave;
        private String sonidoTrampa;
        private String sonidoRecarga;

        #region Constructores
        public ClsMainPageVM(){
            _mazmorra = new ClsTablero();
            _player = new ClsPlayer();
            _alien = new ClsAlien();
            _keyFound = false;
            _srcKeyImage = "/Assets/black_key.png";
            _repeat = false;
            _imageBlood = "";
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

        public bool Repeat
        {
            get
            {
                return _repeat;
            }
            set
            {
                _repeat = value;
                NotifyPropertyChanged("Repeat");
            }
        }

        public String ImageBlood
        {
            get
            {
                return _imageBlood;
            }
            set
            {
                _imageBlood = value;
                NotifyPropertyChanged("ImageBlood");
            }
        }

        public int Proximidad {
            get {
                return proximidad;
            }
            set {
                proximidad = value;
                NotifyPropertyChanged("Proximidad");
            }
        }

        public Boolean ModoBroma {
            get {
                return modoBroma;
            }
            set {
                modoBroma = value;
                asignarSonidos();
                NotifyPropertyChanged("ModoBroma");
            }
        }
        #endregion

        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = ""){
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
                _mazmorra.Tablero.ElementAt(8 * (y + 1) + (x)).DarkImage = "";
            }

            if (y-1 >= 0)//Foco arriba del personaje
            {
               _mazmorra.Tablero.ElementAt(8 * (y-1) + (x)).DarkImage = "";
            }

            if (x + 1 <= 7)//Foco derecha del personaje 
            {
               _mazmorra.Tablero.ElementAt(8 * (y ) + (x + 1)).DarkImage = "";
            }

            if (x - 1 >= 0)//Foco izquierda del personaje
            {
               _mazmorra.Tablero.ElementAt(8 * (y ) + (x - 1)).DarkImage = "";
            }

            if (x + 1 <= 7 && y - 1 >= 0)//Foco derecha superior del personaje 
            {
                _mazmorra.Tablero.ElementAt(8 * (y - 1) + (x + 1)).DarkImage = "";
            }

            if (x - 1 >= 0 && y - 1 >= 0)//Foco izquierda superior del personaje
            {
                _mazmorra.Tablero.ElementAt(8 * (y - 1) + (x - 1)).DarkImage = "";
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
        
        /// <summary>
        /// Cambia las imagenes claras a oscuras.
        /// </summary>
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
            Proximidad = 0;
            _mazmorra = new ClsTablero();
            NotifyPropertyChanged("Mazmorra");
            _player.Position = new ClsPunto(0, 0);
            _alien = new ClsAlien();
            _keyFound = false;
            _srcKeyImage = "/Assets/black_key.png";
            NotifyPropertyChanged("SrcKeyImage");
        }

        /// <summary>
        /// Reinicia el juego una vez haya terminado.
        /// </summary>
        private void ReiniciarJuego() {
            Proximidad = 0;
            Mazmorra = new ClsTablero();
            Player = new ClsPlayer();
            Alien = new ClsAlien();
            CompletedDungeons = 0;
            _keyFound = false;
            SrcKeyImage = "/Assets/black_key.png";
            Repeat = false;
            asignarSonidos();
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
            ImageBlood = "";
            int actualPosition = 8 * (_player.Position.Y) + (_player.Position.X);
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
            ChangeImageToDark();//Oscurecemos el tablero
            focoPersonaje();//Mostramos el foco del personaje
            int actualPosition = 8 * (_player.Position.Y) + (_player.Position.X);
            _mazmorra.Tablero.ElementAt(actualPosition).DarkImage = "/Assets/personaje.gif";//Mostramos al personaje

            switch (_mazmorra.Tablero.ElementAt(actualPosition).RowObject)
            {
                case 2:
                    if (_keyFound)//Si la casilla es la trampilla y el personaje tiene la llave
                    {
                        //Reproducimos el sonido de una puerta abriendose
                        playSounds(sonidoPuerta, 1);
                        //Ganas la partida
                        _completedDungeons++;
                        NotifyPropertyChanged("CompletedDungeons");
                        //Generamos una nueva mazmorra. 
                        newDungeon();
                    }
                    break;
                case 3:
                    if (!_mazmorra.Tablero.ElementAt(actualPosition).Chest.Open)
                    {
                        switch (_mazmorra.Tablero.ElementAt(actualPosition).Chest.ChestReward)
                        {
                            case 1://Contiene una llave
                                playSounds(sonidoLlave, 1.0);
                                this._keyFound = true;
                                _srcKeyImage = "/Assets/golden_key.png";
                                NotifyPropertyChanged("SrcKeyImage");
                                break;
                            case 2://Contiene munición
                                this._player.Ammo++;
                                playSounds(sonidoRecarga, 1.0);
                                NotifyPropertyChanged("Player");
                                break;
                            case 3://Contiene cristales
                                playSounds(sonidoTrampa, 1.0);
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

        /// <summary>
        /// Comentario: Este método nos permite comprobar si el personaje se ha encontrado con el alien, realizando el combate.
        /// </summary>
        public void encuentro(){
            if (_alien.Position.Equals(_player.Position)){
                int actualPosition = 8 * (_player.Position.Y) + (_player.Position.X);
                _mazmorra.Tablero.ElementAt(actualPosition).CharacterImage = "";
                //_mazmorra.Tablero.ElementAt(actualPosition).DarkImage = "personaje.gif";
                if (_player.Ammo > 0){
                    ImageBlood = "/Assets/bloodSplash.gif";
                    _player.Ammo--;
                    Proximidad = 100;
                    alienEscape();//El alien escapa
                    playSounds(sonidoArma, 1.0);//Inserta sonido disparo
                }else{
                    playSounds(sonidoPartidaTerminada, 1.0);//Inserta sonido muerte personaje
                    var frame = (Frame)Window.Current.Content;
                    frame.Navigate(typeof(PantallaFinal), CompletedDungeons);
                    ReiniciarJuego();
                }
            }
        }

        /// <summary>
        /// Comentario: Este método nos permite mover al alien por el tablero, además tiene en cuenta los posibles encuentros con el jugador.
        /// </summary>
        public void moveAlienIA(){
            Random random = new Random();
            bool moved = false;
            _mazmorra.Tablero.ElementAt(8 * (_alien.Position.Y) + (_alien.Position.X)).CharacterImage = "";//Eliminamos la imagen del alien antes de cambiarle de posición
            if (_player.Position.Equals(_alien.Position))//Si el jugador se ha acerdado al alien
            {
                encuentro();
            }else{
                if (random.Next(1, 10) == 1)//Teletransportamos al alien a una posición aleatoria
                {
                    do{ 
                        _alien.Position = new ClsPunto(random.Next(0, 8), random.Next(0, 8));
                    } while (_player.Position.Equals(_alien.Position));//Si se teletransporta a la posición del jugador
                }else//El alien se acerca al jugador
                {
                    do{
                        switch (random.Next(1, 4)){
                            case 1://Intentamos mover el alien en horizontal hacia el jugador
                                if (_player.Position.X > _alien.Position.X && _alien.Position.X < 7)
                                {
                                    _alien.Position.X++;
                                }else{
                                    if (_player.Position.X < _alien.Position.X && _alien.Position.X > 0){
                                        _alien.Position.X--;
                                    }
                                }
                                moved = true;

                                break;
                            case 2://Intentamos mover el alien en vertical hacia el jugador
                                if (_player.Position.Y > _alien.Position.Y && _alien.Position.Y < 7)
                                {
                                    _alien.Position.Y++;
                                    moved = true;
                                }
                                else
                                {
                                    if (_player.Position.Y < _alien.Position.Y && _alien.Position.Y > 0)
                                    {
                                        _alien.Position.Y--;
                                        moved = true;
                                    }
                                }
                                
                                break;
                            case 3://Intentamos mover el alien en diagonal hacia el jugador
                                if (_player.Position.X > _alien.Position.X && _player.Position.Y > _alien.Position.Y && _alien.Position.X < 7 && _alien.Position.Y < 7)
                                {
                                    _alien.Position = new ClsPunto(_alien.Position.X + 1, _alien.Position.Y + 1);
                                    moved = true;
                                }
                                else
                                {
                                    if (_player.Position.X < _alien.Position.X && _player.Position.Y < _alien.Position.Y && _alien.Position.X > 0 && _alien.Position.Y > 0)
                                    {
                                        _alien.Position = new ClsPunto(_alien.Position.X - 1, _alien.Position.Y - 1);
                                        moved = true;
                                    }
                                    else
                                    {
                                        if (_player.Position.X > _alien.Position.X && _player.Position.Y < _alien.Position.Y && _alien.Position.X < 7 && _alien.Position.Y > 0)
                                        {
                                            _alien.Position = new ClsPunto(_alien.Position.X + 1, _alien.Position.Y - 1);
                                            moved = true;
                                        }
                                        else
                                        {
                                            if (_player.Position.X < _alien.Position.X && _player.Position.Y > _alien.Position.Y && _alien.Position.X > 0 && _alien.Position.Y < 7)
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
                alertaProximidad(); //Ejecutamos los posibles sonidos
            }
        }

        /// <summary>
        /// Comentario: Este método nos permite mostrar la imagen del alien si se encuentra en una posición con el foco del personaje
        /// y realizar los posibles encuentros entre estos dos.
        /// </summary>
        private void handlerAlien()
        {
            int postPosition = 8 * (_alien.Position.Y) + (_alien.Position.X);
            if (_mazmorra.Tablero.ElementAt(postPosition).DarkImage.Equals(""))//Si el alien se encuentra en un foco del personaje
                _mazmorra.Tablero.ElementAt(postPosition).CharacterImage = _alien.SrcImage;

            encuentro();
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
            alertaProximidad();
        }
        #endregion

        #region Para el sonido
        /// <summary>
        /// Asigna los sonidos que seran reproducidos en la partida, segun el modo elegido.
        /// </summary>
        private void asignarSonidos() {
            sonidoLlave = "keysound.mp3";
            sonidoTrampa = "risa.wav";
            sonidoRecarga = "reload.mp3";
            if (!ModoBroma) { //Si el modo broma esta activado.
                sonidoArma = "comor.mp3";
                sonidoPartidaTerminada = "chiquitomuerte.mp3";
                sonidoProximidadCerca = "cercachiquito.mp3";
                sonidoPuerta = "condenao.mp3";
                sonidoProximidadLejos = "cobarde.mp3";
            } else {
                sonidoArma = "disparo.wav";
                sonidoPartidaTerminada = "gritoHombre.wav";
                sonidoProximidadCerca = "cerca.wav";
                sonidoPuerta = "puertaAbierta.wav";
                sonidoProximidadLejos = "media.mp3";
            }
        }

        /// <summary>
        /// Se encarga de reproducir una pista de sonido.
        /// </summary>
        /// <param name="sonido">Nombre del archivo a reproducir dentro de la carpeta Sounds.</param>
        /// <param name="volumen">Volumen de la reproduccion.</param>
        private async void playSounds(string sonido, double volumen)
        {
            MediaElement mysong = new MediaElement();
            mysong.Volume = volumen;
            Windows.Storage.StorageFolder folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("Sounds");
            String archivoMusica = sonido;
            Windows.Storage.StorageFile file = await folder.GetFileAsync(archivoMusica);
            var stream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
            mysong.SetSource(stream, file.ContentType);
            
            mysong.Play();
        }

        /// <summary>
        /// Avisa al jugador sobre la posicion del enemigo segun la distancia de este ultimo.
        /// </summary>
        private void alertaProximidad() {
            //Cogemos las coordenadas del jugador y del enemigo
            int distanciaX = Math.Abs(_player.Position.X - _alien.Position.X);
            int distanciaY = Math.Abs(_player.Position.Y - _alien.Position.Y);

            if (distanciaX <= 1 && distanciaY <= 1) {
                //Sonido fuerte
                playSounds(sonidoProximidadCerca, 1.0);
                Proximidad = 90;
            } else if (distanciaX <= 2 && distanciaY <= 2) {
                //Sonido medio
                playSounds(sonidoProximidadLejos, 1.0);
                Proximidad = 70;
            }else if (distanciaX == 0 && distanciaY == 0) {
                playSounds(sonidoProximidadLejos, 1.0);
                Proximidad = 95;
            } else {
                Random random = new Random();
                Proximidad = random.Next(10, 60);
            }
        }
        #endregion
    }
}
