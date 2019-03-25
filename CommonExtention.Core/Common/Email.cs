using CommonExtention.Core.Extensions;
using CommonExtention.Core.Models;
using System;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CommonExtention.Core.Common
{
    /// <summary>
    /// 提供发送邮件功能。此类不可被继承
    /// </summary>
    public sealed class Email
    {
        #region 公有属性

        /// <summary>
        /// 邮件内容
        /// </summary>
        public EmailContent EmailContent { set; get; }

        /// <summary>
        /// 邮箱服务配置
        /// </summary>
        public EmailServiceConfig ServiceConfig { set; get; }

        /// <summary>
        /// 邮件接收
        /// </summary>
        public Collection<MailAddress> Receivers { set; get; }

        /// <summary>
        /// 抄送
        /// </summary>
        public Collection<MailAddress> CarbonCopy { set; get; }

        /// <summary>
        /// 密送
        /// </summary>
        public Collection<MailAddress> BlindCarbonCopy { set; get; }

        /// <summary>
        /// 中文编码
        /// </summary>
        public static Encoding ChineseEncoding { get => Encoding.GetEncoding(936); }
        #endregion

        #region 私有属性

        /// <summary>
        /// 邮件消息
        /// </summary>
        private MailMessage _MailMessage { set; get; }

        /// <summary>
        /// Smtp 传输协议
        /// </summary>
        private SmtpClient _Client { set; get; }

        #endregion

        #region 构造函数

        /// <summary>
        /// 初始化 <see cref="Email"/> 类的新实例
        /// </summary>
        public Email() => _InitializeMailAddressCollection();


        /// <summary>
        /// 初始化 <see cref="Email"/> 类的新实例
        /// </summary>
        /// <param name="emailContent"></param>
        public Email(EmailContent emailContent)
        {
            _InitializeMailAddressCollection();
            _InitializeMailMessage(emailContent);
        }


        /// <summary>
        /// 初始化 <see cref="Email"/> 类的新实例
        /// </summary>
        /// <param name="serviceConfig"></param>
        public Email(EmailServiceConfig serviceConfig)
        {
            _InitializeMailAddressCollection();
            _InitializeServiceConfig(serviceConfig);
        }


        /// <summary>
        /// 初始化 <see cref="Email"/> 类的新实例
        /// </summary>
        /// <param name="serviceConfig"></param>
        /// <param name="emailContent"></param>
        public Email(EmailServiceConfig serviceConfig, EmailContent emailContent)
        {
            _InitializeMailAddressCollection();
            _InitializeServiceConfig(serviceConfig);
            _InitializeMailMessage(emailContent);
        }
        #endregion

        #region 私有方法

        /// <summary>
        /// 初始化邮箱服务
        /// </summary>
        /// <param name="serviceConfig"></param>
        private void _InitializeServiceConfig(EmailServiceConfig serviceConfig)
        {
            if (serviceConfig == null) throw new ArgumentNullException("未将对象引用设置到对象的实例。");
            if (serviceConfig.Host.IsNullOrEmpty()) throw new ArgumentNullException("未指定邮箱服务的端口。");
            if (serviceConfig.EmailAddress.IsNullOrEmpty()) throw new ArgumentNullException("未指定邮箱服务的账号。");
            if (!serviceConfig.EmailAddress.IsEmail()) throw new FormatException("指定的邮箱服务账号不是正确的邮箱格式。");
            if (serviceConfig.Password.IsNullOrEmpty()) throw new ArgumentNullException("未指定邮箱服务的密码。");
            if (serviceConfig.Port < 0 || ServiceConfig.Port >= int.MaxValue) throw new ArgumentOutOfRangeException("指定邮箱服务的端口超出限定范围。");

            ServiceConfig = serviceConfig;
            _Client = new SmtpClient
            {
                DeliveryMethod = serviceConfig.DeliveryMethod,
                Host = serviceConfig.Host,
                Port = serviceConfig.Port,
                EnableSsl = serviceConfig.EnableSsl,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(serviceConfig.EmailAddress, serviceConfig.Password)
            };
        }

        /// <summary>
        /// 初始化邮件内容
        /// </summary>
        /// <param name="emailContent"></param>
        /// <returns></returns>
        private void _InitializeMailMessage(EmailContent emailContent)
        {
            if (emailContent == null) throw new ArgumentNullException("未将对象引用设置到对象的实例。");
            if (emailContent.Title.IsNullOrEmpty()) throw new ArgumentNullException("未指定邮件内容的标题。");
            if (emailContent.Body.IsNullOrEmpty()) throw new ArgumentNullException("未指定邮件内容的主体。");

            _MailMessage = new MailMessage
            {
                Subject = emailContent.Title,
                Body = emailContent.Body,
                IsBodyHtml = emailContent.IsHtmlContent,
                Priority = emailContent.Priority,
            };

            if (emailContent.ReplyAddress != null && emailContent.ReplyAddress.Address.NotNullAndEmpty())
            {
                _MailMessage.From = emailContent.ReplyAddress;
            }

            // 附件
            if (emailContent.Attachment != null && emailContent.Attachment.Count > 0)
            {
                emailContent.Attachment.ForEach(item => { _MailMessage.Attachments.Add(item); });
            }
            EmailContent = emailContent;
        }

        /// <summary>
        /// 初始化邮件地址的集合
        /// </summary>
        private void _InitializeMailAddressCollection()
        {
            Receivers = new Collection<MailAddress>();
            CarbonCopy = new Collection<MailAddress>();
            BlindCarbonCopy = new Collection<MailAddress>();
        }

        /// <summary>
        /// 配置邮箱服务和邮件内容
        /// </summary>
        private void _SetClientAndMail()
        {
            if (_Client == null && ServiceConfig == null) throw new Exception("未设置邮件服务的配置。");
            if (_Client == null && ServiceConfig != null) _InitializeServiceConfig(ServiceConfig);
            if (_MailMessage == null && EmailContent == null) throw new Exception("未设置邮件的内容。");
            if (_MailMessage == null && EmailContent != null) _InitializeMailMessage(EmailContent);
            if (Receivers.Count <= 0) throw new Exception("至少指定一个邮件接收地址。");

            if (_Client != null && _MailMessage != null && _MailMessage.From == null)
            {
                _MailMessage.From = new MailAddress(ServiceConfig.EmailAddress, ServiceConfig.EmailAddress.EmailPrefix(), ChineseEncoding);
            }

            Receivers.ForEach(item =>
            {
                if (!item.Address.IsEmail()) throw new FormatException($"{item.Address}的邮件接收地址不是正确的邮箱格式。");
                _MailMessage.To.Add(item);
            });

            CarbonCopy.ForEach(item =>
            {
                if (!item.Address.IsEmail()) throw new FormatException($"{item.Address}的邮件抄送接收地址不是正确的邮箱格式。");
                _MailMessage.CC.Add(item);
            });

            BlindCarbonCopy.ForEach(item =>
            {
                if (!item.Address.IsEmail()) throw new FormatException($"{item.Address}的邮件密送接收地址不是正确的邮箱格式。");
                _MailMessage.CC.Add(item);
            });

        }

        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <returns></returns>
        private bool _Send()
        {
            _SetClientAndMail();
            _Client.Send(_MailMessage);
            return true;
        }

        /// <summary>
        /// 异步发送邮件
        /// </summary>
        /// <returns></returns>
        private async Task<bool> _SendAsync()
        {
            _SetClientAndMail();
            await _Client.SendMailAsync(_MailMessage);
            return true;
        }

        #endregion

        #region 发送邮件
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <returns></returns>
        public bool Send() => _Send();
        #endregion

        #region 发送邮件
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="mailAddress"></param>
        /// <returns></returns>
        public bool SendEmail(MailAddress mailAddress)
        {
            if (mailAddress == null) throw new ArgumentNullException("未将对象引用设置到对象的实例。");
            if (!mailAddress.Address.IsEmail()) throw new FormatException($"{mailAddress.Address}的邮件接收地址不是正确的邮箱格式。");

            Receivers.Add(mailAddress);
            return _Send();
        }
        #endregion

        #region 发送邮件
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="mails"></param>
        /// <returns></returns>
        public bool SendEmail(Collection<MailAddress> mails)
        {
            if (mails == null) throw new ArgumentNullException("未将对象引用设置到对象的实例。");
            if (mails.Count <= 0) throw new Exception("至少指定一个邮件接收地址。");

            mails.ForEach(item => { Receivers.Add(item); });
            return _Send();
        }
        #endregion

        #region 异步发送邮件
        /// <summary>
        /// 异步发送邮件
        /// </summary>
        /// <returns></returns>
        public async Task<bool> SendAsync() => await _SendAsync();
        #endregion

        #region 异步发送邮件
        /// <summary>
        /// 异步发送邮件
        /// </summary>
        /// <param name="mailAddress"></param>
        /// <returns></returns>
        public async Task<bool> SendEmailAsync(MailAddress mailAddress)
        {
            if (mailAddress == null) throw new ArgumentNullException("未将对象引用设置到对象的实例。");
            if (!mailAddress.Address.IsEmail()) throw new FormatException($"{mailAddress.Address}的邮件接收地址不是正确的邮箱格式。");

            Receivers.Add(mailAddress);
            return await _SendAsync();
        }
        #endregion

        #region 异步发送邮件
        /// <summary>
        /// 异步发送邮件
        /// </summary>
        /// <param name="mails"></param>
        /// <returns></returns>
        public async Task<bool> SendEmailAsync(Collection<MailAddress> mails)
        {
            if (mails == null) throw new ArgumentNullException("未将对象引用设置到对象的实例。");
            if (mails.Count <= 0) throw new Exception("至少指定一个邮件接收地址。");

            mails.ForEach(item => { Receivers.Add(item); });
            return await _SendAsync();
        }
        #endregion

        #region 释放资源
        /// <summary>
        /// 向 SMTP 服务器发送一条 QUIT 消息，适当地结束 TCP 连接，并释放由 System.Net.Mail.SmtpClient 类的当前实例使用的所有资源。
        /// </summary>
        public void Dispose()
        {
            _Client.Dispose();
        }
        #endregion
    }
}
