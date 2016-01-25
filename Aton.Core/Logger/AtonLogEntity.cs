using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aton.Core.Logger
{
    /// <summary>
    /// 日志实体
    /// </summary>
    [Serializable]
    public class AtonLogEntity
    {
        public AtonLogEntity() { Category = "No Category"; }
        /// <summary>
        /// 日志类别
        /// </summary>
        public string Category { get; set; }
        /// <summary>
        /// 日志标题
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 日志内容
        /// </summary>
        public string Content { get; set; }
    }
}
