namespace Laborare.Core.Configuration
{
    using System.Configuration;

    public class IOLegendConfig : ConfigurationSection
    {
        [ConfigurationProperty("legend")]
        [ConfigurationCollection(typeof(IOLegendSignalCollection))]
        public IOLegendSignalCollection IOLegendSignals
        {
            get
            {
                return (IOLegendSignalCollection)this["legend"];
            }
        }
    }
}
