namespace Laborare.Core.Models
{
    using System.ComponentModel;

    public class TestSocket : INotifyPropertyChanged
    {
        /// <summary>
        /// Initialize an instance of the TestSocket class for the first time.
        /// </summary>
        public TestSocket()
        {
            XPosition = 0.0;
            YPosition = 0.0; // usually we don't need to get y position for test socket but just for consistency sake
            ZGetPosition = 0.0;
            ZPutPosition = 0.0;
        }

        /// <summary>
        /// Initialize an instance of the TestSocket class after loading data from db
        /// </summary>
        public TestSocket(double x_pos, double zget_pos, double zput_pos)
        {
            XPosition = x_pos;
            ZGetPosition = zget_pos;
            ZPutPosition = zput_pos;
        }

        // Variables for Test Socket class
        private double _XPosition; // this is where x motor will have to move to
        private double _YPosition; // probably useless but may become useful later on if the test socket actually has y movement
        private double _ZGetPosition; // this is where z motor will move to in order to get the device from socket
        private double _ZPutPosition; // this is where z motor will move to in order to put the device into socket

        private int _VacuumOn_Delay, _VacuumOff_Delay, _AirblowOn_Delay, _AirblowOff_Delay, _ZPut_Delay;

        private bool _EnableFreeFallDrop, _EnableDoublePlunge;

        #region Binding variables
        public bool EnableFreeFallDrop
        {
            get
            {
                return _EnableFreeFallDrop;
            }
            set
            {
                if (value != _EnableFreeFallDrop)
                {
                    _EnableFreeFallDrop = value;
                    OnPropertyChanged("EnableFreeFallDrop");
                }
            }
        }

        public bool EnableDoublePlunge
        {
            get
            {
                return _EnableDoublePlunge;
            }
            set
            {
                if (value != _EnableDoublePlunge)
                {
                    _EnableDoublePlunge = value;
                    OnPropertyChanged("EnableDoublePlunge");
                }
            }
        }

        public double XPosition
        {
            get
            {
                return _XPosition;
            }
            set
            {
                _XPosition = value;
                OnPropertyChanged("XPosition");
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
                _YPosition = value;
                OnPropertyChanged("YPosition");
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
                _ZGetPosition = value;
                OnPropertyChanged("ZGetPosition");
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
                _ZPutPosition = value;
                OnPropertyChanged("ZPutPosition");
            }
        }

        public int VacuumOn_Delay
        {
            get
            {
                return _VacuumOn_Delay;
            }
            set
            {
                if (value != _VacuumOn_Delay)
                {
                    _VacuumOn_Delay = value;
                    OnPropertyChanged("VacuumOn_Delay");
                }
            }
        }

        public int VacuumOff_Delay
        {
            get
            {
                return _VacuumOff_Delay;
            }
            set
            {
                if (value != _VacuumOff_Delay)
                {
                    _VacuumOff_Delay = value;
                    OnPropertyChanged("VacuumOff_Delay");
                }
            }
        }

        public int AirblowOn_Delay
        {
            get
            {
                return _AirblowOn_Delay;
            }
            set
            {
                if (value != _AirblowOn_Delay)
                {
                    _AirblowOn_Delay = value;
                    OnPropertyChanged("AirblowOn_Delay");
                }
            }
        }

        public int AirblowOff_Delay
        {
            get
            {
                return _AirblowOff_Delay;
            }
            set
            {
                if (value != _AirblowOff_Delay)
                {
                    _AirblowOff_Delay = value;
                    OnPropertyChanged("AirblowOff_Delay");
                }
            }
        }

        public int ZPut_Delay
        {
            get
            {
                return _ZPut_Delay;
            }
            set
            {
                if (value != _ZPut_Delay)
                {
                    _ZPut_Delay = value;
                    OnPropertyChanged("ZPut_Delay");
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
