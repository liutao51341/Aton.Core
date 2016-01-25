using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aton.Core.Library.GenericEngine.Events
{
    /// <summary>
    ///引擎初始化委托
    /// </summary>
    public delegate void  EngineInitEventHandler(object sender,EngineInitEventArgs args);
    
    /// <summary>
    /// 引擎初始化委托参数
    /// </summary>
    public class EngineInitEventArgs:EventArgs
    {
        /// <summary>
        /// 引擎初始化委托参数构造函数
        /// </summary>
        /// <param name="engineName"></param>
        /// <param name="engineType"></param>
        public EngineInitEventArgs(string engineName)
        {
            EngineName = engineName;
            InitDateTime = DateTime.Now;
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
        /// 引擎类型
        /// </summary>
        public DateTime InitDateTime
        {
            get;
            internal set;
        }
    }
}
