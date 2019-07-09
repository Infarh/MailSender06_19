using System;
using MailSender.lib.Data;

namespace MailSender.lib.Services.InMemory
{
    public class MailMessagesDataInMemory : DataInMemory<MailMessage>, IMailMessageDataService
    {
        public MailMessagesDataInMemory()
        {
            for(var i = 1; i <= 10; i++)
                _Items.Add(new MailMessage { Id = i, Subject = $"Письмо {i}", Body = $"Текст письма {i}"});
        }

        //public override MailMessage Edit(int id, MailMessage item)
        //{
        //    if (item is null) throw new ArgumentNullException(nameof(item));

        //    var db_item = GetById(id);
        //    if (db_item is null) return null;

        //    db_item.Subject = item.Subject;
        //    db_item.Body = item.Body;
        //    return db_item;
        //}
    }
}