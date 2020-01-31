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
        private String _hideImage;
        private String _shownImage;
        private String _characterImage;
        private int _rowObject;

        #region Constructores
        public ClsCasilla()
        {
            _hideImage = "DEFAULT";
            _shownImage = "DEFAULT";
            _characterImage = "DEFAULT";
            _rowObject = 0;
        }

        public ClsCasilla(String srcFrontImage, String srcBackImage01, String srcBackImage02, int rowObject)
        {
            _hideImage = srcFrontImage;
            _shownImage = srcBackImage01;
            _characterImage = srcBackImage02;
            _rowObject = rowObject;
        }
        #endregion

        #region Propiedades Públicas
        public String HideImage
        {
            get
            {
                return _hideImage;
            }
            set
            {
                _hideImage = value;
                NotifyPropertyChanged("HideImage");
            }
        }

        public String ShownImage
        {
            get
            {
                return _shownImage;
            }
            set
            {
                _shownImage = value;
                NotifyPropertyChanged("ShownImage");
            }
        }

        public String CharacterImage
        {
            get
            {
                return _characterImage;
            }
            set
            {
                _characterImage = value;
                NotifyPropertyChanged("CharacterImage");
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
