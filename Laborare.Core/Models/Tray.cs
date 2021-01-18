namespace Laborare.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    public class Tray : INotifyPropertyChanged
    {
        /// <summary>
        /// Dynamic size dictionary of positions. This is where we will hold the position of each
        /// socket in the tray, which is calculated from the tray's 4 corners.
        /// 
        /// Why use ValueTuple instead of an array?
        /// Answer:
        /// An array as a key doesn't work as you're expecting. Array is a reference type, which
        /// means it will only find a key if it is the same instance, not if all elements have the same values. 
        /// 
        /// Format:
        /// 
        /// Position { row, col }: { x_pos, y_pos, zget_pos, zput_pos }
        /// </summary>
        private Dictionary<ValueTuple<int, int>, double[]> _Positions;

        /// <summary>
        /// Holds the values for each pocket during tuning.
        /// 
        /// Format:
        /// { x-position, y-position, zget-position, zput-position }
        /// </summary>
        private Dictionary<string, double[]> _Pockets;

        private int _Rows, _Cols;

        private int _VacuumOn_Delay, _VacuumOff_Delay, _AirblowOn_Delay, _AirblowOff_Delay, _ZPut_Delay;

        private string _TestSortResult;




        /// <summary>
        /// Initialize an instance of a tray for the first time (or reset?)
        /// </summary>
        public Tray()
        {
            _Positions = new Dictionary<ValueTuple<int, int>, double[]>();
            _Pockets = new Dictionary<string, double[]>();
            _Pockets.Add("Top Left Pocket", new double[4]);
            _Pockets.Add("Top Right Pocket", new double[4]);
            _Pockets.Add("Bottom Left Pocket", new double[4]);
            _Pockets.Add("Bottom Right Pocket", new double[4]);

            _TestSortResult = "9";

            // test values
            VacuumOn_Delay = 333;
            VacuumOff_Delay = 110;
            AirblowOn_Delay = 32;
            AirblowOff_Delay = 10;
            ZPut_Delay = 23;
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

        public Dictionary<ValueTuple<int, int>, double[]> Positions
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

        public string TestSortResult
        {
            get
            {
                return _TestSortResult;
            }
            set
            {
                _TestSortResult = value;
                OnPropertyChanged("TestSortResult");
            }
        }


        #endregion

        public void CreateNewPositions()
        {
            for (int i = 1; i <= Rows; i++)
            {
                for (int j = 1; j <= Cols; j++)
                {
                    Positions.Add(new ValueTuple<int, int>(i, j), new double[4]);
                }
            }
        }

        /// <summary>
        /// FindPositionCoordinates function will take in the inputted row and column in order to find the exact
        /// position and return its coordinates.
        /// 
        /// Returns an array of doubles that are the positions' coordinates. 
        /// [ x_pos, y_pos, zget_pos, zput_pos ]
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        public double[] FindPositionCoordinates(int row, int col)
        {
            return Positions[new ValueTuple<int, int>(row, col)]; 
        }

        public void CalculatePositions()
        {
            double ColWidth, RowWidth;
            
            // 0 for the x position in array, 1 for the y position in array
            ColWidth = Math.Abs(Pockets["Top Left Pocket"][0] - Pockets["Top Right Pocket"][0]) / Cols;
            RowWidth = Math.Abs(Pockets["Top Left Pocket"][1] - Pockets["Bottom Left Pocket"][1]) / Rows;

            for (int i = 1; i <= Rows; i++)
            {
                for (int j = 1; j <= Cols; j++) 
                {
                    ValueTuple<int, int> cur_pos = new ValueTuple<int, int>(i, j);

                    double x_pos = Pockets["Top Left Pocket"][0] - (j * ColWidth);
                    double y_pos = Pockets["Top Left Pocket"][1] + (i * RowWidth);

                    double slope1 = (Pockets["Top Right Pocket"][1] - Pockets["Top Left Pocket"][1]) / (Pockets["Top Right Pocket"][0] - Pockets["Top Left Pocket"][0]);
                    double slope2 = (Pockets["Bottom Left Pocket"][1] - Pockets["Top Left Pocket"][1]) / (Pockets["Bottom Left Pocket"][0] - Pockets["Top Left Pocket"][0]);
                    
                    double x_final = ((y_pos - Pockets["Top Left Pocket"][1]) / slope2) + x_pos;
                    double y_final = (slope1 * (x_pos - Pockets["Top Left Pocket"][0])) + y_pos;

                    Positions[cur_pos][0] = x_final;
                    Positions[cur_pos][1] = y_final;
                    // since zget and zput are always the same, we dont need to calculate
                    Positions[cur_pos][2] = Pockets["Top Right Pocket"][2];
                    Positions[cur_pos][3] = Pockets["Top Right Pocket"][3];
                }
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
