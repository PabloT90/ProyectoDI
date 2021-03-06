﻿using AlienCompadre.Utilities.Lists;
using System;
using System.Collections.Generic;

namespace AlienCompadre_Entities 
{
    public class ClsTablero {
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
            int numRandom;
            for (int i = 0; i < numeroCasillasVacias; i++) {//Generamos las casillas vacías del tablero
                numRandom = random.Next(1, 16);
                _tablero.Add(new ClsCasilla("/Assets/floor" + numRandom + ".png", "/Assets/floor" + numRandom + "dark.png", "", 0));//0 significa que la casilla esta vacía
                //_tablero.Add(new ClsCasilla("/Assets/floor" + numRandom + ".png", "", "", 0));//0 significa que la casilla esta vacía
            }

            for (int i = 1; i <= 3; i++) {
                numRandom = random.Next(1, 16);
                _tablero.Add(new ClsCasilla("/Assets/chestclosed.png", "/Assets/floor" + numRandom + "dark.png", "", 3, new ClsCofre(i, false)));//Contiene la llave
            }

            _tablero.Add(new ClsCasilla("/Assets/trapdoor.png", "/Assets/floor1dark.png", "", 2));//2 significa que la casilla contiene una puerta

            ListUtility.ShuffleList(ref _tablero);//Nos permite mezclar las casillas del tablero

            _tablero.Insert(0, new ClsCasilla("/Assets/floor1.png", "/Assets/floor1dark.png", "/Assets/personaje.gif", 1));//1 significa que la casilla contiene un personaje
            _tablero.Add(new ClsCasilla("/Assets/floor1.png", "/Assets/floor1dark.png", "/Assets/canina.gif", 4));//4 significa que la casilla contiene un alien 
        }
        #endregion
    }
}
