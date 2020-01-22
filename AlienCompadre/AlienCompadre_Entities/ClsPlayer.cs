using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AlienCompadre.Models
{
    public class ClsPlayer : INotifyPropertyChanged
    {
        private String _srcImage;
        private int _ammo;

        #region Constructores
        public ClsPlayer()
        {
            _srcImage = "DireccionImagen";
            _ammo = 0;
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
                NotifyPropertyChanged("SrcImage");
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
                NotifyPropertyChanged("Ammo");
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
    }
}
