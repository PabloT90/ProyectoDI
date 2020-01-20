using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AlienCompadre_Entities
{
    public class ClsCasilla : INotifyPropertyChanged
    {
        private String _image;
        private int _rowObject;

        #region Constructores
        public ClsCasilla()
        {
            _image = "DEFAULT";
            _rowObject = 0;
        }

        public ClsCasilla(String srcImage, int rowObject)
        {
            _image = srcImage;
            _rowObject = rowObject;
        }
        #endregion

        #region Propiedades Públicas
        public String Image
        {
            get
            {
                return _image;
            }
            set
            {
                _image = value;
                NotifyPropertyChanged("Image");
            }
        }

        public int RowObject
        {
            get
            {
                return _rowObject;
            }
            set
            {
                _rowObject = value;
                NotifyPropertyChanged("RowObject");
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
