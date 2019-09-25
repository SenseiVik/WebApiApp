using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiApp.DAL.Context;
using WebApiApp.DAL.Entities;
using WebApiApp.DAL.Repositories;

namespace WebApiApp.Controllers.API
{
    [Authorize]
    public class DateRangesController : ApiController
    {
        private DateRangeRepository _dateRangeRepository;
        private LogRepository _logRepository;

        public DateRangesController(DbContext db)
        {
            this._dateRangeRepository = new DateRangeRepository(db);
            this._logRepository = new LogRepository(db);
        }

        // GET: api/DateRages
        public IHttpActionResult Get()
        {
            IHttpActionResult response;
            Log log = new Log()
            {
                Request = Request.RequestUri.PathAndQuery,
                Date = DateTime.Now,
                RequestMethod = "GET"
            };

            try
            {
                var ranges = _dateRangeRepository.GetAll();

                log.ResponseStatus = (int)HttpStatusCode.OK;
                log.ResponseDataCount = ranges.Count();

                response = Ok(ranges);
            }
            catch (Exception ex)
            {
                log.ResponseStatus = (int)HttpStatusCode.BadRequest;

                response = BadRequest(ex.Message);
            }

            _logRepository.Create(log);
            _logRepository.Save();

            return response;
        }


        public IHttpActionResult Get(DateTime from, DateTime to)
        {
            IHttpActionResult response;
            DateRange value = new DateRange { From = from, To = to };
            Log log = new Log()
            {
                Date = DateTime.Now,
                Request = Request.RequestUri.PathAndQuery,
                RequestMethod = "GET"
            };

            try
            {
                var ranges = _dateRangeRepository
                                        .GetAll()
                                        .Where(range => value.From <= range.To && value.To >= range.To);
                
                log.ResponseStatus = (int)HttpStatusCode.OK;
                log.ResponseDataCount = ranges.Count();

                response = Ok(ranges);
            }       
            catch (Exception ex)
            {
                log.ResponseStatus = (int)HttpStatusCode.BadRequest;

                response = BadRequest(ex.Message);
            }

            _logRepository.Create(log);
            _logRepository.Save();

            return response;
        }

        // POST: api/DateRages
        public IHttpActionResult Post([FromBody]DateRange value)
        {
            IHttpActionResult response;
            Log log = new Log()
            {
                Date = DateTime.Now,
                Request = Request.RequestUri.PathAndQuery,
                RequestMethod = "POST"
            };

            try
            {
                if (value.Id == 0)
                {
                    var data = _dateRangeRepository.Create(value);
                    response = Created("database", value);

                    log.ResponseDataCount = 1;
                    log.ResponseStatus = (int)HttpStatusCode.Created;
                }
                else
                {
                    _dateRangeRepository.Update(value);
                    response = Ok(value);

                    log.ResponseStatus = (int)HttpStatusCode.OK;
                }

                _dateRangeRepository.Save();
            }
            catch (Exception ex)
            {
                 response = BadRequest(ex.Message);

                log.ResponseStatus = (int)HttpStatusCode.BadRequest;
            }

            _logRepository.Create(log);
            _logRepository.Save();

            return response;
        }
    }
}
