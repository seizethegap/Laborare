namespace Laborare.Models
{
    using Laborare.Commands.CommandProcessor;
    using Laborare.Services;

    using System.ComponentModel;

    public interface IAxisMotor
    {
        string Motor_Name { get; set; }
        IConnectionService Connection_Service { get; set; }
        IAxisMotorCommandProcessor Command_Processor { get; set; }
        double Position { get; set; }
        int Device_Id { get; set; }
        string MotorStatus { get; set; }

        void ReadEncoderPosition();

        void EnableMotor();

        void DisableMotor();

        void CheckMotorStatus();

        event PropertyChangedEventHandler PropertyChanged;
    }
}
