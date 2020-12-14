namespace Laborare.Configuration
{
    using System.Configuration;

    public class RS232ConnectionInstanceCollection : ConfigurationElementCollection
    {
        // Create a property that lets us access an element in the 
        // collection with the int index of the element.
        public RS232ConnectionInstanceElement this[int index]
        {
            get
            {
                // Gets the RS232ConnectionInstanceElement at the specified 
                // index in the collection
                return (RS232ConnectionInstanceElement)BaseGet(index);
            }
            set
            {
                // Check if a RS232ConnectionInstanceElement exists at the 
                // specified index and delete it if it does
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }

                // Add the new RS232ConnectionInstanceElement at the specified
                // index
                BaseAdd(index, value);
            }
        }

        // Create a property that lets us access an element in the 
        // collection with the name of the element
        public new RS232ConnectionInstanceElement this[string key]
        {
            get
            {
                // Gets the RS232ConnectionInstanceElement where the name
                // matches the string key specified
                return (RS232ConnectionInstanceElement)BaseGet(key);
            }
            set
            {
                // Checks if a RS232ConnectionInstanceElement exists with
                // the specified name and deletes it if it does
                if (BaseGet(key) != null)
                    BaseRemoveAt(BaseIndexOf(BaseGet(key)));

                // Adds the new SageCRMInstanceElement
                BaseAdd(value);
            }
        }

        // Method that must be overriden to create a new element
        // that can be stored in the collection
        protected override ConfigurationElement CreateNewElement()
        {
            return new RS232ConnectionInstanceElement();
        }

        // Method that must be overriden to get the key of a
        // specified element
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((RS232ConnectionInstanceElement)element).Name;
        }
    }
}
