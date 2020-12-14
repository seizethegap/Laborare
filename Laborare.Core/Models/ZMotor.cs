namespace Laborare.Core.Models
{
    using Laborare.Core.Commands.CommandProcessor;
    using Laborare.Core.Services;

    using System;
    using System.ComponentModel;
    using System.Threading;

    class ZMotor : IAxisMotor, INotifyPropertyChanged
    {
        public ZMotor(string motor_name, int motor_id, int resolution,
            IConnectionService connection_service, IAxisMotorCommandProcessor command_processor)
        {
            _Motor_Name = motor_name;
            _MotorId = motor_id;
            _Resolution = resolution;
            _Connection_Service = connection_service;
            _Command_Processor = command_processor;

            CheckMotorStatus();

            _MessageDecoderService = new MessageDecoderService(this);
        }

        #region Z Motor Variables
        private IConnectionService _Connection_Service;
        private IAxisMotorCommandProcessor _Command_Processor;

        private MessageDecoderService _MessageDecoderService;

        private string _Motor_Name;
        private int _MotorId;

        // operator input restraint so that motor does not go too far and hit hard stop
        private double _MaxDistance;

        private string _MotorStatus;

        private string _HomeStatus;

        // resolution to convert position from motor to inches
        private int _Resolution;

        // motor variables
        private double _Velocity;
        private double _Acceleration;
        private double _Deceleration;

        // motor position, should we parse the motor regularly to get the current position?
        private double _Position;

        private bool _VacuumStatus;

        #endregion

        #region Binding Variables to UI Element
        public string Motor_Name
        {
            get { return _Motor_Name; }
            set
            {
                _Motor_Name = value;
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

        public string MotorStatus
        {
            get { return _MotorStatus; }
            set
            {
                _MotorStatus = value;
                OnPropertyChanged("MotorStatus");
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

        public bool VacuumStatus
        {
            get
            {
                return _VacuumStatus;
            }
            set
            {
                _VacuumStatus = value;
                OnPropertyChanged("VacuumStatus");
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
            Connection_Service.Send(Command_Processor.READ_MOTOR_ENCODER_COMMAND(_MotorId));
            string recieved = Connection_Service.ReceiveMessage();
            if (recieved.Contains(Command_Processor.MOTOR_POSITION_MESSAGE(_MotorId)))
            {
                string[] splitMsg = recieved.Split('=');
                Position = Convert.ToDouble(splitMsg[1]) / Resolution;
            }
        }

        public void EnableMotor()
        {
            Connection_Service.Send(Command_Processor.ENABLE_MOTOR_COMMAND(_MotorId));
            CheckMotorStatus();
        }

        public void DisableMotor()
        {
            Connection_Service.Send(Command_Processor.DISABLE_MOTOR_COMMAND(_MotorId));
            CheckMotorStatus();
        }

        public void HomeMotor()
        {
            Connection_Service.Send(Command_Processor.SEND_MOTOR_HOME_COMMAND(_MotorId));
        }

        public void CheckMotorStatus()
        {
            Connection_Service.Send(Command_Processor.CHECK_MOTOR_STATUS_COMMAND(_MotorId));
            string received = Connection_Service.ReceiveMessage();
            if (received.Contains(Command_Processor.MOTOR_ENABLED_MESSAGE(_MotorId)))
            {
                MotorStatus = "Enabled";
            }
            else if (received.Contains(Command_Processor.MOTOR_DISABLED_MESSAGE(_MotorId)))
            {
                MotorStatus = "Disabled";
            }
        }
    }
}
