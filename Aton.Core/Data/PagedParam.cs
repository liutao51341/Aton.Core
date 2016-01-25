using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aton.Core.Data
{
    /// <summary>
    /// 分页参数
    /// </summary>
    public class PagedParam
    {
        public PagedParam() { Fields = new List<string>(); Orders = new List<string>(); }

        /// <summary>
        /// 数据表名
        /// </summary>
        public string Table { get; set; }
        /// <summary>
        /// 获取字段列表
        /// </summary>
        public List<string> Fields { get; set; }
        /// <summary>
        /// 排序字段列表
        /// </summary>
        public List<string> Orders { get; set; }
        /// <summary>
        /// 分页大小
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// 当前页码
        /// </summary>
        public int CurrentPageIndex { get; set; }
        /// <summary>
        /// 过滤条件
        /// </summary>
        public string FilterCondition { get; set; }
    }
}
