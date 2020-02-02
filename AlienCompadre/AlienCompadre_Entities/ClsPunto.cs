using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AlienCompadre_Entities
{
    public class ClsPunto : INotifyPropertyChanged
    {
        private int x;
        private int y;

        #region Constructores
        public ClsPunto()
        {
            x = 0;
            y = 0;
        }

        public ClsPunto(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        #endregion

        #region Propiedades Públicas
        public int X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }

        public int Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }
        #endregion

        #region Métodos Sobreescritos
        public override bool Equals(Object obj)
        {
            bool ret = false;
            if (this == obj)
            {
                ret = true;
            }
            else
            {
                if (obj != null && typeof(ClsPunto).IsInstanceOfType(obj))
                {
                    ClsPunto punto = (ClsPunto)obj;
                    if (this.X == punto.X &&
                        this.Y == punto.Y)
                    {
                        ret = true;
                    }
                }
            }
            return ret;
        }

        #endregion

        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
