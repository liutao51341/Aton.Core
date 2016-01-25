using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;

namespace Aton.Core.Config.ProviderConfigHandler
{
    public class AtonProviderMode : ConfigurationElement
    {
        public AtonProviderMode() { }
        public AtonProviderMode(string isDelayLoad)
        {
            base["IsDelayLoad"] = isDelayLoad;
        }

        [ConfigurationProperty("IsDelayLoad", DefaultValue = "false")]
        public bool IsDelayLoad
        {
            get { return (bool)base["IsDelayLoad"]; }
            set { base["IsDelayLoad"] = value; }
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
