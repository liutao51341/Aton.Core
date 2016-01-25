using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aton.Core.Data
{
    /// <summary>
    /// 数据字典提供器接口
    /// </summary>
    public interface IParameterProvider : IComProvider
    {
        /// <summary>
        /// 根据键获取值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parameterCode"></param>
        /// <returns></returns>
        object GetParameter(int parameterCode);
        /// <summary>
        /// 获取字段组下所有参数
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="groupCode"></param>
        /// <returns></returns>
        Dictionary<int, string> GetParameterDict(int groupCode);
        /// <summary>
        /// 获取字段组下所有参数
        /// </summary>
        /// <param name="groupCode"></param>
        /// <returns></returns>
        List<Parameter> GetParameterList(int groupCode, string tip);
        /// <summary>
        /// 添加或更新字典参数组
        /// </summary>
        /// <param name="groupCode"></param>
        /// <param name="groupName"></param>
        /// <param name="statusID"></param>
        /// <returns></returns>
        bool AddOrUpdateParameterGroup(string projectCode, int groupCode, string groupName, int statusID);
        /// <summary>
        /// 添加或更新字典参数
        /// </summary>
        /// <param name="groupCode"></param>
        /// <param name="parameterCode"></param>
        /// <param name="parameterName"></param>
        /// <param name="parameterValue"></param>
        /// <param name="statusID"></param>
        /// <returns></returns>
        bool AddOrUpdateParameter(int groupCode,int parameterCode, string parameterName, int statusID);
        /// <summary>
        /// 移除数据字典组
        /// </summary>
        /// <param name="parameterGroupCode"></param>
        /// <returns></returns>
        bool RemoveParameterGroup(string projectCode, int parameterGroupCode);
        /// <summary>
        /// 移除数据字典
        /// </summary>
        /// <param name="parameterCode"></param>
        /// <returns></returns>
        bool RemoveParameter( int parameterCode);
    }
}
