namespace Laborare.Configuration
{
    using System.Configuration;

    public class IOLegendSignalCollection : ConfigurationElementCollection
    {
        public IOLegendSignalElement this[int index]
        {
            get
            {
                return (IOLegendSignalElement)BaseGet(index);
            }
            set
            {
                if (BaseGet(index) != null)
                    BaseRemoveAt(index);

                BaseAdd(index, value);
            }
        }

        public new IOLegendSignalElement this[string key]
        {
            get
            {
                return (IOLegendSignalElement)BaseGet(key);
            }
            set
            {
                if (BaseGet(key) != null)
                    BaseRemoveAt(BaseIndexOf(BaseGet(key)));

                BaseAdd(value);
            }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new IOLegendSignalElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((IOLegendSignalElement)element).Signal;
        }

    }
}
