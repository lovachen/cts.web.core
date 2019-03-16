﻿using System;
using System.Collections.Generic;
using System.Text;

namespace cts.web.Core.Model
{
    /// <summary>
    /// api 结果对象
    /// </summary>
    [Serializable]
    public class ApiJsonResult
    {
        /// <summary>
        /// 
        /// </summary>
        public ApiJsonResult()
        {
            this.code = -1;
            this.msg = "";
        }

        /// <summary>
        /// 0：成功
        /// 1002：禁止访问的ip
        /// 1003：未登录
        /// 1004：token已过期
        /// 1005：参数错误
        /// 1006：appid 为空或错误
        /// 1007：没有权限
        /// </summary>
        public int code { get; set; }

        /// <summary>
        /// 提示信息
        /// </summary>
        public string msg { get; set; }

        /// <summary>
        /// 返回结果
        /// </summary>
        public object data { get; set; }
    }

    
}