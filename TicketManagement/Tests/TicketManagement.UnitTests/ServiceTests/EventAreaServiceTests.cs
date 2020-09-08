// ****************************************************************************
// <copyright file="EventAreaServiceTests.cs" company="EPAM Systems">
// Copyright (c) EPAM Systems. All rights reserved.
// Author Dzianis Shcharbakou.
// </copyright>
// ****************************************************************************

using System.Linq;
using Autofac;
using AutoFixture;
using NUnit.Framework;
using TicketManagement.BLL.DTO;
using TicketManagement.BLL.Interfaces;
using TicketManagement.BLL.Util;
using TicketManagement.UnitTests.ServiceTests.Base;

namespace TicketManagement.UnitTests.ServiceTests
{
    [TestFixture]
    internal class EventAreaServiceTests : TestWithRepositoryBase
    {
        private IEventAreaService eventAreaService;

        [SetUp]
        public void Init()
        {
            this.eventAreaService = this.Container.Resolve<IEventAreaService>();
        }

        [Test]
        public void UpdateEventArea_NewEventArea_GetEventAreaPrice()
        {
            // Arrange
            var id = 1;
            var eventId = 1;
            var expectedDto = this.Fixture.Build<EventAreaDto>()
                .With(e => e.Id, id)
                .With(e => e.EventId, eventId)
                .Create();

            // Act
            this.eventAreaService.UpdateEventArea(expectedDto);

            // Assert
            Assert.Multiple(() =>
            {
                var actualDto = this.EventAreaFakeRepositoryData.First(x => x.Id == id);
                Assert.AreEqual(expectedDto.EventId, actualDto.EventId);
                Assert.AreEqual(expectedDto.Price, actualDto.Price);
            });
        }

        [Test]
        public void GetEventArea_EventAreaId_GetEventAreaDescription()
        {
            // Arrange
            var id = 1;
            var expectedDto = this.EventAreaFakeRepositoryData.First(x => x.Id == id);

            // Act
            var actualDto = this.eventAreaService.GetEventArea(id);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(expectedDto.Description, actualDto.Description);
                Assert.AreEqual(expectedDto.CoordX, actualDto.CoordX);
                Assert.AreEqual(expectedDto.CoordY, actualDto.CoordY);
                Assert.AreEqual(expectedDto.EventId, actualDto.EventId);
                Assert.AreEqual(expectedDto.Price, actualDto.Price);
            });
        }

        [Test]
        public void GetEventAreas_GetEventAreasCount()
        {
            // Arrange
            var expectedCount = this.EventAreaFakeRepositoryData.Count();

            // Act
            var dtos = this.eventAreaService.GetEventAreas();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(expectedCount, dtos.Count());
            });
        }

        [Test]
        public void UpdateEventArea_NonexistentEventArea_GetException()
        {
            // Arrange
            var id = 10000;
            var dto = this.Fixture.Build<EventAreaDto>().With(e => e.Id, id).Create();

            // Act - delegate. Assert
            Assert.Throws<TicketManagementException>(
                () => this.eventAreaService.UpdateEventArea(dto));
        }

        [Test]
        public void GetEventArea_NonexistentEventArea_GetException()
        {
            // Arrange
            var id = 10000;

            // Act - delegate. Assert
            Assert.Throws<TicketManagementException>(
                () => this.eventAreaService.GetEventArea(id));
        }
    }
}
