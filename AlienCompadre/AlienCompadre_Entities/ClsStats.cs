using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AlienCompadre_Entities
{
    public class ClsStats : INotifyPropertyChanged
    {
        #region Propiedades privadas
        private String _name;
        private int _score;
        #endregion

        #region Constructores
        public ClsStats()
        {
            this._name = "";
            this._score = 0;
        }

        public ClsStats(string name, int score)
        {
            this._name = name;
            this._score = score;
        }
        #endregion

        #region Propiedades publicas
        public String Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                NotifyPropertyChanged("Name");
            }
        }

        public int Score
        {
            get
            {
                return _score;
            }
            set
            {
                _score = value;
                NotifyPropertyChanged("Score");
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

