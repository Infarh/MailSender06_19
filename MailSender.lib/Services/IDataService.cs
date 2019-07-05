using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.lib.Services
{
    /// <summary>Сервис доступа к данным</summary>
    /// <typeparam name="T">Тип данных хранимого элемента</typeparam>
    public interface IDataService<T>
    {
        /// <summary>Извлечь все элементы</summary>
        /// <returns>Перечисление всех элементов, хранимых в сервисе</returns>
        IEnumerable<T> GetAll();

        /// <summary>Асинхронно извлечь все элементы</summary>
        /// <returns>Задача, возвращающая перечисление всех элементов, хранимых в сервисе</returns>
        Task<IEnumerable<T>> GetAllAsync();

        /// <summary>Получить элемент по заданному идентификатору</summary>
        /// <param name="id">Идентификатор элемента</param>
        /// <returns>Элемент с заданным идентификатором, либо null</returns>
        T GetById(int id);

        /// <summary>Асинхронного получить элемент по заданному идентификатору</summary>
        /// <param name="id">Идентификатор элемента</param>
        /// <returns>Задача асинхронного получения элемента с заданным идентификатором</returns>
        Task<T> GetByIdAsync(int id);

        /// <summary>Добавить новый элемент в сервис</summary>
        /// <returns>Возвращает идентификатор добавленной сущности</returns>
        void Add(T item);

        /// <summary>Асинхронно добавить новый элемент в сервис</summary>
        /// <param name="item">Добавляемый элемент</param>
        /// <returns>Задача по добавлению нового элемента в сервис</returns>
        Task AddAsync(T item);

        /// <summary>Редактировать элемент в сервисе</summary>
        void Edit(T item);

        /// <summary>Асинхронно редактировать элемент в сервисе</summary>
        /// <param name="item">Редактируемый элемент</param>
        /// <returns>Задача внесения изменений в данные сервиса</returns>
        Task EditAsync(T item);

        /// <summary>Удалить</summary>
        void Delete(T item);

        /// <summary>Асинхронно удалить элемент из данных сервиса</summary>
        /// <param name="item">Удаляемый элемент</param>
        /// <returns>Задача удаления элемента из сервиса</returns>
        Task DeleteAsync(T item);
    }
}
