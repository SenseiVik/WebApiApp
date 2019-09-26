using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepository.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        TEntity Get(int id);
        TEntity Create(TEntity entity);
        void Update(TEntity entity);
        TEntity Delete(TEntity entity);
        void Save();
    }
}
