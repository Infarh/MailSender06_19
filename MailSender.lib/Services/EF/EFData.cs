using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSender.lib.Data.BaseEntityes;
using MailSender.lib.Data.EF;

namespace MailSender.lib.Services.EF
{
    public abstract class EFData<T> : IDataService<T> where T : Entity
    {
        protected readonly MailSenderDB _DB;
        protected readonly DbSet<T> _Set;

        public EFData(MailSenderDB DB)
        {
            _DB = DB;
            _Set = DB.Set<T>();
        }

        public IEnumerable<T> GetAll() => _Set.ToArray();

        public async Task<IEnumerable<T>> GetAllAsync() => await _Set.ToArrayAsync().ConfigureAwait(false);

        public T GetById(int id) => _Set.FirstOrDefault(item => item.Id == id);

        public async Task<T> GetByIdAsync(int id) => await _Set.FirstOrDefaultAsync(item => item.Id == id).ConfigureAwait(false);

        public int Add(T item)
        {
            if(item is null) throw new ArgumentNullException(nameof(item));
            _Set.Add(item);
            Commit();
            return item.Id;
        }

        public async Task<int> AddAsync(T item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));
            _Set.Add(item);
            await CommitAsync();
            return item.Id;
        }

        public abstract T Edit(int id, T item);

        public abstract Task<T> EditAsync(int id, T item);

        public bool Delete(int id)
        {
            var db_item = GetById(id);
            if (db_item is null) return false;
            _Set.Remove(db_item);
            return Commit();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var db_item = await GetByIdAsync(id).ConfigureAwait(false);
            if (db_item is null) return false;
            _Set.Remove(db_item);
            return await CommitAsync();
        }

        public bool Commit() => _DB.SaveChanges() > 0;

        public async Task<bool> CommitAsync() => await _DB.SaveChangesAsync().ConfigureAwait(false) > 0;
    }
}
