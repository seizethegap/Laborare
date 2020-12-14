namespace Laborare.Services
{
    using Laborare.Models;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class CurrentMotorPositionService
    {
        private CancellationTokenSource CancelUpdatingMotorPosition;

        public CurrentMotorPositionService(IAxisMotor motor)
        {
            Motor = motor;
        }

        public IAxisMotor Motor { get; set; }

        public void Start()
        {
            CancelUpdatingMotorPosition = new CancellationTokenSource();

            var task = Task.Run(() =>
            {
                while (!CancelUpdatingMotorPosition.Token.IsCancellationRequested)
                {
                    Motor.ReadEncoderPosition();
                    Thread.Sleep(100);
                }

            }, CancelUpdatingMotorPosition.Token);
        }

        public void Stop()
        {
            CancelUpdatingMotorPosition.Cancel();
            CancelUpdatingMotorPosition.Dispose();
        }
    }
}
