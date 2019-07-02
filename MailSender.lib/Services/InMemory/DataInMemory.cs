using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailSender.lib.Data.BaseEntityes;

namespace MailSender.lib.Services.InMemory
{
    public abstract class DataInMemory<T> : IDataService<T> where T : Entity
    {
        protected readonly List<T> _Items = new List<T>();

        public IEnumerable<T> GetAll() => _Items;
        public Task<IEnumerable<T>> GetAllAsync() => Task.FromResult((IEnumerable<T>)_Items);

        public T GetById(int id)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), id, "Значение id должно быть болше 0");

            return _Items.FirstOrDefault(item => item.Id == id);
        }

        public async Task<T> GetByIdAsync(int id) => await Task.Run(() => GetById(id));

        public void Add(T item)
        {
            if (_Items.Any(i => i.Id == item.Id)) return;
            item.Id = _Items.Count == 0 ? 1 : _Items.Max(i => i.Id) + 1;
            _Items.Add(item);
        }

        public async Task AddAsync(T item) => await Task.Run(() => Add(item));

        public abstract void Edit(T item);

        public virtual async Task EditAsync(T item) => await Task.Run(() => Edit(item));

        public void Delete(T item) => _Items.Remove(item);

        public async Task DeleteAsync(T item) => await Task.Run(() => Delete(item));
    }
}
