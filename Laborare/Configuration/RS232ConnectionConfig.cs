namespace Laborare.Configuration
{
    using System.Configuration;

    public class RS232ConnectionConfig : ConfigurationSection
    {
        // Create a property that lets us access the collection
        // of RS232ConnectionInstanceElements

        // Specifiy the name of the element used for the property
        [ConfigurationProperty("instances")]
        // Specify the type of elements found in the collection
        [ConfigurationCollection(typeof(RS232ConnectionInstanceCollection))]
        public RS232ConnectionInstanceCollection RS232ConnectionInstances
        {
            get
            {
                // Get the collection and parse it
                return (RS232ConnectionInstanceCollection)this["instances"];
            }
        }
    }
}
