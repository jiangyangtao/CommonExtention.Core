using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace CommonExtention.Core.Models
{
    /// <summary>
    /// 邮箱服务配置。此类不可被继承
    /// </summary>
    public sealed class EmailServiceConfig
    {
        /// <summary>
        /// 初始化 <see cref="EmailServiceConfig"/> 类的新实例
        /// </summary>
        public EmailServiceConfig() { }

        /// <summary>
        /// Smtp 服务器地址
        /// </summary>
        public string Host { set; get; }

        /// <summary>
        /// Smtp 服务器的端口，默认为 25
        /// </summary>
        public int Port { set; get; } = 25;

        /// <summary>
        /// Smtp 服务器是否启用 SSL 加密，默认为 true
        /// </summary>
        public bool EnableSsl { set; get; } = true;

        /// <summary>
        /// 邮箱账号
        /// </summary>
        public string EmailAddress { set; get; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { set; get; }

        /// <summary>
        /// 获取或设置 <see cref="bool"/> 值，该值控制 <see cref="CredentialCache.DefaultCredentials"/> 是否随请求一起发送，默认为 false。
        /// </summary>
        public bool UseDefaultCredentials { set; get; } = false;

        /// <summary>
        /// Smtp 传输方式，默认为 Network
        /// </summary>
        public SmtpDeliveryMethod DeliveryMethod { set; get; } = SmtpDeliveryMethod.Network;
    }
}
