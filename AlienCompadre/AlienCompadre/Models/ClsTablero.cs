using AlienCompadre.Utilities.Lists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienCompadre_Entities
{
    public class ClsTablero
    {
        private const int _numbersOfChest = 3;
        private const int _numbersOfDoors = 1;
        private List<ClsCasilla> _tablero;

        #region Constructor
        public ClsTablero()
        {
            _tablero = new List<ClsCasilla>();
            tableroAleatorio();
        }
        #endregion
        #region Propiedades Públicas
        public List<ClsCasilla> Tablero
        {
            get
            {
                return _tablero;
            }
        }
        #endregion
        #region Métodos privados
        /// <summary>
        /// Comentario: Este método nos permite generar un tablero aleatorio. El tablero contendrá cofres, una puerta, el personaje
        /// del jugador y un alien.
        /// </summary>
        private void tableroAleatorio()
        {
            Random random = new Random();
            int numeroCasillasVacias = 62 - (_numbersOfChest + _numbersOfDoors);
            for (int i = 0; i < numeroCasillasVacias; i++)//Generamos las casillas vacías del tablero
                _tablero.Add(new ClsCasilla("DireccionImagenVacíaTipo"+ random.Next(1, 4), 0));//0 significa que la casilla esta vacía
            
            for (int i = 0; i < _numbersOfChest; i++)//Agregamos los cofres
                _tablero.Add(new ClsCasilla("DireccionImagenCofre", 3));              
            
            _tablero.Add(new ClsCasilla("/Assets/trapdoor.png", 2));//2 significa que la casilla contiene una puerta

            ListUtility.ShuffleList(ref _tablero);//Nos permite mezclar las casillas del tablero

            _tablero.Insert(0, new ClsCasilla("DireccionImagenPersonaje", 1));//1 significa que la casilla contiene un personaje
            _tablero.Add(new ClsCasilla("DireccionImagenAlien", 4));//4 significa que la casilla contiene un alien 
        }
        #endregion
    }
}
