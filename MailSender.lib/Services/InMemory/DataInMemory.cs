using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailSender.lib.Data.BaseEntityes;
using MailSender.lib.Service;

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

        public int Add(T item)
        {
            if(item is null) throw new ArgumentNullException(nameof(item));
            if (_Items.Any(i => i.Id == item.Id)) return item.Id;
            item.Id = _Items.Count == 0 ? 1 : _Items.Max(i => i.Id) + 1;
            _Items.Add(item);
            return item.Id;
        }

        public async Task<int> AddAsync(T item) => await Task.Run(() => Add(item));

        public virtual T Edit(int id, T item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));

            var db_item = GetById(id);
            if (db_item is null) return null;

            item.CopyTo(db_item);

            return db_item;
        }

        public virtual async Task<T> EditAsync(int id, T item) => await Task.Run(() => Edit(id, item));

        public bool Delete(int id) => _Items.Remove(GetById(id));

        public async Task<bool> DeleteAsync(int id) => await Task.Run(() => Delete(id));
    }
}
