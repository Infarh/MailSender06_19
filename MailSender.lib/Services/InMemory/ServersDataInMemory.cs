using System;
using MailSender.lib.Data;

namespace MailSender.lib.Services.InMemory
{
    public class ServersDataInMemory : DataInMemory<Server>, IServerDataService
    {
        public ServersDataInMemory()
        {
            for (var i = 1; i <= 10; i++)
                _Items.Add(new Server { Id = i, Name = $"Сервер {i}", Address = $"smtp.server{i}.com" });
        }

        public override void Edit(Server item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));

            var db_item = GetById(item.Id);
            if (db_item is null) return;

            db_item.Name = item.Name;
            db_item.Address = item.Address;
            db_item.Port = item.Port;
            db_item.UseSSL = item.UseSSL;
            db_item.UserName = item.UserName;
            db_item.Password = item.Password;
        }
    }
}