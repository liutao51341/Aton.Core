using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aton.Core.Library.GenericEngine.Events
{
    /// <summary>
    /// 引擎故障通知委托
    /// </summary>
    public delegate void EngineFaultEventHandler(object sender, EngineFaultEventArgs args);

    /// <summary>
    /// 引擎故障通知委托参数
    /// </summary>
    public class EngineFaultEventArgs : EventArgs
    {
        /// <summary>
        /// consturctor
        /// </summary>
        /// <param name="engineName"></param>
        /// <param name="engineType"></param>
        public EngineFaultEventArgs(string message, string stackTrace, string engineName)
        {
            EngineName = engineName;
            Message = message;
            StackTrace = stackTrace;
        }

        /// <summary>
        /// Engine Name
        /// </summary>
        public string EngineName
        {
            get;
            internal set;
        }

        /// <summary>
        /// 异常消息
        /// </summary>
        public string Message
        {
            get;
            internal set;
        }

        /// <summary>
        /// 堆栈信息
        /// </summary>
        public string StackTrace
        {
            get;
            internal set;
        }
    }
}
