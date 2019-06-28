using MailSender.lib.Data.BaseEntityes;

namespace MailSender.lib.Data
{
    /// <summary>Сообщение электронной почты</summary>
    public class MailMessage : Entity
    {
        /// <summary>Тема</summary>
        public string Subject { get; set; }

        /// <summary>Тело сообщения</summary>
        public string Body { get; set; }
    }
}