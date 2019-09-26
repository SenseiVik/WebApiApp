using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebApiApp.BOL.DTO;
using WebApiApp.Controllers.API;
using WebApiApp.BOL.Service.Interfaces;
using System.Web.Http;
using System.Net.Http;

namespace WebApiApp.Tests.Controllers
{
    [TestClass]
    class DateRangesControllerTest
    {
        [TestMethod]
        public void Get()
        {
            // Arrange
            var dateRangeService = new Mock<IEntityService<DateRangeDTO>>();
            dateRangeService.Setup(x => x.GetAll()).Returns(new List<DateRangeDTO>()
            {
                new DateRangeDTO()
                {
                    Id = 1,
                    From = Convert.ToDateTime("2018-01-01"),
                    To = Convert.ToDateTime("2018-01-03")
                }
            });

            LogDTO log = new LogDTO()
            {
                Id = 3,
                Date = Convert.ToDateTime("2018-01-01"),
                Request = "api/dateranges",
                RequestMethod = "GET",
                ResponseDataCount = 3,
                ResponseStatus = 200
            };

            var logService = new Mock<IEntityService<LogDTO>>();
            logService.Setup(x => x.Add(log)).Returns(log);

            DateRangesController controller = new DateRangesController(dateRangeService.Object, logService.Object);

            // Act
            HttpResponseMessage result = controller.Get() as HttpResponseMessage;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.StatusCode, System.Net.HttpStatusCode.OK);
            Assert.AreNotEqual(result.Content.ReadAsStringAsync().Result, "");
        }
    }
}
