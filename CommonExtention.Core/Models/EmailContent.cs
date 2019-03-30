using System.Collections.ObjectModel;
using System.Net.Mail;
using System.Text;

namespace CommonExtention.Core.Models
{
    /// <summary>
    /// 邮件内容。此类不可被继承
    /// </summary>
    public class EmailContent
    {
        /// <summary>
        /// 初始化 <see cref="EmailContent"/> 类的新实例
        /// </summary>
        public EmailContent() { }

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
        /// 邮件的优先级，默认为 Normal
        /// </summary>
        public MailPriority Priority { set; get; } = MailPriority.Normal;

        /// <summary>
        /// 附件
        /// </summary>
        public Collection<Attachment> Attachment { set; get; }
    }
}
