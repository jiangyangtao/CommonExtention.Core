using CommonExtention.Core.Extensions;
using CommonExtention.Core.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace CommonExtention.Core.Common
{
    /// <summary>
    /// 提供发送邮件功能。此类不可被继承
    /// </summary>
    public sealed class Email
    {
        /// <summary>
        /// 
        /// </summary>
        public EmailContent Content { set; get; }

        /// <summary>
        /// 
        /// </summary>
        public EmailServiceConfig ServiceConfig { set; get; }

        /// <summary>
        /// 中文编码
        /// </summary>
        public static Encoding ChineseEncoding { get => Encoding.GetEncoding(936); }


        private MailMessage _MailMessage { set; get; }

        private SmtpClient _Client { set; get; }


        private bool _HasSetServiceConfig { set; get; } = false;

        private bool _HasSetEmailContent { set; get; } = false;

        /// <summary>
        /// 邮件接收者
        /// </summary>
        private Collection<MailAddress> Receivers { set; get; }

        /// <summary>
        /// 抄送
        /// </summary>
        private Collection<MailAddress> CarbonCopy { set; get; }

        /// <summary>
        /// 密送
        /// </summary>
        private Collection<MailAddress> BlindCarbonCopy { set; get; }


        /// <summary>
        /// 
        /// </summary>
        public Email() { }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        public Email(EmailContent content)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceConfig"></param>
        public Email(EmailServiceConfig serviceConfig)
        {
            SetServiceConfig(serviceConfig);
            _HasSetServiceConfig = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceConfig"></param>
        /// <param name="emailContent"></param>
        public Email(EmailServiceConfig serviceConfig, EmailContent emailContent)
        {

        }

        private void SetServiceConfig(EmailServiceConfig serviceConfig)
        {
            if (serviceConfig == null) throw new ArgumentNullException("未将对象引用设置到对象的实例。");
            if (serviceConfig.Host.IsNullOrEmpty()) throw new ArgumentNullException("未指定邮件服务的端口。");
            if (serviceConfig.EmailAddress.IsNullOrEmpty()) throw new ArgumentNullException("未指定邮件服务的账号。");
            if (serviceConfig.Password.IsNullOrEmpty()) throw new ArgumentNullException("未指定邮件服务的密码。");
            if (serviceConfig.Port < 0 || ServiceConfig.Port >= int.MaxValue) throw new ArgumentOutOfRangeException("指定邮件服务的端口超出限定范围。");

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
        /// 创建邮件
        /// </summary>
        /// <param name="emailContent"></param>
        /// <returns></returns>
        private void SetMailMessage(EmailContent emailContent)
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

            //if (receiver.Receivers == null || receiver.Receivers.Count < 0)
            //    throw new SmtpFailedRecipientException("至少需要一个接收邮件的地址。");

            //receiver.Receivers.ForEach(item =>
            //{
            //    mailMessage.To.Add(item);
            //});

            // 附件
            if (emailContent.Attachment != null && emailContent.Attachment.Count > 0)
            {
                emailContent.Attachment.ForEach(item => { _MailMessage.Attachments.Add(item); });
            }

            //// 抄送
            //if (receiver.CarbonCopy != null && receiver.CarbonCopy.Count > 0)
            //{
            //    receiver.CarbonCopy.ForEach(item => { mailMessage.CC.Add(item); });
            //}

            //// 密送
            //if (receiver.BlindCarbonCopy != null && receiver.BlindCarbonCopy.Count > 0)
            //{
            //    receiver.BlindCarbonCopy.ForEach(item => { mailMessage.Bcc.Add(item); });
            //}
        }

        public bool Send()
        {
            return false;
        }

        public bool SendAsync()
        {
            return false;
        }

        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="receiver"></param>
        /// <returns></returns>
        public bool SendEmail(EmailContent receiver)
        {
            //var mail = CreateMailMessage(receiver);
            //_Client.Send(mail);
            return true;
        }

        /// <summary>
        /// 发送邮件给多人
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool SendEmail(List<EmailContent> list)
        {
            list.ForEach(item =>
            {
                //var mail = CreateMailMessage(item);
                //_Client.Send(mail);
            });
            return true;
        }

        /// <summary>
        /// 异步发送邮件
        /// </summary>
        /// <param name="receiver"></param>
        /// <returns></returns>
        public async Task<bool> SendEmailAsync(EmailContent receiver)
        {
            //var mail = CreateMailMessage(receiver);
            //await _Client.SendMailAsync(mail);
            return true;
        }

        /// <summary>
        /// 异步发送邮件给多人
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public async Task<bool> SendEmailAsync(List<EmailContent> list)
        {
            //foreach (var item in list)
            //{
            //    var mail = CreateMailMessage(item);
            //    await _Client.SendMailAsync(mail);
            //}
            return true;
        }
    }
}
