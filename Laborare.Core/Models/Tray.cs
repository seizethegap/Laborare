namespace Laborare.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    public class Tray : INotifyPropertyChanged
    {
        /// <summary>
        /// Dynamic size list of positions. This is where we will hold the position of each
        /// socket in the tray, which is calculated from the tray's 4 corners.
        /// Format:
        /// Position n: { x_pos, y_pos, zget_pos, zput_pos }
        /// </summary>
        private List<double[]> _Positions;

        /// <summary>
        /// Holds the values for each pocket during tuning.
        /// 
        /// Format:
        /// { x-position, y-position, zget-position, zput-position }
        /// </summary>
        private Dictionary<string, double[]> _Pockets;

        private int _Rows, _Cols;

        private int _VacuumOn_Delay, _VacuumOff_Delay, _AirblowOn_Delay, _AirblowOff_Delay, _ZPut_Delay;




        /// <summary>
        /// Initialize an instance of a tray for the first time (or reset?)
        /// </summary>
        public Tray()
        {
            _Positions = new List<double[]>();
            _Pockets = new Dictionary<string, double[]>();
            _Pockets.Add("Top Left Pocket", new double[] 
            { 0.0, 0.0, 0.0, 0.0 });
            _Pockets.Add("Top Right Pocket", new double[]
            { 0.0, 0.0, 0.0, 0.0 });
            _Pockets.Add("Bottom Left Pocket", new double[]
            { 0.0, 0.0, 0.0, 0.0 });
            _Pockets.Add("Bottom Right Pocket", new double[]
            { 0.0, 0.0, 0.0, 0.0 });
        }

        #region Binding variables
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

        public List<double[]> Positions
        {
            get
            {
                return _Positions;
            }
            set
            {
                if (value != _Positions)
                {
                    _Positions = value;
                    OnPropertyChanged("Positions");
                }
            }
        }

        public Dictionary<string, double[]> Pockets
        {
            get
            {
                return _Pockets;
            }
            set
            {
                if (value != _Pockets)
                {
                    _Pockets = value;
                    OnPropertyChanged("Pockets");
                }
            }
        }

        public int Rows
        {
            get
            {
                return _Rows;
            }
            set
            {
                _Rows = value;
                OnPropertyChanged("Rows");
            }
        }

        public int Cols
        {
            get
            {
                return _Cols;
            }
            set
            {
                _Cols = value;
                OnPropertyChanged("Cols");
            }
        }

        #endregion

        public void CreateNewPositions()
        {
            for (int i = 0; i < Rows * Cols; i++)
            {
                // create 0 value positions on the tray
                Positions.Add(new double[] { 0.0, 0.0, 0.0, 0.0 });
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
