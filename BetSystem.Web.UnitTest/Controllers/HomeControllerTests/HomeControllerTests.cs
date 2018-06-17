using BetSystem.Web.Controllers;
using Moq;
using NUnit.Framework;
using System.Web.Mvc;
using TestStack.FluentMVCTesting;

namespace BetSystem.Web.UnitTest.Controllers.HomeControllerTests
{
    [TestFixture]
    public class HomeControllerTests
    {
        [Test]
        public void Index_ShouldRenderDefaultView_WhenCalled()
        {
            // Arrange
            var homeController = new HomeController();

            // Act
            ViewResult testResult = homeController.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(testResult);
        }
    }
}
