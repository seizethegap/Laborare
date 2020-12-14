namespace Laborare.Models
{
    using System.ComponentModel;

    class TestSocket : INotifyPropertyChanged
    {
        /// <summary>
        /// Initialize an instance of the TestSocket class for the first time.
        /// </summary>
        public TestSocket()
        {
            TS_XPosition = 0.0;
            TS_YPosition = 0.0; // usually we don't need to get y position for test socket but just for consistency sake
            TS_ZGetPosition = 0.0;
            TS_ZPutPosition = 0.0;
        }

        /// <summary>
        /// Initialize an instance of the TestSocket class after loading data from db
        /// </summary>
        public TestSocket(double x_pos, double zget_pos, double zput_pos)
        {
            TS_XPosition = x_pos;
            TS_ZGetPosition = zget_pos;
            TS_ZPutPosition = zput_pos;
        }

        // Variables for Test Socket class
        private double _XPosition; // this is where x motor will have to move to
        private double _YPosition; // probably useless but may become useful later on if the test socket actually has y movement
        private double _ZGetPosition; // this is where z motor will move to in order to get the device from socket
        private double _ZPutPosition; // this is where z motor will move to in order to put the device into socket

        #region Binding variables
        public double TS_XPosition
        {
            get
            {
                return _XPosition;
            }
            set
            {
                _XPosition = value;
                OnPropertyChanged("TS_XPosition");
            }
        }

        public double TS_YPosition
        {
            get
            {
                return _YPosition;
            }
            set
            {
                _YPosition = value;
                OnPropertyChanged("TS_YPosition");
            }
        }

        public double TS_ZGetPosition
        {
            get
            {
                return _ZGetPosition;
            }
            set
            {
                _ZGetPosition = value;
                OnPropertyChanged("TS_ZGetPosition");
            }
        }

        public double TS_ZPutPosition
        {
            get
            {
                return _ZPutPosition;
            }
            set
            {
                _ZPutPosition = value;
                OnPropertyChanged("TS_ZPutPosition");
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
