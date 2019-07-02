using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;
using MailSender.lib.Data;
using MailMessage = MailSender.lib.Data.MailMessage;

namespace MailSender.lib.Services
{
    public class SmtpMailSender : IMailSender
    {
        private readonly string _Host;
        private readonly int _Port;
        private readonly bool _UseSsl;
        private readonly string _Login;
        private readonly string _Password;

        public SmtpMailSender(string Host, int Port, bool UseSSL, string Login, string Password)
        {
            _Host = Host;
            _Port = Port;
            _UseSsl = UseSSL;
            _Login = Login;
            _Password = Password;
        }

        public void Send(MailMessage Message, Sender From, Recipient To)
        {
            using (var server = new SmtpClient(_Host, _Port) { EnableSsl = _UseSsl })
            {
                server.Credentials = new NetworkCredential(_Login, _Password);

                using (var msg = new System.Net.Mail.MailMessage())
                {
                    msg.From = new MailAddress(From.Address, From.Name);
                    msg.To.Add(new MailAddress(To.Address, To.Name));

                    server.Send(msg);
                }
            }
        }

        public void Send(MailMessage Message, Sender From, IEnumerable<Recipient> To)
        {
            foreach (var recipient in To)
                Send(Message, From, recipient);
        }

        public void SendParallel(MailMessage Message, Sender From, IEnumerable<Recipient> To)
        {
            //foreach (var recipient in To)
            //{
            //    var current_recipient = recipient; // опасность замыкания!
            //    new Thread(() => Send(Message, From, current_recipient))
            //    {
            //        Name = $"Поток отправки почты от {From.Name} к {recipient.Name}",
            //        Priority = ThreadPriority.BelowNormal,
            //        IsBackground = true
            //    }.Start();
            //}

            foreach (var recipient in To)
            {
                Debug.WriteLine($"Отправка почты {recipient.Name} : {recipient.Address}");

                var current_recipient = recipient;
                ThreadPool.QueueUserWorkItem(p => Send(Message, From, current_recipient));
            }
        }

        public async Task SendAsync(MailMessage Message, Sender From, Recipient To)
        {
            using (var server = new SmtpClient(_Host, _Port) { EnableSsl = _UseSsl })
            {
                server.Credentials = new NetworkCredential(_Login, _Password);

                using (var msg = new System.Net.Mail.MailMessage())
                {
                    msg.From = new MailAddress(From.Address, From.Name);
                    msg.To.Add(new MailAddress(To.Address, To.Name));

                    await server.SendMailAsync(msg);
                }
            }
        }

        public async Task SendAsync(
            MailMessage Message, 
            Sender From, IEnumerable<Recipient> To, 
            IProgress<double> Progress = null,
            CancellationToken Cancel = default)
        {
            #region Параллельный асинхронный процесс
            //await Task.WhenAll(To.Select(to => SendAsync(Message, From, to))); 
            #endregion

            #region Последовательный асинхронный процесс
            var to = To.ToArray();

            for (var i = 0; i < to.Length; i++)
            {
                Cancel.ThrowIfCancellationRequested();
                await SendAsync(Message, From, to[i]);
                Progress?.Report((double)i / to.Length);
            }

            Progress?.Report(1); 
            #endregion
        }
    }
}