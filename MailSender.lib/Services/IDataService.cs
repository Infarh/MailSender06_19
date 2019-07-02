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

        Task<IEnumerable<T>> GetAllAsync();

        T GetById(int id);

        Task<T> GetByIdAsync(int id);

        /// <summary>Создать (зарегистрировать)</summary>
        /// <returns>Возвращает идентификатор добавленной сущности</returns>
        void Add(T item);

        Task AddAsync(T item);

        /// <summary>Обновить</summary>
        void Edit(T item);

        Task EditAsync(T item);

        /// <summary>Удалить</summary>
        void Delete(T item);

        Task DeleteAsync(T item);
    }
}
