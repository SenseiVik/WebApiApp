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
    public class DateRangeRepository : BaseRepository<DateRange>
    {
        public DateRangeRepository(DbContext db) : base(db)
        {
        }
    }
}
