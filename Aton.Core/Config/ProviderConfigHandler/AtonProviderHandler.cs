using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace Aton.Core.Config.ProviderConfigHandler
{
    /// <summary>
    /// 服务配置信息
    /// </summary>
    public class AtonProviderConfig
    {
        public AtonProviderConfig(string name,string ver,string desc, string type)
        {
            Name = name;
            Type = type;
        }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 组件版本
        /// </summary>
        public string Ver{get;set;}
                /// <summary>
        /// 组件描述
        /// </summary>
        public string Desc{get;set;}
        /// <summary>
        /// 类/路径名
        /// </summary>
        public string Type { get; set; }
    }

    public class AtonProviderHandler : List<AtonProviderConfig>
    {
        public AtonProviderMode AtonProviderMode
        {
            get;
            set;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public AtonProviderHandler(string sectionName = "AtonProviderHost")
        {
            var serverConfig = ConfigurationManager.GetSection(sectionName) as AtonProviderConfiguration;
            AddRange(serverConfig.AtonProviders.ToProviderConfigArray());
            AtonProviderMode = serverConfig.AtonProvidersMode;
        }
    }
}
