using System;
using System.Threading.Tasks;
using MailSender.lib.Data;
using MailSender.lib.Data.EF;

namespace MailSender.lib.Services.EF
{
    public class SendersEFData : EFData<Sender>, ISendersDataService
    {
        public SendersEFData(MailSenderDB DB) : base(DB) { }

        public override Sender Edit(int id, Sender item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));

            var db_item = GetById(id);
            if (db_item is null) return null;

            db_item.Name = item.Name;
            db_item.Address = item.Address;
            db_item.Description = item.Description;

            Commit();
            return db_item;
        }

        public override async Task<Sender> EditAsync(int id, Sender item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));

            var db_item = await GetByIdAsync(id).ConfigureAwait(false);
            if (db_item is null) return null;

            db_item.Name = item.Name;
            db_item.Address = item.Address;
            db_item.Description = item.Description;

            await CommitAsync().ConfigureAwait(false);
            return db_item;
        }
    }
}