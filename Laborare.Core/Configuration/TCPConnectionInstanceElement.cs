namespace Laborare.Core.Configuration
{
    using System.Configuration;

    
    public class TCPConnectionInstanceElement : ConfigurationElement
    {
        // Create a property to store the name of the TCP Connection Instance
        // - The "name" identifys what this motor is on the handler
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

        // Create a property to store the server of the TCP Motor Instance
        // - The "ip" is stores the ip address of the motor
        // - The IsRequired setting specifies that a value is required
        [ConfigurationProperty("ip", IsRequired = true)]
        public string Ip_Address
        {
            get
            {
                return (string)base["ip"];
            }
            set
            {
                base["ip"] = value;
            }
        }

        // Create a property to store the server of the TCP Motor Instance
        // - The port is stores the port of the motor
        // - The IsRequired setting specifies that a value is required
        [ConfigurationProperty("port", IsRequired = true)]
        public int Port
        {
            get
            {
                return (int)base["port"];
            }
            set
            {
                base["port"] = value;
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
