using System;
using System.Threading.Tasks;
using MailSender.lib.Data;
using MailSender.lib.Data.EF;
using MailSender.lib.Service;

namespace MailSender.lib.Services.EF
{
    public class MailMessagesEFData : EFData<MailMessage>, IMailMessageDataService
    {
        public MailMessagesEFData(MailSenderDB DB) : base(DB) { }

        public override MailMessage Edit(int id, MailMessage item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));

            var db_item = GetById(id);
            if (db_item is null) return null;

            item.CopyTo(db_item);
            //db_item.Subject = item.Subject;
            //db_item.Body = item.Body;

            Commit();
            return db_item;
        }

        public override async Task<MailMessage> EditAsync(int id, MailMessage item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));

            var db_item = await GetByIdAsync(id).ConfigureAwait(false);
            if (db_item is null) return null;

            db_item.Subject = item.Subject;
            db_item.Body = item.Body;

            await CommitAsync().ConfigureAwait(false);
            return db_item;
        }
    }
}