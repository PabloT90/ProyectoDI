using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AlienCompadre_Entities
{
    public class ClsAlien
    {
        private String _srcImage;
        private ClsPunto _position;

        #region Constructores
        public ClsAlien()
        {
            _srcImage = "/Assets/canina.gif";
            _position = new ClsPunto(7, 7);
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
