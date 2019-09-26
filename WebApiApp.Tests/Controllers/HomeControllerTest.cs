using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApiApp;
using WebApiApp.Controllers;
using WebApiApp.Controllers.Auth;

namespace WebApiApp.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void LogIn()
        {
            // Arrange
            AuthController controller = new AuthController();

            // Act
            ViewResult result = controller.LogIn() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Log In Page", result.ViewBag.Title);
        }

        [TestMethod]
        public void Register()
        {
            // Arrange
            AuthController controller = new AuthController();

            // Act
            ViewResult result = controller.Register() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Register Page", result.ViewBag.Title);
        }
    }
}
