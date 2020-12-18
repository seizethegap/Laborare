namespace Laborare.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Bucket : INotifyPropertyChanged
    {
        public Bucket()
        {
            _XPosition = 0.0;
            _YPosition = 0.0;
            _ZGetPosition = 0.0;
            _ZPutPosition = 0.0;

            // temporary random result
            _TestSortResult = "1,2,3,4,5";
        }

        private double _XPosition, _YPosition, _ZGetPosition, _ZPutPosition;

        private string _TestSortResult;

        #region Binding variables
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

        public string TestSortResult
        {
            get
            {
                return _TestSortResult;
            }
            set
            {
                if (value != _TestSortResult)
                {
                    _TestSortResult = value;
                    OnPropertyChanged("TestSortResult");
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
