namespace MailSender.lib.Data
{
    /// <summary>Сообщение электронной почты</summary>
    public class MailMessage
    {
        /// <summary>Тема</summary>
        public string Subject { get; set; }

        /// <summary>Тело сообщения</summary>
        public string Body { get; set; }
    }
}