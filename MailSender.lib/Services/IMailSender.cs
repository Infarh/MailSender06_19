using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MailSender.lib.Data;

namespace MailSender.lib.Services
{
    public interface IMailSender
    {
        void Send(MailMessage Message, Sender From, Recipient To);
        void Send(MailMessage Message, Sender From, IEnumerable<Recipient> To);

        void SendParallel(MailMessage Message, Sender From, IEnumerable<Recipient> To);

        Task SendAsync(MailMessage Message, Sender From, Recipient To);
        Task SendAsync(MailMessage Message, Sender From, IEnumerable<Recipient> To, 
            IProgress<double> Progress = null, CancellationToken Cancel = default);
    }
}