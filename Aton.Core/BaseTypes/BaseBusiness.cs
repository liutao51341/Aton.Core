using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aton.Core.BaseTypes
{
   public  class BaseBusiness
    {
       public BaseBusiness(long deptId) { DepartmentId = deptId; }

        /// <summary>
        /// 当前用户所属单位
        /// </summary>
        public long DepartmentId { get; set; }
    }
}
