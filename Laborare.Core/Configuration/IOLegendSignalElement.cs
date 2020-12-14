namespace Laborare.Core.Configuration
{
    using System.Configuration;

    public class IOLegendSignalElement : ConfigurationElement
    {
        [ConfigurationProperty("signal", IsKey = true, IsRequired = true)]
        public string Signal
        {
            get
            {
                return (string)base["signal"];
            }
            set
            {
                base["signal"] = value;
            }
        }

        [ConfigurationProperty("function", IsRequired = true)]
        public string Function
        {
            get
            {
                return (string)base["function"];
            }
            set
            {
                base["function"] = value;
            }
        }

        [ConfigurationProperty("desc", IsRequired = true)]
        public string Description
        {
            get
            {
                return (string)base["desc"];
            }
            set
            {
                base["desc"] = value;
            }
        }
    }
}
