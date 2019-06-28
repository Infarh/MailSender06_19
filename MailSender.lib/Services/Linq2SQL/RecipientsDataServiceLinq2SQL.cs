using System.Collections.Generic;
using System.Linq;
using MailSender.lib.Data;

namespace MailSender.lib.Services.Linq2SQL
{
    /// <summary>Реализация сервиса работы с получателями для источника данных - контекста БД Linq2SQL</summary>
    public class RecipientsDataServiceLinq2SQL : IRecipientsDataService
    {
        /// <summary>Контектс базы данных</summary>
        private readonly MailSender.lib.Data.Linq2SQL.MailSenderDBContext _db;

        /// <summary>Инициализация нового сервиса <seealso cref="RecipientsDataServiceLinq2SQL"/></summary>
        /// <param name="db">Контекст БД Linq2SQL</param>
        public RecipientsDataServiceLinq2SQL(MailSender.lib.Data.Linq2SQL.MailSenderDBContext db) => _db = db;


        /// <summary>Извлечь всех получателей из контекста БД</summary>
        /// <returns>Перечисление всех получателей, хранимый в контексте БД</returns>
        public IEnumerable<Recipient> GetAll() => _db.Recipient
           .Select(r => new Recipient
            {
                Id = r.Id,
                Name = r.Name,
                Address = r.Address,
                Description = r.Description
            })
           .ToArray();

        public Recipient GetById(int id) => _db.Recipient
           .Select(r => new Recipient
            {
                Id = r.Id,
                Name = r.Name,
                Address = r.Address,
                Description = r.Description
            })
           .FirstOrDefault(r => r.Id == id);

        /// <summary>Создать (зарегистрировать) нового получателя почты в контексте БД</summary>
        /// <param name="item">Создаваемый новый получатель</param>
        public void Add(Recipient item)
        {
            if (item.Id != 0) return;
            _db.Recipient.InsertOnSubmit(new Data.Linq2SQL.Recipient
            {
                Name = item.Name,
                Address = item.Address,
                Description = item.Description
            });
            _db.SubmitChanges();
        }

        /// <summary>Обновить данные получателя</summary>
        /// <param name="item">Получатель почты, данные которого требуется обновить</param>
        public void Edit(Recipient item) => _db.SubmitChanges();

        /// <summary>Удалить получателя из БД</summary>
        /// <param name="item">Получатель почты, которого требуется удалить</param>
        public void Delete(Recipient item)
        {
            var db_item = _db.Recipient.FirstOrDefault(i => i.Id == item.Id);
            if(db_item is null) return;
            _db.Recipient.DeleteOnSubmit(db_item);
            _db.SubmitChanges();
        }
    }
}
