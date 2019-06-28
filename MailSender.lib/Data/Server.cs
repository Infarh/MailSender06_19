using MailSender.lib.Data.BaseEntityes;

namespace MailSender.lib.Data
{
    /// <summary>Почтовый сервер</summary>
    public class Server : NamedEntity
    {
        /// <summary>Адрес</summary>
        public string Address { get; set; }

        /// <summary>Порт</summary>
        public int Port { get; set; } = 25;

        /// <summary>Использовать ли защищённый канал для передачи данных?</summary>
        public bool UseSSL { get; set; } = true;

        /// <summary>Имя пользователя</summary>
        public string UserName { get; set; }

        /// <summary>Пароль</summary>
        public string Password { get; set; }
    }
}