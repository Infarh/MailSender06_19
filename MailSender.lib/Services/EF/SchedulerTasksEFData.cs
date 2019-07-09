using System;
using System.Threading.Tasks;
using MailSender.lib.Data;
using MailSender.lib.Data.EF;

namespace MailSender.lib.Services.EF
{
    public class SchedulerTasksEFData : EFData<SchedulerTask>, ISchedulerTasksDataService
    {
        public SchedulerTasksEFData(MailSenderDB DB) : base(DB) { }

        public override SchedulerTask Edit(int id, SchedulerTask item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));

            var db_item = GetById(id);
            if (db_item is null) return null;

            db_item.Time = item.Time;
            db_item.Message = item.Message;
            db_item.Recipients = item.Recipients;
            db_item.Sender = item.Sender;
            db_item.Server = item.Server;

            Commit();
            return db_item;
        }

        public override async Task<SchedulerTask> EditAsync(int id, SchedulerTask item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));

            var db_item = await GetByIdAsync(id).ConfigureAwait(false);
            if (db_item is null) return null;

            db_item.Time = item.Time;
            db_item.Message = item.Message;
            db_item.Recipients = item.Recipients;
            db_item.Sender = item.Sender;
            db_item.Server = item.Server;

            await CommitAsync().ConfigureAwait(false);
            return db_item;
        }
    }
}