namespace WebApiApp.Console
{
    using System;
    using System.Collections.Generic;

    public class Log
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Request { get; set; }

        public string RequestMethod { get; set; }

        public int ResponseDataCount { get; set; }

        public int ResponseStatus { get; set; }
    }
}
