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
        public override void Edit(Sender item)
        {
            if(item is null) throw new ArgumentNullException(nameof(item));

            var db_item = GetById(item.Id);
            if(db_item is null) return;

            db_item.Name = item.Name;
            db_item.Address = item.Address;
        }
    }
}
