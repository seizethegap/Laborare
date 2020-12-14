namespace Laborare.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    class Tray : INotifyPropertyChanged
    {
        /// <summary>
        /// Initialize an instance of a tray for the first time (or reset?)
        /// </summary>
        public Tray()
        {
            TopLeftPocket = new Dictionary<string, double>()
            {
                { "X-Position", 0.0 },
                { "Y-Position", 0.0 },
                { "ZGet-Position", 0.0 },
                { "ZPut-Position", 0.0 }
            };
            TopRightPocket = new Dictionary<string, double>()
            {
                { "X-Position", 0.0 },
                { "Y-Position", 0.0 },
                { "ZGet-Position", 0.0 },
                { "ZPut-Position", 0.0 }
            };
            BottomLeftPocket = new Dictionary<string, double>()
            {
                { "X-Position", 0.0 },
                { "Y-Position", 0.0 },
                { "ZGet-Position", 0.0 },
                { "ZPut-Position", 0.0 }
            };
            BottomRightPocket = new Dictionary<string, double>()
            {
                { "X-Position", 0.0 },
                { "Y-Position", 0.0 },
                { "ZGet-Position", 0.0 },
                { "ZPut-Position", 0.0 }
            };
        }

        /// <summary>
        /// Initialize an instance of a tray based on the data loaded from db.
        /// </summary>
        public Tray(Dictionary<string, double> top_left_pocket, Dictionary<string, double> top_right_pocket,
            Dictionary<string, double> bottom_left_pocket, Dictionary<string, double> bottom_right_pocket)
        {
            TopLeftPocket = top_left_pocket;
            TopRightPocket = top_right_pocket;
            BottomLeftPocket = bottom_left_pocket;
            BottomRightPocket = bottom_right_pocket;
        }

        // tray variables to keep track of
        private Dictionary<string, double> _TopLeftPocket;
        private Dictionary<string, double> _TopRightPocket;
        private Dictionary<string, double> _BottomLeftPocket;
        private Dictionary<string, double> _BottomRightPocket;

        #region Binding variables
        public Dictionary<string, double> TopLeftPocket
        {
            get
            {
                return _TopLeftPocket;
            }
            set
            {
                _TopLeftPocket = value;
                OnPropertyChanged("TopLeftPocket");
            }
        }

        public Dictionary<string, double> TopRightPocket
        {
            get
            {
                return _TopRightPocket;
            }
            set
            {
                _TopRightPocket = value;
                OnPropertyChanged("TopRightPocket");
            }
        }

        public Dictionary<string, double> BottomLeftPocket
        {
            get
            {
                return _BottomLeftPocket;
            }
            set
            {
                _BottomLeftPocket = value;
                OnPropertyChanged("BottomLeftPocket");
            }
        }

        public Dictionary<string, double> BottomRightPocket
        {
            get
            {
                return _BottomRightPocket;
            }
            set
            {
                _BottomRightPocket = value;
                OnPropertyChanged("BottomRightPocket");
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
