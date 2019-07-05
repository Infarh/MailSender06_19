using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSender.lib.Data;

namespace MailSender.lib.Services.InMemory
{
    public class SendersDataInMemory : DataInMemory<Sender>, ISendersDataService
    {
        public SendersDataInMemory()
        {
            for (var i = 1; i < 10; i++)
                _Items.Add(new Sender { Id = i, Name = $"Отправитель {i}", Address = $"sender{i}@server.com" });
        }

        public override Sender Edit(int id, Sender item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));

            var db_item = GetById(id);
            if (db_item is null) return null;

            db_item.Name = item.Name;
            db_item.Address = item.Address;
            return db_item;
        }
    }
}
