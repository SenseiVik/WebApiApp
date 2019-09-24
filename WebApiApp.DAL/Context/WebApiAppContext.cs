namespace WebApiApp.DAL.Context
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using WebApiApp.DAL.Entities;

    public partial class WebApiAppContext : DbContext
    {
        public WebApiAppContext()
            : base("name=WebApiAppContext")
        {
        }

        public virtual DbSet<DateRange> DateRange { get; set; }
        public virtual DbSet<Log> Log { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
    }
}
