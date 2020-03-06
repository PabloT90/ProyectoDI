using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AlienCompadre_Entities
{
    public class ClsCasilla : INotifyPropertyChanged
    {
        private String _lightImage;
        private String _darkImage;
        private String _characterImage;
        private int _rowObject;
        private ClsCofre _chest;

        #region Constructores
        public ClsCasilla()
        {
            _lightImage = "DEFAULT";
            _darkImage = "DEFAULT";
            _characterImage = "DEFAULT";
            _rowObject = 0;
            _chest = null;
        }

        public ClsCasilla(String srcFrontImage, String srcBackImage01, String srcBackImage02, int rowObject)
        {
            _lightImage = srcFrontImage;
            _darkImage = srcBackImage01;
            _characterImage = srcBackImage02;
            _rowObject = rowObject;
            _chest = null;
        }

        public ClsCasilla(String srcFrontImage, String srcBackImage01, String srcBackImage02, int rowObject, ClsCofre chest)
        {
            _lightImage = srcFrontImage;
            _darkImage = srcBackImage01;
            _characterImage = srcBackImage02;
            _rowObject = rowObject;
            _chest = chest;
        }

        #endregion

        #region Propiedades Públicas
        public String LightImage
        {
            get
            {
                return _lightImage;
            }
            set
            {
                _lightImage = value;
                NotifyPropertyChanged("LightImage");
            }
        }

        public String DarkImage
        {
            get
            {
                return _darkImage;
            }
            set
            {
                _darkImage = value;
                NotifyPropertyChanged("DarkImage");
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

        public ClsCofre Chest
        {
            get
            {
                return _chest;
            }
            set
            {
                _chest = value;
                NotifyPropertyChanged("Chest");
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
