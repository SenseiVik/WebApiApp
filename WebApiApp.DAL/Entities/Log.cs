namespace WebApiApp.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Log")]
    public class Log
    {
        public int Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        [StringLength(100)]
        public string Request { get; set; }

        [StringLength(100)]
        public string RequestMethod { get; set; }

        public int ResponseDataCount { get; set; }

        public int ResponseStatus { get; set; }
    }
}
