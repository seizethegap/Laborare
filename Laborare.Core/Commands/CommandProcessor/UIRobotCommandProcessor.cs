namespace Laborare.Core.Commands.CommandProcessor
{
    class UIRobotCommandProcessor : IAxisMotorCommandProcessor
    {
        public string CHECK_HOME_SENSOR_COMMAND(int uId)
        {
            // UIRobot does not have a check home sensor command.
            return null;
        }
        public string SEND_ACCELERATION_COMMAND(int uId, double acceleration)
        {
            return ">ADR=" + uId.ToString() + ";>MACC=" + acceleration.ToString() + ";"; 
        }

        public string SEND_VELOCITY_COMMAND(int uId, double velocity)
        {
            return ">ADR=" + uId.ToString() + ";>SPD=" + velocity.ToString() + ";";
        }

        public string SEND_DECELERATION_COMMAND(int uId, double deceleration)
        {
            return ">ADR=" + uId.ToString() + ";>MDEC=" + deceleration.ToString() + ";";
        }

        public string SEND_MOTOR_HOME_COMMAND(int uId)
        {
            // UIRobot does not have implementation for this command
            return null;
        }

        public string SET_MOTOR_POSITION_TO_ZERO_COMMAND(int uId)
        {
            return "> ADR=" + uId.ToString() + ";> ORG;";
        }

        public string ENABLE_MOTOR_COMMAND(int uId)
        {
            return "> ADR=" + uId.ToString() + ";> ENA;";
        }

        public string DISABLE_MOTOR_COMMAND(int uId)
        {
            return "> ADR=" + uId.ToString() + ";> OFF;";
        }

        public string READ_MOTOR_ENCODER_COMMAND(int uId)
        {
            // UIRobot does not have implementation for this command
            return null;
        }

        public string SEND_POSITION_COMMAND(int uId, long position)
        {
            return "> ADR=" + uId.ToString() + ";> POS=" + position.ToString() + ";";
        }

        public string CHECK_MOTOR_STATUS_COMMAND(int uId)
        {
            return null;
        }

        public string MOTOR_HOME_TRUE_MESSAGE(int uId)
        {
            // UIRobot does not have implementation for this command
            return null;
        }

        public string MOTOR_HOME_FALSE_MESSAGE(int uId)
        {
            // UIRobot does not have implementation for this command
            return null;
        }

        public string MOTOR_ENABLED_MESSAGE(int uId)
        {
            return null;
        }

        public string MOTOR_DISABLED_MESSAGE(int uId)
        {
            return null;
        }

        public string MOTOR_POSITION_MESSAGE(int uId)
        {
            return null;
        }
    }
}
