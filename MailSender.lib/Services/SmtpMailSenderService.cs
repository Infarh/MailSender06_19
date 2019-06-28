using MailSender.lib.Data;

namespace MailSender.lib.Services
{
    public class SmtpMailSenderService : IMailSenderService
    {
        public IMailSender CreateSender(Server Server) =>
            new SmtpMailSender(Server.Address, Server.Port, Server.UseSSL, Server.UserName, Server.Password);
    }
}