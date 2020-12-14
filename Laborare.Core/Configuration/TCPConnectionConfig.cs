namespace Laborare.Core.Configuration
{
    using System.Configuration;

    public class TCPConnectionConfig : ConfigurationSection
    {
        // Create a property that lets us access the collection
        // of TCPConnectionInstanceElements

        // Specifiy the name of the element used for the property
        [ConfigurationProperty("instances")]
        // Specify the type of elements found in the collection
        [ConfigurationCollection(typeof(TCPConnectionInstanceCollection))]
        public TCPConnectionInstanceCollection TCPConnectionInstances
        {
            get
            {
                // Get the collection and parse it
                return (TCPConnectionInstanceCollection)this["instances"];
            }
        }
    }
}
