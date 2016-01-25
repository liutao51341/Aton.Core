using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aton.Core
{
    /// <summary>
    /// 组件加载器接口
    /// </summary>
    public abstract class IProviderLoader
    {
        /// <summary>
        /// 获取已加载的组件列表
        /// </summary>
        /// <returns></returns>
        public abstract List<string> GetLoadedList();
        /// <summary>
        /// 获取所有配置列表
        /// </summary>
        /// <returns></returns>
        public abstract List<string> GetTotalLoadList();
        /// <summary>
        /// 获取组件提供器
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public abstract IComProvider Resolver(string name);
        /// <summary>
        /// 创建对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        protected bool TryCreateInstance<T>(string type, out T result)
        {
            Type instanceType = null;
            result = default(T);

            if (!TryGetType(type, out instanceType))
                return false;

            try
            {
                object instance = Activator.CreateInstance(instanceType);
                result = (T)instance;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// 获取类型
        /// </summary>
        /// <param name="type"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        private bool TryGetType(string type, out Type result)
        {
            try
            {
                result = Type.GetType(type,true);
                return true;
            }
            catch (Exception e)
            {
                result = null;
                return false;
            }
        }
    }
}
