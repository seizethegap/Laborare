namespace Laborare.Configuration
{
    using System.Configuration;

    public class TCPConnectionInstanceCollection : ConfigurationElementCollection
    {
        // Create a property that lets us access an element in the 
        // collection with the int index of the element.
        public TCPConnectionInstanceElement this[int index]
        {
            get
            {
                // Gets the TCPConnectionInstanceElement at the specified 
                // index in the collection
                return (TCPConnectionInstanceElement)BaseGet(index);
            }
            set
            {
                // Check if a TCPConnectionInstanceElement exists at the 
                // specified index and delete it if it does
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }

                // Add the new TCPConnectionInstanceElement at the specified
                // index
                BaseAdd(index, value);
            }
        }

        // Create a property that lets us access an element in the 
        // collection with the name of the element
        public new TCPConnectionInstanceElement this[string key]
        {
            get
            {
                // Gets the TCPConnectionInstanceElement where the name
                // matches the string key specified
                return (TCPConnectionInstanceElement)BaseGet(key);
            }
            set
            {
                // Checks if a TCPConnectionInstanceElement exists with
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
            return new TCPConnectionInstanceElement();
        }

        // Method that must be overriden to get the key of a
        // specified element
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((TCPConnectionInstanceElement)element).Name;
        }
    }
}
