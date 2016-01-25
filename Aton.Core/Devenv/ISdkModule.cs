using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Aton.Core.Devenv
{
    /// <summary>
    /// 开发插件接口
    /// </summary>
    public interface ISdkModule : IComProvider
    {
        /// <summary>
        /// 模块名称
        /// </summary>
        string ModuleName { get; }
        /// <summary>
        /// 模块介绍
        /// </summary>
        string ModuleDesc { get; }
        /// <summary>
        /// 支持的命令结构
        /// </summary>
        IEnumerable<SdkMessageScheme> SupportCommand { get; }
        /// <summary>
        /// 模块初始化(显示默认页面)
        /// </summary>
        /// <returns></returns>
        Control Initial(IDevenvHandler devenvHandler);
        /// <summary>
        /// 模块卸载
        /// </summary>
        /// <returns></returns>
        bool UnLoad();
        /// <summary>
        /// 向模块发送消息
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        object PostMessage(SdkMessage message);
    }
}
