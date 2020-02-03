using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienCompadre_Entities
{
    public class ClsCofre
    {
        private int _chestReward;
        private bool _open;

        #region Constructores
        public ClsCofre()
        {
            _chestReward = 0;
            _open = false;
        }

        public ClsCofre(int chestReward, bool open)
        {
            _chestReward = chestReward;
            _open = open;
        }
        #endregion

        #region Propiedades Públicas
        public int ChestReward
        {
            get
            {
                return _chestReward;
            }
            set
            {
                _chestReward = value;
            }
        }

        public bool Open
        {
            get
            {
                return _open;
            }
            set
            {
                _open = value;
            }
        }
        #endregion
    }
}
