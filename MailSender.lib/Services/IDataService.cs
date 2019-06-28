using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.lib.Services
{
    public interface IDataService<T>
    {
        /// <summary>Извлечь</summary>
        IEnumerable<T> GetAll();

        T GetById(int id);

        /// <summary>Создать (зарегистрировать)</summary>
        void Add(T item);

        /// <summary>Обновить</summary>
        void Edit(T item);

        /// <summary>Удалить</summary>
        void Delete(T item);
    }
}
