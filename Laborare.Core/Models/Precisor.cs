namespace Laborare.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    public class Precisor : INotifyPropertyChanged
    {
        /// <summary>
        /// Initialize an instance of the Precisor object for the first time, or reset.
        /// </summary>
        public Precisor()
        {
            _XPosition = 0.0;
            _YPosition = 0.0;
            _ZGetPosition = 0.0;
            _ZPutPosition = 0.0;
        }

        /// <summary>
        /// Initialize an instance of the Precisor from data loaded from the db
        /// </summary>
        public Precisor(double x_pos, double y_pos, double zget_pos, double zput_pos)
        {
            _XPosition = x_pos;
            _YPosition = y_pos;
            _ZGetPosition = zget_pos;
            _ZPutPosition = zput_pos;
        }

        private double _XPosition;
        private double _YPosition;
        private double _ZGetPosition;
        private double _ZPutPosition;

        private int _VacuumOn_Delay, _VacuumOff_Delay, _AirblowOn_Delay, _AirblowOff_Delay, _ZPut_Delay;

        private bool _EnablePrecisorBeforeTestSite, _EnablePrecisorVacuum, _EnablePrecisorBeforeOutput;

        #region Binding variables
        public bool EnablePrecisorBeforeTestSite
        {
            get
            {
                return _EnablePrecisorBeforeTestSite;
            }
            set
            {
                _EnablePrecisorBeforeTestSite = value;
                OnPropertyChanged("EnablePrecisorBeforeTestSite");
            }
        }

        public bool EnablePrecisorVacuum
        {
            get
            {
                return _EnablePrecisorVacuum;
            }
            set
            {
                _EnablePrecisorVacuum = value;
                OnPropertyChanged("EnablePrecisorVacuum");
            }
        }

        public bool EnablePrecisorBeforeOutput
        {
            get
            {
                return _EnablePrecisorBeforeOutput;
            }
            set
            {
                _EnablePrecisorBeforeOutput = value;
                OnPropertyChanged("EnablePrecisorBeforeOutput");
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
