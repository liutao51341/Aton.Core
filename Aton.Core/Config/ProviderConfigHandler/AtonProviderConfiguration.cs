using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace Aton.Core.Config.ProviderConfigHandler
{
    class AtonProviderConfiguration : ConfigurationSection
    {
        [ConfigurationProperty("AtonProviders")]
        public AtonProviderCollection AtonProviders
        {
            get
            {
                return this["AtonProviders"] as AtonProviderCollection;
            }
        }

        [ConfigurationProperty("AtonProviderMode")]
        public AtonProviderMode AtonProvidersMode
        {
            get
            {
                return this["AtonProviderMode"] as AtonProviderMode;
            }
        }
    }
}
