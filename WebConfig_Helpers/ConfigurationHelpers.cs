using System.Configuration;

namespace Re_useable_Classes.WebConfig_Helpers
{
    //Add the following to the web.config file to use

    //    <configSections>
    //    <section name="IPAddresses" type="Re_useable_Classes.WebConfig_Helpers.MultipleValuesSection" requirePermission="false" />
    //    </configSections>

    public class ValueElement : ConfigurationElement
    {
        [ConfigurationProperty("name", IsKey = true, IsRequired = true)]
        public string Name
        {
            get { return (string)this["name"]; }
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
            return ((ValueElement)element).Name;
        }
    }

    public class MultipleValuesSection : ConfigurationSection
    {
        [ConfigurationProperty("Values")]
        public ValueElementCollection Values
        {
            get { return (ValueElementCollection)this["Values"]; }
        }
    }
}