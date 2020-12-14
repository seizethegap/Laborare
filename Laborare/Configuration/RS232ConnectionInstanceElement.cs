namespace Laborare.Configuration
{
    using System.Configuration;

    public class RS232ConnectionInstanceElement : ConfigurationElement
    {
        // Create a property to store the name of the RS-232 Instance
        // - The "name" identifys what this device is is on the handler
        // - The IsKey setting specifies that this field is used to identify
        //   element uniquely
        // - The IsRequired setting specifies that a value is required
        [ConfigurationProperty("name", IsKey = true, IsRequired = true)]
        public string Name
        {
            get
            {
                return (string)base["name"];
            }

            set
            {
                base["name"] = value;
            }
        }

        // Create a property to store the port name of the RS-232 Instance
        // - The "port_name" is stores the port name of the motor
        // - The IsRequired setting specifies that a value is required
        [ConfigurationProperty("port_name", IsRequired = true)]
        public string Port_Name
        {
            get
            {
                return (string)base["port_name"];
            }
            set
            {
                base["port_name"] = value;
            }
        }

        // Create a property to store the baud rate of the RS-232 instance
        // - The "baud_rate" is stores the baud rate of the motor
        // - The IsRequired setting specifies that a value is required
        [ConfigurationProperty("baud_rate", IsRequired = true)]
        public int Baud_Rate
        {
            get
            {
                return (int)base["baud_rate"];
            }
            set
            {
                base["baud_rate"] = value;
            }
        }

        [ConfigurationProperty("databits", IsRequired = true)]
        public int Databits
        {
            get
            {
                return (int)base["databits"];
            }
            set
            {
                base["databits"] = value;
            }
        }

        [ConfigurationProperty("read_timeout", IsRequired = true)]
        public int Read_Timeout
        {
            get
            {
                return (int)base["read_timeout"];
            }
            set
            {
                base["read_timeout"] = value;
            }
        }

        [ConfigurationProperty("write_timeout", IsRequired = true)]
        public int Write_Timeout
        {
            get
            {
                return (int)base["write_timeout"];
            }
            set
            {
                base["write_timeout"] = value;
            }
        }

        [ConfigurationProperty("type", IsRequired = false)]
        public string Type
        {
            get
            {
                return (string)base["type"];
            }
            set
            {
                base["type"] = value;
            }
        }

        [ConfigurationProperty("uid", IsRequired = true)]
        public int Device_Id
        {
            get
            {
                return (int)base["uid"];
            }
            set
            {
                base["uid"] = value;
            }
        }

        [ConfigurationProperty("resolution", IsRequired = false)]
        public int Resolution
        {
            get
            {
                return (int)base["resolution"];
            }
            set
            {
                base["resolution"] = value;
            }
        }
    }
}
