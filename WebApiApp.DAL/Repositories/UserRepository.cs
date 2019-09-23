using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiApp.DAL.Abstract;
using WebApiApp.DAL.Entities;

namespace WebApiApp.DAL.Repositories
{
    class UserRepository : BaseRepository<User>
    {
        public UserRepository(DbContext db) : base(db)
        {
        }
    }
}
