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
            int casilla;

            _tablero.Add(new ClsCasilla("DireccionImagenPersonaje", 1));//1 significa que la casilla contiene un personaje

            for (int i = 1; i < (_tablero.Count - 2); i++)//Generamos las casillas intermedias del tablero
            {
                _tablero.Add(new ClsCasilla("DireccionImagenVacíaTipo"+ random.Next(1, 4), 0));//0 significa que la casilla esta vacía
            }

            _tablero.Add(new ClsCasilla("DireccionImagenAlien", 4));//1 significa que la casilla contiene un alien

            for (int i = 0; i < _numbersOfChest; i++)
            {
                casilla = random.Next(2, 63);
                if (_tablero.ElementAt(casilla).RowObject == 0)
                {
                    _tablero.Insert(casilla, new ClsCasilla("DireccionImagenCofre", 3));
                }
                else {
                    i--;
                }
            }

            casilla = random.Next(2, 63);
            do {
                if (_tablero.ElementAt(casilla).RowObject == 0)
                    _tablero.Insert(casilla, new ClsCasilla("DireccionImagenCofre", 3));               
            } while (_tablero.ElementAt(casilla = random.Next(2, 63)).RowObject != 0);
        } 
        #endregion
    }
}
