using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aton.Core.Devenv
{
    /// <summary>
    /// 模块传递消息
    /// </summary>
    public class SdkMessage : SdkMessageScheme
    {
        /// <summary>
        /// 命令内容
        /// </summary>
        public object CmdValue { get; set; }
    }

}
