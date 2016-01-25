using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aton.Core.IO
{
    public interface IOProvider:  IComProvider
    {
        /// <summary>
        /// 字符串Io处理
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        string IOProcess(string input,object param);
    }
}
