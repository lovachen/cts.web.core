using System;
using System.Collections.Generic;
using System.Text;

namespace cts.web.Core.Mail
{
    public interface IMailSender
    {
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="subject"></param>
        /// <param name="isHtml"></param>
        /// <param name="body"></param>
        void Smtp(string to, string subject, string body, bool isHtml = false);

        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="tos"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <param name="isHtml"></param>
        void Smtp(IEnumerable<string> tos, string subject, string body, bool isHtml = false);

    }
}
