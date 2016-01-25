using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
 
namespace Aton.Core.Logger
{
    /// <summary>
    /// 日志接口
    /// </summary>
    public interface IAtonLogProvider : IComProvider
    {
        /// <summary>
        /// 日志所属项目代码
        /// </summary>
        string ProjectCode { get; }
        /// <summary>
        /// 捕获异常消息
        /// </summary>
        /// <param name="ex">异常</param>
        /// <returns>处理结果</returns>
        void HandleException(Exception ex,string category="No Category");
        /// <summary>
        /// 捕获异常消息
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="ex">异常</param>
        /// <param name="category">分组</param>
        /// <returns>结果</returns>
        void HandleException(string title, Exception ex, string category = "No Category");
        /// <summary>
        /// 记录日志
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="content">内容</param>
        /// <returns>结果</returns>
        void WriteLog(string title, string content, string category = "No Category");
        /// <summary>
        /// 记录日志[实体对象]
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        void WriteLog(AtonLogEntity entity);
    }
}
