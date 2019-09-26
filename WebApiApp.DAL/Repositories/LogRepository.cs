using GenericRepository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiApp.DAL.Entities;

namespace WebApiApp.DAL.Repositories
{
    public class LogRepository : BaseRepository<Log>
    {
        public LogRepository(DbContext db) : base(db)
        {
        }
    }
}
