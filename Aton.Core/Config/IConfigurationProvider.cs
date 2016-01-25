using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aton.Core.Config
{
    /// <summary>
    /// 配置控制器接口
    /// </summary>
    public interface IConfigurationProvider : IComProvider
    {
        /// <summary>
        /// 加载配置
        /// </summary>
        /// <param name="config">配置对象</param>
        /// <returns>结果</returns>
        T LoadConfig<T>() where T : IConfiguration, new();
        /// <summary>
        /// 保存配置
        /// </summary>
        /// <param name="config">配置对象</param>
        /// <returns>结果</returns>
        bool SaveConfig<T>(T config) where T : IConfiguration, new();
        /// <summary>
        /// 获取配置信息
        /// </summary>
        /// <param name="group">分组</param>
        /// <param name="code">代码</param>
        /// <returns>配置值</returns>
        object GetConfigValue(string group, string code);
        /// <summary>
        /// 更新配置信息
        /// </summary>
        /// <param name="group">分组</param>
        /// <param name="code">代码</param>
        /// <param name="value">配置值</param>
        /// <returns>更新结果</returns>
        bool SetConfigValue(string group, string code, object value);
    }
}
