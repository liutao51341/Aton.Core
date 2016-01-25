using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aton.Core.Config.ServiceConfigHandler;
using Aton.Core.Service;

namespace Aton.Core.Loader
{
    /// <summary>
    /// 服务组件加载器
    /// </summary>
    public class ServiceLoader : IProviderLoader
    {
        /// <summary>
        /// 服务配置对象
        /// </summary>
        AtonServiceConfigHandler handler = new AtonServiceConfigHandler();
        /// <summary>
        /// 服务容器
        /// </summary>
        protected ConcurrentDictionary<string, IComProvider> container = new ConcurrentDictionary<string, IComProvider>();

        /// <summary>
        /// 构造函数
        /// </summary>
        public ServiceLoader()
        {
            IsLoaded = LoadServiceInfo(handler);
        }

        /// <summary>
        /// 是否已经加载
        /// </summary>
        public bool IsLoaded
        {
            get;
            set;
        }

        /// <summary>
        /// 获取待加载的服务列表
        /// </summary>
        /// <returns></returns>
        public override List<string> GetTotalLoadList()
        {
            return handler.Select(n => n.Name).ToList();
        }

        /// <summary>
        /// 获取加载成功的服务列表
        /// </summary>
        /// <returns></returns>
        public override List<string> GetLoadedList()
        {
            return container.Select(n => n.Key).ToList();
        }

        public override IComProvider Resolver(string name)
        {
            IComProvider provider = null;
            if (container.TryGetValue(name, out provider))
            {
                return provider;
            }
            return provider;
        }

        /// <summary>
        /// 加载服务信息
        /// </summary>
        /// <param name="configHandler"></param>
        /// <returns></returns>
        protected bool LoadServiceInfo(AtonServiceConfigHandler configHandler)
        {
            foreach (var item in configHandler)
            {
                IAtonService service;
                if (TryCreateInstance<IAtonService>(item.Type, out service))
                {
                    container.TryAdd(item.Name, service);
                }
                else
                {
                    container.Clear();
                    return false;
                }
            }
            return true;
        }
    }
}
