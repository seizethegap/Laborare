namespace Laborare.Core.Models
{
    using Laborare.Core.Commands.CommandProcessor;
    using Laborare.Core.Services;

    using System;
    using System.ComponentModel;

    class RMotor : IAxisMotor, INotifyPropertyChanged
    {
        public RMotor(string motor_name, int motor_id, int resolution, 
            IConnectionService connection_service, IAxisMotorCommandProcessor command_processor)
        {
            _MotorName = motor_name;
            _MotorId = motor_id;
            _Resolution = resolution;
            _Connection_Service = connection_service;
            _Command_Processor = command_processor;
            _MotorStatus = "N/A";


        }

        #region R Motor Variables
        private IConnectionService _Connection_Service;
        private IAxisMotorCommandProcessor _Command_Processor;
        private string _MotorName;

        private int _MotorId;

        private string _MotorStatus;

        private string _HomeStatus;

        // operator input restraint so that motor does not go too far and hit hard stop
        private double _MaxDistance;

        // resolution to convert position from motor to inches
        private int _Resolution;

        // motor variables
        private double _Velocity;
        private double _Acceleration;
        private double _Deceleration;

        // motor position, should we parse the motor regularly to get the current position?
        private double _Position;


        #endregion

        #region Binding Variables to UI Element

        public IConnectionService Connection_Service
        {
            get
            {
                return _Connection_Service;
            }
            set
            {
                _Connection_Service = value;
            }
        }

        public IAxisMotorCommandProcessor Command_Processor
        {
            get
            {
                return _Command_Processor;
            }
            set
            {
                _Command_Processor = value;
            }
        }

        public string MotorStatus
        {
            get { return _MotorStatus; }
            set
            {
                if (value != _MotorStatus)
                {
                    _MotorStatus = value;
                    OnPropertyChanged("MotorStatus");
                } 
            }
        }

        public string HomeStatus
        {
            get { return _HomeStatus; }
            set
            {
                if (value != _HomeStatus)
                {
                    _HomeStatus = value;
                    OnPropertyChanged("HomeStatus");
                }
            }
        }

        public string Motor_Name
        {
            get
            {
                return _MotorName;
            }
            set
            {
                _MotorName = value;
            }
        }

        public int Device_Id
        {
            get { return _MotorId; }
            set
            {
                _MotorId = value;
            }
        }
        /// <summary>
        /// Motor parameter variables
        /// </summary>
        public double MaxDistance
        {
            get
            {
                return _MaxDistance;
            }
            set
            {
                _MaxDistance = value;
                OnPropertyChanged("MaxDistance");
            }
        }

        public double Acceleration
        {
            get
            {
                return _Acceleration;
            }
            set
            {
                _Acceleration = value;
                OnPropertyChanged("Acceleration");
            }
        }

        public int Resolution
        {
            get
            {
                return _Resolution;
            }
            set
            {
                _Resolution = value;
                OnPropertyChanged("Resolution");
            }
        }

        public double Velocity
        {
            get
            {
                return _Velocity;
            }
            set
            {
                _Velocity = value;
                OnPropertyChanged("Velocity");
            }
        }

        public double Deceleration
        {
            get
            {
                return _Deceleration;
            }
            set
            {
                _Deceleration = value;
                OnPropertyChanged("Deceleration");
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
                _Position = value;
                OnPropertyChanged("Position");
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

        public void ReadEncoderPosition()
        {
            // no encoder on R motor
        }

        public void EnableMotor()
        {
            Connection_Service.Send(Command_Processor.ENABLE_MOTOR_COMMAND(_MotorId));
        }

        public void DisableMotor()
        {
            Connection_Service.Send(Command_Processor.DISABLE_MOTOR_COMMAND(_MotorId));
        }

        public void HomeMotor()
        {
            Connection_Service.Send(Command_Processor.SEND_POSITION_COMMAND(_MotorId, 0));
        }

        public void CheckMotorStatus()
        {
            // no implementation
        }
    }
}
