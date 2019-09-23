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
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Log>()
                .Property(e => e.Request)
                .IsUnicode(false);

            modelBuilder.Entity<Log>()
                .Property(e => e.Response)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);
        }
    }
}
