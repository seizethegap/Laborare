namespace Laborare.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Input;

    using Laborare.Commands.ViewModelCommands.MotorConfigurationCommands;
    using Laborare.Models;
    using Laborare.Services;

    public class MotorConfigurationViewModel : INotifyPropertyChanged
    {
        public MotorConfigurationViewModel()
        {
            EnableMotorCommand = new EnableMotorCommand(this);
            DisableMotorCommand = new DisableMotorCommand(this);
            HomeMotorCommand = new HomeMotorCommand(this);
        }

        private string _SelectedMotor;
        
        private string _MotorStatus;

        private double _Position;

        private IAxisMotor _CurrentMotor;

        public Dictionary<string, IAxisMotor> Motors
        {
            get
            {
                return MainHandlerService.AxisMotors;
            }
            set
            {
                MainHandlerService.AxisMotors = value;
                // relay to the ui that our list of motors have changed
                OnPropertyChanged("Motors");
            }
        }

        #region Binding variables
        public string SelectedMotor
        {
            get 
            {
                return _SelectedMotor;
            }
            set
            {
                _SelectedMotor = value;
                _CurrentMotor = Motors[_SelectedMotor];
                _CurrentMotor.PropertyChanged += CurrentMotor_PropertyChanged;
                SynchronizeMotorProperty();
            }
        }

        public double Position
        {
            get
            {
                return _Position;
            }
            set
            {
                if (value != _Position)
                {
                    _Position = value;
                    OnPropertyChanged("Position");
                }
            }
        }

        public string MotorStatus
        {
            get
            {
                return _MotorStatus;
            }

            set
            {
                if (value != _MotorStatus)
                {
                    _MotorStatus = value;
                    OnPropertyChanged("MotorStatus");
                }
            }
        }

        #endregion

        public ICommand EnableMotorCommand
        {
            get;
            private set;
        }

        public ICommand DisableMotorCommand
        {
            get;
            private set;
        }

        public ICommand HomeMotorCommand
        {
            get;
            private set;
        }

        public void EnableMotor()
        {
            _CurrentMotor.EnableMotor();
        }

        public void DisableMotor()
        {
            _CurrentMotor.DisableMotor();
        }

        public void HomeMotor()
        {
            _CurrentMotor.HomeMotor();
        }

        public void SynchronizeMotorProperty()
        {
            MotorStatus = _CurrentMotor.MotorStatus;
            Position = _CurrentMotor.Position;
        }

        /// <summary>
        /// this monitors all properties that are binded to onpropertychanged in our
        /// _CurrentMotor model. the model will notify this viewmodel when a property is changed
        /// and the viewmodel will update to the ui
        /// </summary>

        private void CurrentMotor_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                // if the MotorStatus property in current motor changes, this view model will be notified
                case "MotorStatus":
                    MotorStatus = _CurrentMotor.MotorStatus;
                    break;

                case "Position":
                    Position = _CurrentMotor.Position;
                    break;
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
