using AlienCompadre_Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AlienCompadre.Models
{
    public class ClsPlayer
    {
        private String _srcImage;
        private int _ammo;
        private ClsPunto _position;

        #region Constructores
        public ClsPlayer()
        {
            _srcImage = "/Assets/player.png";
            _ammo = 1;
            _position = new ClsPunto();
        }
        #endregion

        #region Propiedades Públicas
        public String SrcImage
        {
            get
            {
                return _srcImage;
            }
            set
            {
                _srcImage = value;
            }
        }

        public int Ammo
        {
            get
            {
                return _ammo;
            }
            set
            {
                _ammo = value;
            }
        }

        public ClsPunto Position
        {
            get
            {
                return _position;
            }
            set
            {
                _position = value;
            }
        }
        #endregion
    }
}
