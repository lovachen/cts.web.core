using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace cts.web.core.MediaItem
{
    /// <summary>
    /// 
    /// </summary>
    public interface IMediaItemStorage
    {
        /// <summary>
        /// 文件存储,返回路径的相对文件路径
        /// 存储到当前应用的目录下
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="virtualPath">虚拟相对目录 xxxx/xxx</param>
        /// <param name="fileName"></param>
        /// <returns>返回相对路径</returns>
        string Storage(MemoryStream stream, string virtualPath, string fileName);
    }
}
