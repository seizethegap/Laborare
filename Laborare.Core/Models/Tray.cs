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
