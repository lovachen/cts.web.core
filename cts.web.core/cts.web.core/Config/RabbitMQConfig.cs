using System;
using System.Collections.Generic;
using System.Text;

namespace cts.web.Core.Config
{
    /// <summary>
    /// rabbitmq 配置
    /// </summary>
    [Serializable]
    public class RabbitMQConfig
    {
        /// <summary>
        /// 
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string HostName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string VirtualHost { get; set; }
    }
}
