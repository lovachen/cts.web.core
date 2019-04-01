using System;
using System.Collections.Generic;
using System.Text;

namespace cts.web.core.Librs
{
    /// <summary>
    /// 图片处理类
    /// </summary>
    public class ImageHelper
    {

    }


    /// <summary>
    /// 缩略图方式
    /// </summary>
    public enum ThumbnailProportion
    {
        /// <summary>
        /// 指定宽，高按比例   
        /// </summary>
        WIDTH,

        /// <summary>
        /// 指定高，宽按比例
        /// </summary>
        HEIHT,

        /// <summary>
        /// 指定高宽缩放（可能变形）
        /// </summary>
        WIDTH_HEIHT,

        /// <summary>
        /// 指定高宽裁减（不变形）
        /// </summary>
        CUT

    }

    /// <summary>
    /// 图片水印位置
    /// </summary>
    public enum WaterPosition
    {
        /// <summary>
        /// 左上
        /// </summary>
        左上,

        /// <summary>
        /// 中上
        /// </summary>
        中上,

        /// <summary>
        /// 右上
        /// </summary>
        右上,

        /// <summary>
        /// 左中
        /// </summary>
        左中,

        /// <summary>
        /// 中中
        /// </summary>
        中中,

        /// <summary>
        /// 右中
        /// </summary>
        右中,

        /// <summary>
        /// 左下
        /// </summary>
        左下,

        /// <summary>
        /// 中下
        /// </summary>
        中下,

        /// <summary>
        /// 右下
        /// </summary>
        右下

    }
}
