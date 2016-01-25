using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aton.Core.Devenv
{
    /// <summary>
    /// 模块传递消息结构
    /// </summary>
    public class SdkMessageScheme
    {
        /// <summary>
        /// 命令码
        /// </summary>
        public string CmdCode { get; set; }
        /// <summary>
        /// 命令名称
        /// </summary>
        public string CmdName { get; set; }
        /// <summary>
        /// 命令内容数据类型
        /// Null 表示不输入值
        /// </summary>
        public Type ValueType { get; set; }
        /// <summary>
        /// 值输入提示
        /// </summary>
        public string ValueTip { get; set; }
    }
}
