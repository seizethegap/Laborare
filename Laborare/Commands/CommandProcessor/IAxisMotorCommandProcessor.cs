namespace Laborare.Commands.CommandProcessor
{
    public interface IAxisMotorCommandProcessor
    {
        string CHECK_HOME_SENSOR_COMMAND(int uId);
        string SEND_ACCELERATION_COMMAND(int uId, double acceleration);
        string SEND_VELOCITY_COMMAND(int uId, double velocity);
        string SEND_DECELERATION_COMMAND(int uId, double deceleration);
        string SEND_MOTOR_HOME_COMMAND(int uId);
        string SET_MOTOR_POSITION_TO_ZERO_COMMAND(int uId);
        string ENABLE_MOTOR_COMMAND(int uId);
        string DISABLE_MOTOR_COMMAND(int uId);
        string READ_MOTOR_ENCODER_COMMAND(int uId);
        string SEND_POSITION_COMMAND(int uId, long position);
        string CHECK_MOTOR_STATUS_COMMAND(int uId);




        string MOTOR_HOME_TRUE_MESSAGE(int uId);
        string MOTOR_HOME_FALSE_MESSAGE(int uId);
        string MOTOR_ENABLED_MESSAGE(int uId);
        string MOTOR_DISABLED_MESSAGE(int uId);
        string MOTOR_POSITION_MESSAGE(int uId);
    }
}
