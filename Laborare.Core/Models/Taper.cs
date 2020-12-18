namespace Laborare.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using System.ComponentModel;

    public class Taper : INotifyPropertyChanged
    {
        public Taper()
        {
            XPosition = 0.0;
            YPosition = 0.0;
            ZGetPosition = 0.0;
            ZPutPosition = 0.0;
        }

        private double _XPosition;
        private double _YPosition;
        private double _ZGetPosition;
        private double _ZPutPosition;

        private string _TestSortResult;

        /// <summary>
        /// Tape and Reel Options in the TaperConfigurationView
        /// </summary>
        private bool _EnableTaperVacuum, _EnableRedRingLight, _EnableTaperVibration, _EnableTapeInspection,
            _EnableFreeFallDrop, _EnableZNozzleVacuum, _EnableSealHeadDown;
        private int _TapeRotationDegrees, _NumOfPocketsBeforeCheckingDevices, _TotalTapeCount;

        /// <summary>
        /// Part of Taper Temperature Fine Tune in TaperConfigurationView
        /// </summary>
        private int _SealHeadDownDelay;

        /// <summary>
        /// Reel Tuning in TaperConfigurationView
        /// </summary>
        private int _GapOffset, _LeaderCount, _TrailerCount, _TakeUpMotorCount, _NumberOfHolesBetweenPockets,
            _NumberOfPocketsBeforeTimeout;

        private int _TapeInspectionJob;


        #region Binding variables

        public int GapOffset
        {
            get
            {
                return _GapOffset;
            }
            set
            {
                _GapOffset = value;
                OnPropertyChanged("GapOffset");
            }
        }

        public int SealHeadDownDelay
        {
            get
            {
                return _SealHeadDownDelay;
            }
            set
            {
                _SealHeadDownDelay = value;
                OnPropertyChanged("SealHeadDownDelay");
            }
        }

        public int TotalTapeCount
        {
            get
            {
                return _TotalTapeCount;
            }
            set
            {
                _TotalTapeCount = value;
                OnPropertyChanged("TotalTapeCount");
            }
        }

        public int NumOfPocketsBeforeCheckingDevices
        {
            get
            {
                return _NumOfPocketsBeforeCheckingDevices;
            }
            set
            {
                _NumOfPocketsBeforeCheckingDevices = value;
                OnPropertyChanged("NumOfPocketsBeforeCheckingDevices");
            }
        }

        public int TapeRotationDegrees
        {
            get
            {
                return _TapeRotationDegrees;
            }
            set
            {
                _TapeRotationDegrees = value;
                OnPropertyChanged("TapeRotationDegrees");
            }
        }

        public bool EnableSealHeadDown
        {
            get
            {
                return _EnableSealHeadDown;
            }
            set
            {
                _EnableSealHeadDown = value;
                OnPropertyChanged("EnableSealHeadDown");
            }
        }

        public bool EnableZNozzleVacuum
        {
            get
            {
                return _EnableZNozzleVacuum;
            }
            set
            {
                _EnableZNozzleVacuum = value;
                OnPropertyChanged("EnableZNozzleVacuum");
            }
        }

        public bool EnableFreeFallDrop
        {
            get
            {
                return _EnableFreeFallDrop;
            }
            set
            {
                _EnableFreeFallDrop = value;
                OnPropertyChanged("EnableFreeFallDrop");
            }
        }

        public bool EnableTapeInspection
        {
            get
            {
                return _EnableTapeInspection;
            }
            set
            {
                _EnableTapeInspection = value;
                OnPropertyChanged("EnableTapeInspection");
            }
        }

        public bool EnableTaperVibration
        {
            get
            {
                return _EnableTaperVibration;
            }
            set
            {
                _EnableTaperVibration = value;
                OnPropertyChanged("EnableTaperVibration");
            }
        }

        public bool EnableRedRingLight
        {
            get
            {
                return _EnableRedRingLight;
            }
            set
            {
                _EnableRedRightLight = value;
                OnPropertyChanged("EnableRedRingLight");
            }
        }

        public bool EnableTaperVacuum
        {
            get
            {
                return _EnableTaperVacuum;
            }
            set
            {
                _EnableTaperVacuum = value;
                OnPropertyChanged("EnableTaperVacuum");
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
