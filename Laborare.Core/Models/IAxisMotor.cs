namespace Laborare.Core.Models
{
    using Laborare.Core.Commands.CommandProcessor;
    using Laborare.Core.Services;

    using System.ComponentModel;

    public interface IAxisMotor
    {
        string Motor_Name { get; set; }
        IConnectionService Connection_Service { get; set; }
        IAxisMotorCommandProcessor Command_Processor { get; set; }
        double Position { get; set; }
        int Device_Id { get; set; }

        int Resolution { get; set; }
        string MotorStatus { get; set; }
        string HomeStatus { get; set; }

        void ReadEncoderPosition();

        void EnableMotor();

        void DisableMotor();

        void CheckMotorStatus();

        void HomeMotor();

        event PropertyChangedEventHandler PropertyChanged;
    }
}
