namespace Laborare.Services
{
    using Laborare.Models;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class MessageDecoderService
    {
        private CancellationTokenSource CancelMessageDecoderService;

        public MessageDecoderService(IAxisMotor motor)
        {
            Motor = motor;
        }

        public IAxisMotor Motor { get; set; }

        public void Start()
        {
            CancelMessageDecoderService = new CancellationTokenSource();

            var task = Task.Run(() =>
            {
                while (!CancelMessageDecoderService.Token.IsCancellationRequested)
                {
                    string recieved = Motor.Connection_Service.ReceiveMessage();
                    // check if message is for motor position, if so update the motor position
                    if (recieved.Contains(Motor.Command_Processor.MOTOR_POSITION_MESSAGE(Motor.Device_Id)))
                    {
                        string[] splitMsg = recieved.Split('=');
                        Motor.Position = Convert.ToDouble(splitMsg[1]) / Motor.Resolution;
                    }
                    else if (recieved.Contains(Motor.Command_Processor.MOTOR_DISABLED_MESSAGE(Motor.Device_Id)))
                    {
                        Motor.MotorStatus = "Disabled";
                    }
                    else if (recieved.Contains(Motor.Command_Processor.MOTOR_ENABLED_MESSAGE(Motor.Device_Id)))
                    {
                        Motor.MotorStatus = "Enabled";
                    }
                    else if (recieved.Contains(Motor.Command_Processor.MOTOR_HOME_TRUE_MESSAGE(Motor.Device_Id)))
                    {
                        Motor.HomeStatus = "Home";
                    }
                    else if (recieved.Contains(Motor.Command_Processor.MOTOR_HOME_FALSE_MESSAGE(Motor.Device_Id)))
                    {
                        Motor.HomeStatus = "Not Home";
                    }
                }
            }, CancelMessageDecoderService.Token);
        }
    }
}
