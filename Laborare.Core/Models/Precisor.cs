namespace Laborare.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    class Precisor : INotifyPropertyChanged
    {
        /// <summary>
        /// Initialize an instance of the Precisor object for the first time, or reset.
        /// </summary>
        public Precisor()
        {
            Precisor_XPosition = 0.0;
            Precisor_YPosition = 0.0;
            Precisor_ZGetPosition = 0.0;
            Precisor_ZPutPosition = 0.0;
        }

        /// <summary>
        /// Initialize an instance of the Precisor from data loaded from the db
        /// </summary>
        public Precisor(double x_pos, double y_pos, double zget_pos, double zput_pos)
        {
            Precisor_XPosition = x_pos;
            Precisor_YPosition = y_pos;
            Precisor_ZGetPosition = zget_pos;
            Precisor_ZPutPosition = zput_pos;
        }

        private double _XPosition;
        private double _YPosition;
        private double _ZGetPosition;
        private double _ZPutPosition;

        public double Precisor_XPosition
        {
            get
            {
                return _XPosition;
            }
            set
            {
                _XPosition = value;
                OnPropertyChanged("Precisor_XPosition");
            }
        }

        public double Precisor_YPosition
        {
            get
            {
                return _YPosition;
            }
            set
            {
                _YPosition = value;
                OnPropertyChanged("Precisor_YPosition");
            }
        }

        public double Precisor_ZGetPosition
        {
            get
            {
                return _ZGetPosition;
            }
            set
            {
                _ZGetPosition = value;
                OnPropertyChanged("Precisor_ZGetPosition");
            }
        }

        public double Precisor_ZPutPosition
        {
            get
            {
                return _ZPutPosition;
            }
            set
            {
                _ZPutPosition = value;
                OnPropertyChanged("Precisor_ZPutPosition");
            }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
