using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aton.Core
{
    /// <summary>
    /// 组件提供器接口
    /// </summary>
    public interface IComProvider
    {
        /// <summary>
        /// 组件名称
        /// </summary>
        string ProviderName { get; }
        /// <summary>
        /// 组件版本
        /// </summary>
        string Ver { get; }
    }
}
