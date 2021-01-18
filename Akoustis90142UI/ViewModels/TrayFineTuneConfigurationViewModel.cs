namespace Akoustis90142UI.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.ComponentModel;
    using System.Windows.Input;

    using Laborare.Core.Models;
    using Laborare.Core.Services;

    using Akoustis90142UI.Commands.ViewModelCommands.TrayFineTuneConfigurationCommands;

    public class TrayFineTuneConfigurationViewModel : INotifyPropertyChanged
    {
        public TrayFineTuneConfigurationViewModel()
        {
            _RowComboBox = new List<int>();
            _ColComboBox = new List<int>();

            ReadCoordinatesCommand = new ReadCoordinatesCommand(this);
            SaveCoordinatesCommand = new SaveCoordinatesCommand(this);
        }

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

        private string _FineTune_SelectedTray;
        private Tray _FineTune_CurrentTray;

        private int _SelectedRow, _SelectedCol;

        private List<int> _RowComboBox, _ColComboBox;

        private double _X_Position, _Y_Position, _ZGet_Position, _ZPut_Position;

        #region Binding Variables
        public string FineTune_SelectedTray
        {
            get
            {
                return _FineTune_SelectedTray;
            }
            set
            {
                _FineTune_SelectedTray = value;
                _FineTune_CurrentTray = Trays[value];
                PopulateRowsList();
                PopulateColsList();
            }
        }

        public Tray FineTune_CurrentTray
        {
            get
            {
                return _FineTune_CurrentTray;
            }
            set
            {
                if (value != _FineTune_CurrentTray)
                {
                    _FineTune_CurrentTray = value;
                    OnPropertyChanged("FineTune_CurrentTray");
                }
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

        public int SelectedRow
        {
            get
            {
                return _SelectedRow;
            }
            set
            {
                _SelectedRow = value;
                OnPropertyChanged("SelectedRow");
            }
        }

        public int SelectedCol
        {
            get
            {
                return _SelectedCol;
            }
            set
            {
                _SelectedCol = value;
                OnPropertyChanged("SelectedCol");
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

        #endregion

        public ICommand ReadCoordinatesCommand
        {
            get;
            private set;
        }

        public ICommand SaveCoordinatesCommand
        {
            get;
            private set;
        }

        public void PopulateRowsList()
        {
            // reset the list
            RowComboBox.Clear();

            for (int i = 1; i <= _FineTune_CurrentTray.Rows; i++)
            {
                RowComboBox.Add(i);
            }
        }

        public void PopulateColsList()
        {
            ColComboBox.Clear();

            for (int i = 1; i <= _FineTune_CurrentTray.Cols; i++)
            {
                ColComboBox.Add(i);
            }
        }

        public void ReadCoordinates()
        {
            double[] coordinates = FineTune_CurrentTray.FindPositionCoordinates(SelectedRow, SelectedCol);

            X_Position = coordinates[0];
            Y_Position = coordinates[1];
            ZGet_Position = coordinates[2];
            ZPut_Position = coordinates[3];
        }

        public void SaveCoordinates()
        {
            ValueTuple<int, int> cur_pos = new ValueTuple<int, int>(SelectedRow, SelectedCol);

            FineTune_CurrentTray.Positions[cur_pos][0] = X_Position;
            FineTune_CurrentTray.Positions[cur_pos][1] = Y_Position;
            FineTune_CurrentTray.Positions[cur_pos][2] = ZGet_Position;
            FineTune_CurrentTray.Positions[cur_pos][3] = ZPut_Position;
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
