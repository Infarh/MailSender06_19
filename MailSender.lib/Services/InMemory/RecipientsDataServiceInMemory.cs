using System;
using System.Collections.Generic;
using MailSender.lib.Data;

namespace MailSender.lib.Services.InMemory
{
    public class RecipientsDataServiceInMemory : DataInMemory<Recipient>, IRecipientsDataService
    {
        public RecipientsDataServiceInMemory()
        {
            var test_data = new List<Recipient>
            {
                new Recipient { Id = 1, Name = "Иванов", Address = "ivanov@yandex.ru", Description = "" },
                new Recipient { Id = 2, Name = "Петров", Address = "petrov@yandex.ru", Description = "" },
                new Recipient { Id = 3, Name = "Сидоров", Address = "sidorov@yandex.ru", Description = "" }
            };
            _Items.AddRange(test_data);
        }

        public override Recipient Edit(int id, Recipient item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));

            var db_item = GetById(id);
            if (db_item is null) return null;

            db_item.Name = item.Name;
            db_item.Address = item.Address;
            db_item.Description = item.Description;
            return db_item;
        }
    }
}
