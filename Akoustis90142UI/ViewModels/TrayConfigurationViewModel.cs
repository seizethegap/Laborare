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

    using Akoustis90142UI.Commands.ViewModelCommands.TrayConfigurationCommands;

    public class TrayConfigurationViewModel : INotifyPropertyChanged
    {
        public TrayConfigurationViewModel()
        {
            _RowComboBox = new List<int>();
            _ColComboBox = new List<int>();

            ApplyNewRowColToTraysCommand = new ApplyNewRowColToTraysCommand(this);
            ReadMotorEncoderXYCommand = new ReadMotorEncoderXYCommand(this);
            ReadMotorEncoderZCommand = new ReadMotorEncoderZCommand(this);
            StopReadMotorEncoderCommand = new StopReadMotorEncoderCommand(this);
            SaveCoordinatesCommand = new SaveCoordinatesCommand(this);
            CalculateAllCoordinatesCommand = new CalculateAllCoordinatesCommand(this);
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

        private CancellationTokenSource CancelUpdatingPositions;

        // hold the collection of numbers for the row and col combo boxes
        private List<int> _RowComboBox;
        private List<int> _ColComboBox;

        // tray tuning variables
        private double _X_Position, _Y_Position, _ZGet_Position, _ZPut_Position;

        // tray information variables
        private int _NumOfRows, _NumOfCols;

        public Dictionary<string, IAxisMotor> Motors
        {
            get
            {
                return MainHandlerService.AxisMotors;
            }
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

        public ICommand ReadMotorEncoderXYCommand
        {
            get;
            private set;
        }

        public ICommand ReadMotorEncoderZCommand
        {
            get;
            private set;
        }

        public ICommand StopReadMotorEncoderCommand
        {
            get;
            private set;
        }

        public ICommand SaveCoordinatesCommand
        {
            get;
            private set;
        }

        public ICommand CalculateAllCoordinatesCommand
        {
            get;
            private set;
        }

        public void DisableAllMotors()
        {
            foreach (var motor in Motors)
            {
                motor.Value.DisableMotor();
            }
        }

        public void EnableAllMotors()
        {
            foreach (var motor in Motors)
            {
                motor.Value.EnableMotor();
            }
        }

        public void ReadMotorEncoderXY()
        {
            DisableAllMotors();

            Motors["x1_motor"].CurrentMotorPositionService.Start();
            Motors["y1_motor"].CurrentMotorPositionService.Start();

            StartUpdatingXYMotorPositionsToTrayPositions();
        }

        public void ReadMotorEncoderZ()
        {
            DisableAllMotors();

            Motors["z1_motor"].CurrentMotorPositionService.Start();

            StartUpdatingZMotorPositionsToTrayPositions();
        }

        public void StopReadMotorEncoder()
        {
            EnableAllMotors();

            // TODO: You need to handle this correctly, it will crash now because
            // it will crash because not all motors are running this service when it is stopped.
            try
            {
                Motors["x1_motor"].CurrentMotorPositionService.Stop();
                Motors["y1_motor"].CurrentMotorPositionService.Stop();
                Motors["z1_motor"].CurrentMotorPositionService.Stop();
            }
            catch (Exception er)
            {
                // in here means service never started.
            }

            CancelUpdatingMotorPositionsToTrayPositions();

        }

        public void StartUpdatingXYMotorPositionsToTrayPositions()
        {
            CancelUpdatingPositions = new CancellationTokenSource();

            var task = Task.Run(() =>
            {
                while (!CancelUpdatingPositions.Token.IsCancellationRequested)
                {
                    X_Position = Motors["x1_motor"].Position;
                    Y_Position = Motors["y1_motor"].Position;
                }
            }, CancelUpdatingPositions.Token);
        }

        public void StartUpdatingZMotorPositionsToTrayPositions()
        {
            CancelUpdatingPositions = new CancellationTokenSource();

            var task = Task.Run(() =>
            {
                while (!CancelUpdatingPositions.Token.IsCancellationRequested)
                {
                    ZGet_Position = Motors["z1_motor"].Position;
                    ZPut_Position = Motors["z1_motor"].Position - 0.10;
                }
            }, CancelUpdatingPositions.Token);
        }

        public void CancelUpdatingMotorPositionsToTrayPositions()
        {
            CancelUpdatingPositions.Cancel();
            CancelUpdatingPositions.Dispose();
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

        public void SaveCoordinates()
        {
            _TrayTuning_CurrentTray.Pockets[_TrayTuning_SelectedPosition][0] = X_Position;
            _TrayTuning_CurrentTray.Pockets[_TrayTuning_SelectedPosition][1] = Y_Position;
            _TrayTuning_CurrentTray.Pockets[_TrayTuning_SelectedPosition][2] = ZGet_Position;
            _TrayTuning_CurrentTray.Pockets[_TrayTuning_SelectedPosition][3] = ZPut_Position;
        }

        public void CalculateAllCoordinates()
        {
            _TrayTuning_CurrentTray.CalculatePositions();
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
