using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMonitor.Models
{

    /// <summary>
    /// 环境信息
    /// </summary>
    public class EnvironmentModel : BindableBase
    {
        /// <summary>
        /// 名字
        /// </summary>
        public string EnItName { get; set; }
        /// <summary>
        /// 值
        /// </summary>
        public int EnItValue { get; set; }

    }
}
