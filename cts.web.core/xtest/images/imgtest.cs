using cts.web.core.Librs;
using System;
using System.Collections.Generic;
using System.DrawingCore.Drawing2D;
using System.IO;
using System.Text;
using Xunit;

namespace xtest.images
{
    public class imgtest
    {
        [Fact]
        public void FontImg()
        {
           var img = ImageHelper.FontMarkPicture("地大物博", 38, "微软雅黑", "#000000", "#FFA500");
           var dir = System.IO.Directory.GetCurrentDirectory();

            using (var fs = new System.IO.FileStream(System.IO.Path.Combine(dir, "1.jpg"), FileMode.OpenOrCreate))
            {
                img.Save(fs, System.DrawingCore.Imaging.ImageFormat.Jpeg) ;
                fs.Flush();
                fs.Close();
            }
        }

        [Fact]
        public void Store()
        {
           string p = System.IO.Path.Combine("e:/", "abc");

        }
    }
}
