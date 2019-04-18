using cts.web.core.Librs;
using cts.web.core.MediaItem;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Microsoft.AspNetCore.Http
{
    /// <summary>
    /// 上传文件扩展
    /// </summary>
    public static class FormFileExtension
    {
        //255216是jpg;7173是gif;6677是BMP,13780是PNG
        private static string[] img_exArr = new string[] { "255216", "7173", "6677", "13780" };

        /// <summary>
        /// 文件是否是图片
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        public static bool IsImage(this IFormFile formFile)
        {
            using (Stream stream = formFile.OpenReadStream())
            {
                using (BinaryReader r = new BinaryReader(stream))
                {
                    StringBuilder sb = new StringBuilder();
                    byte buffer;
                    buffer = r.ReadByte();
                    sb.Append(buffer.ToString());
                    buffer = r.ReadByte();
                    sb.Append(buffer.ToString());
                    return img_exArr.Any(o => o.Contains(sb.ToString().ToLower()));
                }
            }
        }

        /// <summary>
        /// 文件大小超出范围
        /// </summary>
        /// <param name="formFile"></param>
        /// <param name="length">字节大小 例 100kb，100*1024 = 102400 </param>
        /// <returns></returns>
        public static bool IsBigSize(this IFormFile formFile, int length)
        {
            return formFile.Length > length;
        }

        /// <summary>
        /// 获取文件的哈希SHA1值
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        public static string GetSHA1(this IFormFile formFile)
        {
            using (var ms = formFile.OpenReadStream())
            {
                SHA1 sha1 = new SHA1CryptoServiceProvider();
                byte[] retval = sha1.ComputeHash(ms);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < retval.Length; i++)
                    sb.AppendFormat("{0:X2}", retval[i]);
                return sb.ToString();
            }
        }

        /// <summary>
		/// 获取文件的MD5值
		/// </summary>
		/// <param name="formFile"></param>
		/// <returns></returns>
		public static string GetMD5(this IFormFile formFile)
        {
            using (Stream inputStream = formFile.OpenReadStream())
            {
                byte[] array = MD5.Create().ComputeHash(inputStream);
                StringBuilder stringBuilder = new StringBuilder();
                for (int i = 0; i < array.Length; i++)
                {
                    stringBuilder.Append(array[i].ToString("x2"));
                }
                return stringBuilder.ToString();
            }
        }

        /// <summary>
        /// 创建保存图片文件
        /// </summary>
        /// <param name="formFile"></param>
        /// <param name="imageStorage"></param>
        /// <param name="virtualPath">虚拟相对路径 xxx/xxx</param>
        /// <param name="compress">是否压缩图片</param>
        /// <param name="flag">压缩质量 1-100(数字越小压缩率越高)。只有启用压缩是才起作用</param>
        /// <returns></returns>
        public static string CreateImagePathFromStream(this IFormFile formFile, IMediaItemStorage imageStorage, string virtualPath, bool compress = false, int flag = 50)
        {
            return CreateImagePathFromStream(formFile, imageStorage, virtualPath, false, compress, flag);
        }

        /// <summary>
        /// 创建保存图片文件
        /// </summary>
        /// <param name="formFile"></param>
        /// <param name="imageStorage"></param>
        /// <param name="virtualPath">虚拟相对路径 xxx/xxx</param>
        /// <param name="suffix">是否带后缀</param>
        /// <param name="compress">是否压缩图片</param>
        /// <param name="flag">压缩质量 1-100(数字越小压缩率越高)。只有启用压缩是才起作用</param>
        /// <returns></returns>
        public static string CreateImagePathFromStream(this IFormFile formFile, IMediaItemStorage imageStorage, string virtualPath, bool suffix, bool compress, int flag)
        {
            var imagePath = string.Empty;

            using (Stream sm = formFile.OpenReadStream())
            {
                using (var memoryStream = new MemoryStream())
                {
                    sm.CopyTo(memoryStream);
                    string fileName = suffix ? Guid.NewGuid() + Path.GetExtension(formFile.FileName) : Guid.NewGuid().ToString();
                    if (compress)
                    {
                        using (MemoryStream ms = ImageHelper.Compress(memoryStream, flag))
                        {
                            imagePath = imageStorage.Storage(ms, virtualPath, fileName);
                        }
                    }
                    else
                    {
                        imagePath = imageStorage.Storage(memoryStream, virtualPath, fileName);
                    }
                }
            }
            return imagePath;
        }





    }
}
