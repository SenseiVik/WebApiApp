using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiApp.BOL.DTO
{
    public class LogDTO
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        [StringLength(100)]
        public string Request { get; set; }

        [StringLength(100)]
        public string RequestMethod { get; set; }

        public int ResponseDataCount { get; set; }

        public int ResponseStatus { get; set; }
    }
}
