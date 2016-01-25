using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aton.Core.Config
{
    /// <summary>
    /// 配置接口
    /// </summary>
    public interface IConfiguration
    {
        /// <summary>
        /// 组名称
        /// </summary>
        string GroupCode { get; }
        /// <summary>
        /// 是否已经初始化
        /// </summary>
        bool Initialized { get; set; }
    }
}
