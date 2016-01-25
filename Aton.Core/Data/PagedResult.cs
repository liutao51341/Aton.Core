using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aton.Core.Data
{
    /// <summary>
    /// 分页结果
    /// </summary>
    public class PagedResult
    {
        /// <summary>
        /// 分页大小
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// 总页数
        /// </summary>
        public int PageCount { get; set; }
        /// <summary>
        /// 当前页码
        /// </summary>
        public int CurrentPageIndex { get; set; }
        /// <summary>
        /// 记录总数
        /// </summary>
        public int RecordCount { get; set; }
    }

    /// <summary>
    /// 实体分页结果
    /// </summary>
    public class PagedResult<T> : PagedResult
    {
        /// <summary>
        /// 数据源
        /// </summary>
        public virtual List<T> DataSource { get; set; }
    }
}
