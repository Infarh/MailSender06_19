using System;
using System.Threading.Tasks;
using MailSender.lib.Data;
using MailSender.lib.Data.EF;

namespace MailSender.lib.Services.EF
{
    public class ServersEFData : EFData<Server>, IServerDataService
    {
        public ServersEFData(MailSenderDB DB) : base(DB) { }

        public override Server Edit(int id, Server item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));

            var db_item = GetById(id);
            if (db_item is null) return null;

            db_item.Name = item.Name;
            db_item.Address = item.Address;
            db_item.Port = item.Port;
            db_item.UseSSL = item.UseSSL;
            db_item.UserName = item.UserName;
            db_item.Password = item.Password;

            Commit();
            return db_item;
        }

        public override async Task<Server> EditAsync(int id, Server item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));

            var db_item = await GetByIdAsync(id).ConfigureAwait(false);
            if (db_item is null) return null;

            db_item.Name = item.Name;
            db_item.Address = item.Address;
            db_item.Port = item.Port;
            db_item.UseSSL = item.UseSSL;
            db_item.UserName = item.UserName;
            db_item.Password = item.Password;

            await CommitAsync().ConfigureAwait(false);
            return db_item;
        }
    }
}