using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aton.Core.Service
{
    /// <summary>
    /// 服务接口
    /// </summary>
    public interface IAtonService : IComProvider
    {
        /// <summary>
        /// 启动服务
        /// </summary>
        /// <returns></returns>
        bool StartService();
        /// <summary>
        /// 停止服务
        /// </summary>
        /// <returns></returns>
        bool StopService();
    }
}
