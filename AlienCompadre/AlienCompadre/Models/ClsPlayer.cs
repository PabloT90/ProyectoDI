using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienCompadre.Models
{
    public class ClsPlayer
    {
        private String _srcImage;
        private int _ammo;

        #region Constructores
        public String SrcImage {
            get
            {
                return _srcImage;
            }
            set
            {
                _srcImage = value;
            }
        }
        #endregion
    }
}
