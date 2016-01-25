using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aton.Core.Library.GenericEngine.Events
{
    /// <summary>
    ///引擎已经初始化委托
    /// </summary>
    public delegate void EngineStartedEventHandler(object sender, EngineStartedEventArgs args);

    /// <summary>
    /// 引擎初始化委托参数
    /// </summary>
    public class EngineStartedEventArgs : EventArgs
    {
        /// <summary>
        /// 引擎初始化委托参数构造函数
        /// </summary>
        /// <param name="engineName"></param>
        /// <param name="engineType"></param>
        public EngineStartedEventArgs(bool startResult,string engineName)
        {
            StartResult = startResult;
            EngineName = engineName;
            StartDateTime = DateTime.Now;
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
        /// 启动时间
        /// </summary>
        public DateTime StartDateTime
        {
            get;
            internal set;
        }

        /// <summary>
        /// 启动结果
        /// </summary>
        public bool StartResult
        {
            get;
            internal set;
        }
    }
}
