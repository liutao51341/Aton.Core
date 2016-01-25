using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aton.Core.BaseTypes
{
    /// <summary>
    /// 结果标识基类
    /// </summary>
    public class BaseResult
    {
        /// <summary>
        /// 成功标识
        /// </summary>
        public bool IsOK { get; set; }
        /// <summary>
        /// 附加标识
        /// </summary>
        public int ExtId { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Desc { get; set; }
    }
}
