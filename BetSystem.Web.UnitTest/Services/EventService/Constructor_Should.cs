using BetSystem.Data.Contracts;
using BetSystem.Data.Models;
using BetSystem.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetSystem.Web.UnitTest.Services.EventService
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ReturnsAnInstance_WhenParametersAreNotNull()
        {
            // Arrange
            var eventRepositoryMock = new Mock<IGenericRepository<Event>>();

            // Act & Assert
            Assert.DoesNotThrow(() => new BetSystem.Services.EventService(eventRepositoryMock.Object));
        }

        [Test]
        public void ThrowException_WhenEventRepositoryIsNull()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentNullException>(() => new BetSystem.Services.EventService(null));
        }
    }
}
