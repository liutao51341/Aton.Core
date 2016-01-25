using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aton.Core.Config
{
    /// <summary>
    /// 配置字段映射属性
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class ConfigMapNameAttribute : Attribute
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="mapName">映射名称</param>
        public ConfigMapNameAttribute(string mapName)
        {
            MapName = mapName;
        }

        /// <summary>
        /// 映射表字段信息
        /// </summary>
        public string MapName
        {
            get;
            private set;
        }
    }
}
