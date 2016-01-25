using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aton.Core.Devenv
{
    /// <summary>
    /// 控件反控制开发环境接口
    /// </summary>
    public interface IDevenvHandler
    {
        void SendCommand(DevenvCommand cmd,object content);
    }

    /// <summary>
    /// 开发环境支持命令
    /// </summary>
    public enum DevenvCommand
    { 
        /// <summary>
        /// 打开新tab页面（系统权限）
        /// 参数：传递参数是插件名称
        /// </summary>
        NEWTAB=1,
        /// <summary>
        /// 关闭新tab页面（系统权限）
        /// 参数：传递参数是插件名称
        /// </summary>
        CLOSETAB,
        /// <summary>
        /// 关闭开发环境（系统权限）
        /// 参数：传递参数是插件名称
        /// </summary>
        CLOSEWIN,
        /// <summary>
        /// 设置开发环境状态栏信息
        /// 参数： 传递格式（标题|内容）
        /// </summary>
        STATUS=100,
        /// <summary>
        /// 关闭自己
        /// 参数： null
        /// </summary>
        CLOSEME
    }
}
