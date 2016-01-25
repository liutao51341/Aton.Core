using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aton.Core.Library.GenericEngine
{
    /// <summary>
    /// 引擎状态
    /// </summary>
    public enum EngineStatus
    {
        /// <summary>
        /// 未初始化
        /// </summary>
        NotReady,
        /// <summary>
        /// 已初始化
        /// </summary>
        Ready,
        /// <summary>
        /// 运行中
        /// </summary>
        Running,
        /// <summary>
        /// 等待停止
        /// </summary>
        WaitToStop,
        /// <summary>
        /// 已停止
        /// </summary>
        Stopped
    }
}
