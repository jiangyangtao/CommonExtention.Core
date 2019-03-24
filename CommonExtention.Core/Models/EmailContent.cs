using System.Collections.ObjectModel;
using System.Net.Mail;
using System.Text;

namespace CommonExtention.Core.Models
{
    /// <summary>
    /// 邮件内容
    /// </summary>
    public class EmailContent
    {
        /// <summary>
        /// 标题、主题
        /// </summary>
        public string Title { set; get; }

        /// <summary>
        /// 邮件主体
        /// </summary>
        public string Body { set; get; }

        /// <summary>
        /// 是否为 html 内容，默认为 false
        /// </summary>
        public bool IsHtmlContent { set; get; } = false;

        /// <summary>
        /// 邮件回复地址
        /// </summary>
        public MailAddress ReplyAddress { set; get; }

        /// <summary>
        /// 编码，默认为中文编码
        /// </summary>
        public Encoding Encoding { set; get; } = Encoding.GetEncoding(936);

        /// <summary>
        /// 邮件的优先级，默认为 Normal
        /// </summary>
        public MailPriority Priority { set; get; } = MailPriority.Normal;

        /// <summary>
        /// 附件
        /// </summary>
        public Collection<Attachment> Attachment { set; get; }
    }
}
