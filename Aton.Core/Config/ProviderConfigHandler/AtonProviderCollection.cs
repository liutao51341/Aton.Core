using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace Aton.Core.Config.ProviderConfigHandler
{
    [ConfigurationCollection(typeof(AtonProvider), AddItemName = "AtonProvider")]
    class AtonProviderCollection : ConfigurationElementCollection, IEnumerable<AtonProvider>
    {
        public AtonProvider this[int index]
        {
            get
            {
                return (AtonProvider)base.BaseGet(index);
            }
            set
            {
                if (base.BaseGet(index) != null)
                {
                    base.BaseRemoveAt(index);
                }
                this.BaseAdd(index, value);
            }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new AtonProvider();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((AtonProvider)element).Name;
        }

        public new IEnumerator<AtonProvider> GetEnumerator()
        {
            int count = base.Count;
            for (int i = 0; i < count; i++)
            {
                yield return (AtonProvider)base.BaseGet(i);
            }
        }

        public IEnumerable<AtonProviderConfig> ToProviderConfigArray()
        {
            int count = base.Count;
            for (int i = 0; i < count; i++)
            {
                AtonProvider provider = (AtonProvider)base.BaseGet(i);
                yield return new AtonProviderConfig(provider.Name, provider.Ver, provider.Desc, provider.Type);
            }
        }
    }
}
