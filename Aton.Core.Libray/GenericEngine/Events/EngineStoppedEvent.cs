using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aton.Core.Library.GenericEngine.Events
{
    /// <summary>
    ///引擎停止委托
    /// </summary>
    public delegate void EngineStoppedEventHandler(object sender, EngineStoppedEventArgs args);

    /// <summary>
    /// 引擎停止委托参数
    /// </summary>
    public class EngineStoppedEventArgs : EventArgs
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="engineName">引擎名称</param>
        /// <param name="stopResult">停止结果</param>
        /// <param name="stopReason">停止原因</param>
        public EngineStoppedEventArgs(string engineName, bool stopResult, string stopReason)
        {
            EngineName = engineName;
            StopReason = stopReason;
            StopResult = stopResult;
        }

        /// <summary>
        /// 引擎名称
        /// </summary>
        public string EngineName
        {
            get;
            internal set;
        }

        /// <summary>
        /// 启动结果
        /// True成功或False失败
        /// </summary>
        public bool StopResult
        {
            get;
            internal set;
        }

        /// <summary>
        /// 停止原因
        /// </summary>
        public string StopReason
        {
            get;
            internal set;
        }
    }
}
