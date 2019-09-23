using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiApp.DAL.Interfaces;

namespace WebApiApp.DAL.Abstract
{
    public class BaseRepository<TEntity> : IRepository<TEntity>, IDisposable where TEntity : class
    {
        private DbContext _db;

        public BaseRepository(DbContext db)
        {
            this._db = db;
        }

        public virtual TEntity Create(TEntity entity)
        {
            return _db.Set<TEntity>().Add(entity);
        }

        public virtual TEntity Delete(TEntity entity)
        {
            return _db.Set<TEntity>().Remove(entity);
        }

        public virtual void Dispose()
        {
            _db.Dispose();
        }

        public virtual TEntity Get(int id)
        {
            return _db.Set<TEntity>().Find(id);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return _db.Set<TEntity>();
        }

        public virtual void Save()
        {
            _db.SaveChanges();
        }

        public virtual void Update(TEntity entity)
        {
            _db.Entry<TEntity>(entity).State = EntityState.Modified;
        }
    }
}
