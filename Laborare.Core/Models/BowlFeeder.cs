namespace Laborare.Core.Models
{
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class BowlFeeder : INotifyPropertyChanged
    {
        public BowlFeeder()
        {
            _XPosition = 0.0;
            _YPosition = 0.0;
            _ZGetPosition = 0.0;
            _ZPutPosition = 0.0;
        }

        public BowlFeeder(int x_pos, int y_pos, int zget_pos, int zput_pos)
        {
            _XPosition = x_pos;
            _YPosition = y_pos;
            _ZGetPosition = zget_pos;
            _ZPutPosition = zput_pos;
        }

        private double _XPosition, _YPosition, _ZGetPosition, _ZPutPosition;

        #region Binding Variable
        public double XPosition
        {
            get
            {
                return _XPosition;
            }
            set
            {
                if (value != _XPosition)
                {
                    _XPosition = value;
                    OnPropertyChanged("XPosition");
                }
            }
        }

        public double YPosition
        {
            get
            {
                return _YPosition;
            }
            set
            {
                if (value != _YPosition)
                {
                    _YPosition = value;
                    OnPropertyChanged("YPosition");
                }
            }
        }

        public double ZGetPosition
        {
            get
            {
                return _ZGetPosition;
            }
            set
            {
                if (value != _ZGetPosition)
                {
                    _ZGetPosition = value;
                    OnPropertyChanged("ZGetPosition");
                }
            }
        }

        public double ZPutPosition
        {
            get
            {
                return _ZPutPosition;
            }
            set
            {
                if (value != _ZPutPosition)
                {
                    _ZPutPosition = value;
                    OnPropertyChanged("ZPutPosition");
                }
            }
        }
        #endregion

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
