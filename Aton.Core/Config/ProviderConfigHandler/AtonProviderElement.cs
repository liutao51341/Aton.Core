using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;

namespace Aton.Core.Config.ProviderConfigHandler
{
    /// <summary>
    /// 服务元素
    /// </summary>
    class AtonProvider : ConfigurationElement
    {
        public AtonProvider() { }
        public AtonProvider(string name,string ver,string desc, string type)
        {
            base["Name"] = name;
            base["Ver"] = ver;
            base["Desc"] = desc;
            base["Type"] = type;
        }

        [ConfigurationProperty("Name", IsRequired = true)]
        public string Name
        {
            get { return (string)base["Name"]; }
            set { base["Name"] = value; }
        }

        [ConfigurationProperty("Ver", IsRequired = true)]
        public string Ver
        {
            get { return (string)base["Ver"]; }
            set { base["Ver"] = value; }
        }

        [ConfigurationProperty("Desc", IsRequired = false)]
        public string Desc
        {
            get { return (string)base["Desc"]; }
            set { base["Desc"] = value; }
        }

        [ConfigurationProperty("Type", IsRequired = true)]
        public string Type
        {
            get { return (string)base["Type"]; }
            set { base["Type"] = value; }
        }

        [ConfigurationProperty("disabled", DefaultValue = "false")]
        public bool Disabled
        {
            get { return (bool)base["disabled"]; }
            set { base["disabled"] = value; }
        }

        public NameValueCollection Options { get; private set; }

        protected override bool OnDeserializeUnrecognizedAttribute(string name, string value)
        {
            if (Options == null)
            {
                Options = new NameValueCollection();
            }

            Options.Add(name, value);
            return true;
        }
    }
}
