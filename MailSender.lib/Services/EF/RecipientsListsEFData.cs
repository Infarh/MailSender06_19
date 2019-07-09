using System;
using System.Threading.Tasks;
using MailSender.lib.Data;
using MailSender.lib.Data.EF;

namespace MailSender.lib.Services.EF
{
    public class RecipientsListsEFData : EFData<RecipientsList>, IRecipientsListsDataService
    {
        public RecipientsListsEFData(MailSenderDB DB) : base(DB) { }

        public override RecipientsList Edit(int id, RecipientsList item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));

            var db_item = GetById(id);
            if (db_item is null) return null;

            db_item.Name = item.Name;
            db_item.Recipients = item.Recipients;

            Commit();
            return db_item;
        }

        public override async Task<RecipientsList> EditAsync(int id, RecipientsList item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));

            var db_item = await GetByIdAsync(id).ConfigureAwait(false);
            if (db_item is null) return null;

            db_item.Name = item.Name;
            db_item.Recipients = item.Recipients;

            await CommitAsync().ConfigureAwait(false);
            return db_item;
        }
    }
}