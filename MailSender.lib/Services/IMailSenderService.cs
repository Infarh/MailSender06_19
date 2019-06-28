using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSender.lib.Data;

namespace MailSender.lib.Services
{
    public interface IMailSenderService
    {
        IMailSender CreateSender(Server Server);
    }
}
