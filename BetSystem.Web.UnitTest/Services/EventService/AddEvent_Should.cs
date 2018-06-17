using BetSystem.Data.Contracts;
using BetSystem.Data.Models;
using BetSystem.Services.DTO;
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
    public class AddEvent_Should
    {
        [Test]
        public void ThrowException_WhenPassedNullEvent()
        {
            // Arrange
            var eventRepositoryMock = new Mock<IGenericRepository<Event>>();

            // Act
            var eventService = new BetSystem.Services.EventService(eventRepositoryMock.Object);

            // Assert
            Assert.Throws<ArgumentNullException>(() => eventService.AddEvent(null));
        }

        [Test]
        public void ThrowException_WhenPassedOddForFirstTeamLessThanOne()
        {
            // Arrange
            var eventRepositoryMock = new Mock<IGenericRepository<Event>>();
            var eventModel = new EventDTO()
            {
                EventName = "Roma vs Inter",
                OddsForFirstTeam = 0,
                OddsForDraw = 2,
                OddsForSecondTeam = 3,
                EventStartDate = new DateTime(19, 1, 1, 1, 1, 1)
            };

            // Act
            var eventService = new BetSystem.Services.EventService(eventRepositoryMock.Object);

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => eventService.AddEvent(eventModel));
        }

        [Test]
        public void ThrowException_WhenPassedOddForDrawLessThanOne()
        {
            // Arrange
            var eventRepositoryMock = new Mock<IGenericRepository<Event>>();
            var eventModel = new EventDTO()
            {
                EventName = "Roma vs Inter",
                OddsForFirstTeam = 1,
                OddsForDraw = 0,
                OddsForSecondTeam = 3,
                EventStartDate = new DateTime(19, 1, 1, 1, 1, 1)
            };

            // Act
            var eventService = new BetSystem.Services.EventService(eventRepositoryMock.Object);

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => eventService.AddEvent(eventModel));
        }

        [Test]
        public void ThrowException_WhenPassedOddForSecondTeamLessThanOne()
        {
            // Arrange
            var eventRepositoryMock = new Mock<IGenericRepository<Event>>();
            var eventModel = new EventDTO()
            {
                EventName = "Roma vs Inter",
                OddsForFirstTeam = 1,
                OddsForDraw = 1,
                OddsForSecondTeam = 0,
                EventStartDate = new DateTime(19, 1, 1, 1, 1, 1)
            };

            // Act
            var eventService = new BetSystem.Services.EventService(eventRepositoryMock.Object);

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => eventService.AddEvent(eventModel));
        }
    }
}
