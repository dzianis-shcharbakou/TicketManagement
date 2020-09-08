// ****************************************************************************
// <copyright file="EventSeatServiceTests.cs" company="EPAM Systems">
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
    internal class EventSeatServiceTests : TestWithRepositoryBase
    {
        private IEventSeatService eventSeatService;

        [SetUp]
        public void Init()
        {
            this.eventSeatService = this.Container.Resolve<IEventSeatService>();
        }

        [Test]
        public void UpdateEventSeat_NewEventSeat_GetEventSeatState()
        {
            // Arrange
            var id = 1;
            var eventAreaId = 1;
            var expectedDto = this.Fixture.Build<EventSeatDto>()
                .With(e => e.Id, id)
                .With(e => e.EventAreaId, eventAreaId)
                .Create();

            // Act
            this.eventSeatService.UpdateEventSeat(expectedDto);

            // Assert
            Assert.Multiple(() =>
            {
                var actualDto = this.EventSeatFakeRepositoryData.First(x => x.Id == id);
                Assert.AreEqual(expectedDto.EventAreaId, actualDto.EventAreaId);
                Assert.AreEqual(expectedDto.State, actualDto.State);
            });
        }

        [Test]
        public void GetEventSeat_EventSeatId_GetEventState()
        {
            // Arrange
            var id = 1;
            var expectedDto = this.EventSeatFakeRepositoryData.First(x => x.Id == id);

            // Act
            var actualDto = this.eventSeatService.GetEventSeat(id);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(expectedDto.EventAreaId, actualDto.EventAreaId);
                Assert.AreEqual(expectedDto.Number, actualDto.Number);
                Assert.AreEqual(expectedDto.Row, actualDto.Row);
                Assert.AreEqual(expectedDto.State, actualDto.State);
            });
        }

        [Test]
        public void GetEventSeats_GetEventSeatCount()
        {
            // Arrange
            var expectedCount = this.EventSeatFakeRepositoryData.Count();

            // Act
            var dtos = this.eventSeatService.GetEventSeats();

            // Assert
            Assert.AreEqual(expectedCount, dtos.Count());
        }

        [Test]
        public void UpdateEventSeat_NonexistentEventSeat_GetException()
        {
            // Arrange
            var id = 10000;
            var dto = this.Fixture.Build<EventSeatDto>().With(e => e.Id, id).Create();

            // Act - delegate. Assert
            Assert.Throws<TicketManagementException>(
                () => this.eventSeatService.UpdateEventSeat(dto));
        }

        [Test]
        public void GetEventSeat_NonexistentEventSeat_GetException()
        {
            // Arrange
            var id = 10000;

            // Act - delegate. Assert
            Assert.Throws<TicketManagementException>(
                () => this.eventSeatService.GetEventSeat(id));
        }
    }
}
