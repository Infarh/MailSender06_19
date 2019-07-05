using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<IEnumerable<Recipient>> GetAllAsync() => await Task.Run(GetAll);

        public Recipient GetById(int id) => _db.Recipient
           .Select(r => new Recipient
           {
               Id = r.Id,
               Name = r.Name,
               Address = r.Address,
               Description = r.Description
           })
           .FirstOrDefault(r => r.Id == id);

        public async Task<Recipient> GetByIdAsync(int id) => await Task.Run(() => GetById(id));

        /// <summary>Создать (зарегистрировать) нового получателя почты в контексте БД</summary>
        /// <param name="item">Создаваемый новый получатель</param>
        public int Add(Recipient item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));
            if (item.Id != 0) return item.Id;
            _db.Recipient.InsertOnSubmit(new Data.Linq2SQL.Recipient
            {
                Name = item.Name,
                Address = item.Address,
                Description = item.Description
            });
            _db.SubmitChanges();
            return item.Id;
        }

        public async Task<int> AddAsync(Recipient item) => await Task.Run(() => Add(item));

        /// <summary>Обновить данные получателя</summary>
        /// <param name="item">Получатель почты, данные которого требуется обновить</param>
        public Recipient Edit(int id, Recipient item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));
            var db_item = _db.Recipient.FirstOrDefault(r => r.Id == id);
            if (db_item is null) return null;

            db_item.Name = item.Name;
            db_item.Address = item.Address;
            db_item.Description = item.Description;

            _db.SubmitChanges();

            return new Recipient
            {
                Id = db_item.Id,
                Name = db_item.Name,
                Address = db_item.Address,
                Description = db_item.Description
            };
        }

        public async Task<Recipient> EditAsync(int id, Recipient item) => await Task.Run(() => Edit(id, item));

        /// <summary>Удалить получателя из БД</summary>
        /// <param name="id">Идентификатор получателя почты</param>
        public bool Delete(int id)
        {
            var db_item = _db.Recipient.FirstOrDefault(i => i.Id == id);
            if (db_item is null) return false;
            _db.Recipient.DeleteOnSubmit(db_item);
            _db.SubmitChanges();
            return true;
        }

        public async Task<bool> DeleteAsync(int id) => await Task.Run(() => Delete(id));
    }
}
