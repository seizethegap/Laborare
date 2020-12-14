namespace Laborare.Commands.CommandProcessor
{
    public class CM1CommandProcessor : IAxisMotorCommandProcessor
    {
        public string CHECK_HOME_SENSOR_COMMAND(int uId)
        {
            return "?70." + uId.ToString();
        } 
        public string SEND_ACCELERATION_COMMAND(int uId, double acceleration)
        {
            return "A." + uId.ToString() + "=" + acceleration.ToString();
        }

        public string SEND_VELOCITY_COMMAND(int uId, double velocity)
        {
            return "S." + uId.ToString() + "=" + velocity.ToString();
        }

        public string SEND_DECELERATION_COMMAND(int uId, double deceleration)
        {
            return "K44." + uId.ToString() + "=" + deceleration.ToString();
        }

        public string SEND_MOTOR_HOME_COMMAND(int uId)
        {
            return "|." + uId.ToString();
        }

        public string SET_MOTOR_POSITION_TO_ZERO_COMMAND(int uId)
        {
            return "|2." + uId.ToString();
        }

        public string ENABLE_MOTOR_COMMAND(int uId)
        {
            return "(." + uId.ToString();
        }
        
        public string DISABLE_MOTOR_COMMAND(int uId)
        {
            return ")." + uId.ToString();
        }

        public string READ_MOTOR_ENCODER_COMMAND(int uId)
        {
            return "?96." + uId.ToString();
        }

        public string SEND_POSITION_COMMAND(int uId, long position)
        {
            return "P." + uId.ToString() + "=" + position.ToString() + ", ^." + uId.ToString();
        }

        public string CHECK_MOTOR_STATUS_COMMAND(int uId)
        {
            return "?99." + uId.ToString();
        }







        public string MOTOR_HOME_TRUE_MESSAGE(int uId)
        {
            return "IN." + uId.ToString() + "=04";
        }

        public string MOTOR_ENABLED_MESSAGE(int uId)
        {
            return "Ux." + uId.ToString() + "=8";
        }

        public string MOTOR_DISABLED_MESSAGE(int uId)
        {
            return "Ux." + uId.ToString() + "=16";
        }

        public string MOTOR_POSITION_MESSAGE(int uId)
        {
            return "Px." + uId.ToString();
        }
    }
}
