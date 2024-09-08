using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMonitor.Models
{
    public class DeviceModel : BindableBase
    {

        /// <summary>
        /// 设备名称
        /// </summary>
        public string DeviceItem { get; set; }
        /// <summary>
        /// 值
        /// </summary>
        public double Value { get; set; }


    }
}
