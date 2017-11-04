using System.Configuration;

namespace ServizioWin.Infrastructure
{
    public class ValueElement : ConfigurationElement
    {
        [ConfigurationProperty("time", IsKey = true, IsRequired = true)]
        public string Time
        {
            get
            {
                return (string) this["time"];
            }
        }
    }

    public class ValueElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new ValueElement();
        }


        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ValueElement) element).Time;
        }
    }

    public class MultipleValuesSection : ConfigurationSection
    {
        [ConfigurationProperty("Times")]
        public ValueElementCollection Values
        {
            get
            {
                return (ValueElementCollection) this["Times"];
            }
        }
    }
}
