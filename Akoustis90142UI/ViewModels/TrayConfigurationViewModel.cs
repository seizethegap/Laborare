namespace Akoustis90142UI.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.ComponentModel;
    using System.Windows.Input;

    using Laborare.Core.Models;
    using Laborare.Core.Services;

    using Akoustis90142UI.Commands.ViewModelCommands.TrayConfigurationCommands;

    public class TrayConfigurationViewModel : INotifyPropertyChanged
    {
        public TrayConfigurationViewModel()
        {
            _RowComboBox = new List<int>();
            _ColComboBox = new List<int>();

            ApplyNewRowColToTraysCommand = new ApplyNewRowColToTraysCommand(this);
        }

        // hold the combo box value selections
        private string _TrayTuning_SelectedTray;
        private string _TrayTuning_SelectedPosition;
        private string _Goto_SelectedTray;
        private string _Goto_SelectedRow;
        private string _Goto_SelectedCol;

        // current trays selected for tray tuning and move to tray position
        private Tray _TrayTuning_CurrentTray;
        private Tray _Goto_CurrentTray;

        private Dictionary<string, double[]> _Pockets;

        // hold the collection of numbers for the row and col combo boxes
        private List<int> _RowComboBox;
        private List<int> _ColComboBox;

        // tray tuning variables
        private double _X_Position, _Y_Position, _ZGet_Position, _ZPut_Position;

        // tray information variables
        private int _NumOfRows, _NumOfCols;

        public Dictionary<string, Tray> Trays
        {
            get
            {
                return MainHandlerService.ActiveTrays;
            }
            set
            {
                MainHandlerService.ActiveTrays = value;
                OnPropertyChanged("Trays");
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
                _Pockets = value;
                OnPropertyChanged("Pockets");
            }
        }

        public List<int> RowComboBox
        {
            get
            {
                return _RowComboBox;
            }
            set
            {
                _RowComboBox = value;
                OnPropertyChanged("RowComboBox");
            }
        }

        public List<int> ColComboBox
        {
            get
            {
                return _ColComboBox;
            }
            set
            {
                _ColComboBox = value;
                OnPropertyChanged("ColComboBox");
            }
        }

        #region Binding variables
        public string TrayTuning_SelectedTray
        {
            get
            {
                return _TrayTuning_SelectedTray;
            }
            set
            {
                _TrayTuning_SelectedTray = value;
                _TrayTuning_CurrentTray = Trays[_TrayTuning_SelectedTray];
                Pockets = _TrayTuning_CurrentTray.Pockets;
            }
        }

        public string TrayTuning_SelectedPosition
        {
            get
            {
                return _TrayTuning_SelectedPosition;
            }
            set
            {
                _TrayTuning_SelectedPosition = value;
                SynchronizeTrayPositions();
            }
        }

        public string Goto_SelectedTray
        {
            get
            {
                return _Goto_SelectedTray;
            }
            set
            {
                _Goto_SelectedTray = value;
                _Goto_CurrentTray = Trays[_Goto_SelectedTray];
                PopulateRowsList();
                PopulateColsList();
            }
        }

        public string Goto_SelectedRow
        {
            get
            {
                return _Goto_SelectedRow;
            }
            set
            {
                _Goto_SelectedRow = value;
                OnPropertyChanged("Goto_SelectedRow");
            }
        }

        public string Goto_SelectedCol
        {
            get
            {
                return _Goto_SelectedCol;
            }
            set
            {
                _Goto_SelectedCol = value;
                OnPropertyChanged("Goto_SelectedCol");
            }
        }

        public double X_Position
        {
            get
            {
                return _X_Position;
            }
            set
            {
                if (value != _X_Position)
                {
                    _X_Position = value;
                    OnPropertyChanged("X_Position");
                }
            }
        }

        public double Y_Position
        {
            get
            {
                return _Y_Position;
            }
            set
            {
                if (value != _Y_Position)
                {
                    _Y_Position = value;
                    OnPropertyChanged("Y_Position");
                }
            }
        }

        public double ZGet_Position
        {
            get
            {
                return _ZGet_Position;
            }
            set
            {
                if (value != _ZGet_Position)
                {
                    _ZGet_Position = value;
                    OnPropertyChanged("ZGet_Position");
                }
            }
        }

        public double ZPut_Position
        {
            get
            {
                return _ZPut_Position;
            }
            set
            {
                if (value != _ZPut_Position)
                {
                    _ZPut_Position = value;
                    OnPropertyChanged("ZPut_Position");
                }
            }
        }

        public int NumOfRows
        {
            get
            {
                return _NumOfRows;
            }
            set
            {
                _NumOfRows = value;
            }
        }

        public int NumOfCols
        {
            get
            {
                return _NumOfCols;
            }
            set
            {
                _NumOfCols = value;
            }
        }

        #endregion

        public ICommand ApplyNewRowColToTraysCommand
        {
            get;
            private set;
        }

        public void SynchronizeTrayPositions()
        {
            X_Position = Pockets[_TrayTuning_SelectedPosition][0];
            Y_Position = Pockets[_TrayTuning_SelectedPosition][1];
            ZGet_Position = Pockets[_TrayTuning_SelectedPosition][2];
            ZPut_Position = Pockets[_TrayTuning_SelectedPosition][3];
        }

        public void ApplyNewRowColToTrays()
        {
            foreach (var tray in Trays)
            {
                tray.Value.Rows = NumOfRows;
                tray.Value.Cols = NumOfCols;
                tray.Value.CreateNewPositions();
            }
        }

        public void PopulateRowsList()
        {
            // reset the list
            RowComboBox.Clear();

            NumOfRows = _Goto_CurrentTray.Rows;

            for (int i = 1; i <= NumOfRows; i++)
            {
                RowComboBox.Add(i);
            }
        }

        public void PopulateColsList()
        {
            ColComboBox.Clear();

            NumOfCols = _Goto_CurrentTray.Cols;

            for (int i = 1; i <= NumOfCols; i++)
            {
                ColComboBox.Add(i);
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
