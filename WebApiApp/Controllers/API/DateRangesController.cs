using System;
using System.Linq;
using System.Net;
using System.Web.Http;
using WebApiApp.BOL.DTO;
using WebApiApp.BOL.Service.Services;

namespace WebApiApp.Controllers.API
{
    [Authorize]
    public class DateRangesController : ApiController
    {
        private DateRangeDTOService dateRangeDTOService;
        private LogDTOService logDTOService;

        public DateRangesController(DateRangeDTOService dateRangeService, LogDTOService logService)
        {
            this.dateRangeDTOService = dateRangeService;
            this.logDTOService = logService;
        }

        // GET: api/DateRages
        public IHttpActionResult Get()
        {
            IHttpActionResult response;
            LogDTO log = new LogDTO()
            {
                Request = Request.RequestUri.PathAndQuery,
                Date = DateTime.Now,
                RequestMethod = "GET"
            };

            try
            {
                var ranges = dateRangeDTOService.GetAll();

                log.ResponseStatus = (int)HttpStatusCode.OK;
                log.ResponseDataCount = ranges.Count();

                response = Ok(ranges);
            }
            catch (Exception ex)
            {
                log.ResponseStatus = (int)HttpStatusCode.BadRequest;

                response = BadRequest(ex.Message);
            }

            logDTOService.Add(log);
            logDTOService.Save();

            return response;
        }


        public IHttpActionResult Get(DateTime from, DateTime to)
        {
            IHttpActionResult response;
            DateRangeDTO value = new DateRangeDTO { From = from, To = to };
            LogDTO log = new LogDTO()
            {
                Date = DateTime.Now,
                Request = Request.RequestUri.PathAndQuery,
                RequestMethod = "GET"
            };

            try
            {
                var ranges = dateRangeDTOService
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

            logDTOService.Add(log);
            logDTOService.Save();

            return response;
        }

        // POST: api/DateRages
        public IHttpActionResult Post([FromBody]DateRangeDTO value)
        {
            IHttpActionResult response;
            LogDTO log = new LogDTO()
            {
                Date = DateTime.Now,
                Request = Request.RequestUri.PathAndQuery,
                RequestMethod = "POST"
            };

            try
            {
                if (value.Id == 0)
                {
                    var data = dateRangeDTOService.Add(value);
                    response = Created("database", value);

                    log.ResponseDataCount = 1;
                    log.ResponseStatus = (int)HttpStatusCode.Created;
                }
                else
                {
                    dateRangeDTOService.Update(value);
                    response = Ok(value);

                    log.ResponseStatus = (int)HttpStatusCode.OK;
                }

                dateRangeDTOService.Save();
            }
            catch (Exception ex)
            {
                 response = BadRequest(ex.Message);

                log.ResponseStatus = (int)HttpStatusCode.BadRequest;
            }

            logDTOService.Add(log);
            logDTOService.Save();

            return response;
        }
    }
}
