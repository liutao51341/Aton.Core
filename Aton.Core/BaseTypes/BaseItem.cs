using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aton.Core.BaseTypes
{
    /// <summary>
    /// 基础项
    /// </summary>
    public class BaseItem<Key>
    {
        /// <summary>
        /// 代码
        /// </summary>
        public Key Code { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
    }
}
