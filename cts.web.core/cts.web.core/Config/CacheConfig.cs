using System;
using System.Collections.Generic;
using System.Text;

namespace cts.web.Core.Config
{
    /// <summary>
    /// 缓存配置
    /// </summary>
    public class CacheConfig
    {
        /// <summary>
        /// 启用redis？
        /// </summary>
        public bool RedisCachingEnabled { get; set; }

        /// <summary>
        /// redis连接字符串
        /// </summary>
        public string RedisCachingConnectionString { get; set; }
    }
}
