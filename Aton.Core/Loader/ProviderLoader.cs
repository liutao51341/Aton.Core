using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aton.Core.Config.ProviderConfigHandler;

namespace Aton.Core.Loader
{
    /// <summary>
    /// 组件加载器
    /// </summary>
    public class ProviderLoader:IProviderLoader
    {
        /// <summary>
        /// 配置对象
        /// </summary>
        AtonProviderHandler handler = new AtonProviderHandler();
        /// <summary>
        /// 服务容器
        /// </summary>
        protected ConcurrentDictionary<string, IComProvider> container = new ConcurrentDictionary<string, IComProvider>();
        /// <summary>
        /// 是否延迟加载(具体调用的时候加载)
        /// </summary>
        protected bool IsDelayLoad = false;

        /// <summary>
        /// 服务加载器构造函数
        /// </summary>
        public ProviderLoader()
        {
            IsDelayLoad = handler.AtonProviderMode.IsDelayLoad;
            if (!IsDelayLoad)
            {
                LoadServiceInfo(handler);
            }
        }
 
        /// <summary>
        /// 获取待加载的服务列表
        /// </summary>
        /// <returns></returns>
        public override List<string> GetLoadedList()
        {
            return container.Select(n => n.Key).ToList();
        }

        /// <summary>
        /// 获取组件列表
        /// </summary>
        /// <returns></returns>
        public override List<string> GetTotalLoadList()
        {
            return handler.Select(n=>n.Name).ToList();
        }

        /// <summary>
        /// 获取组件对象
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public override IComProvider Resolver(string name)
        {
            IComProvider provider = null;
            if (container.TryGetValue(name, out provider))
            {
                return provider;
            }
            else
            {
                LoadServiceInfo(handler, name);
            }
            container.TryGetValue(name, out provider);
            return provider;
        }

        /// <summary>
        /// 加载服务信息
        /// </summary>
        /// <param name="configHandler"></param>
        /// <returns></returns>
        protected bool LoadServiceInfo(AtonProviderHandler configHandler, string name = "")
        {
            if (string.IsNullOrEmpty(name)) //全部加载
            {
                foreach (var item in configHandler)
                {
                    IComProvider service;
                    if (TryCreateInstance<IComProvider>(item.Type, out service))
                    {
                        container.TryAdd(item.Name, service);
                    }
                }
            }
            else //延迟加载
            {
                var item = configHandler.FirstOrDefault(n => n.Name == name);
                if (item == null)
                {
                    return false;
                }
                else
                {
                    IComProvider service;
                    if (TryCreateInstance<IComProvider>(item.Type, out service))
                    {
                        container.TryAdd(item.Name, service);
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
