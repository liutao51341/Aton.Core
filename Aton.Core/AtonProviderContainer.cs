using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using Aton.Core.Config;
using Aton.Core.Data;
using Aton.Core.Loader;
using Aton.Core.Logger;
using Aton.Core.IO;

namespace Aton.Core
{
    /// <summary>
    /// 组件提供器容器
    /// </summary>
    public class AtonProviderContainer
    {
        /// <summary>
        /// 组件加载器
        /// </summary>
        static ProviderLoader loader = new ProviderLoader();

        #region 获取容器中的日志访问对象
        /// <summary>
        /// 获取容器中的日志访问对象
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="configName">配置名称</param>
        /// <returns></returns>
        public static IAtonLogProvider ResolveLogger(string configName="LoggerProvider")
        {
            return loader.Resolver(configName) as IAtonLogProvider;
        }
        #endregion

        #region 获取容器中的配置对象
        /// <summary>
        /// 获取容器中的配置对象
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="configName">配置名称</param>
        /// <returns></returns>
        public static IConfigurationProvider ResolveConfigProvider(string configName = "ConfigProvider")
        {
            return loader.Resolver(configName) as IConfigurationProvider;
        }
        #endregion

        #region 获取容器中的数据字典对象
        /// <summary>
        /// 获取容器中的数据字典对象
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="configName">配置名称</param>
        /// <returns></returns>
        public static IParameterProvider ResolveParameterProvider(string configName = "ParameterProvider")
        {
            return loader.Resolver(configName) as IParameterProvider;
        }
        #endregion

        #region 获取容器中的IO对象
        /// <summary>
        /// 获取容器中的IO对象
        /// </summary>
        /// <param name="configName">配置名称</param>
        /// <returns></returns>
        public static IOProvider ResolveIoProvider(string configName)
        {
            return loader.Resolver(configName) as IOProvider;
        }
        #endregion
    }
}
