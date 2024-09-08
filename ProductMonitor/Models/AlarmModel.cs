﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMonitor.Models
{
    /// <summary>
    /// 报警数据类型
    /// </summary>
    public class AlarmModel:BindableBase
    {
        /// <summary>
        /// 编号
        /// </summary>
        public string Num { get; set; }
        /// <summary>
        /// 报警信息
        /// </summary>
        
        public string Msg { get; set; }
        /// <summary>
        /// 报警时间
        /// </summary>
        public DateTime Time { get; set; }
        /// <summary>
        /// 报警时长
        /// </summary>
        public int Duration { get; set; }


    }
}
