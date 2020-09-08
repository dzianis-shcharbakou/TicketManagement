// ****************************************************************************
// <copyright file="EventServiceTests.cs" company="EPAM Systems">
// Copyright (c) EPAM Systems. All rights reserved.
// Author Dzianis Shcharbakou.
// </copyright>
// ****************************************************************************

using System;
using System.Linq;
using Autofac;
using NUnit.Framework;
using TicketManagement.BLL.DTO;
using TicketManagement.BLL.Interfaces;
using TicketManagement.BLL.Util;
using TicketManagement.UnitTests.ServiceTests.Base;

namespace TicketManagement.UnitTests.ServiceTests
{
    [TestFixture]
    internal class EventServiceTests : TestWithRepositoryBase
    {
        private IEventService eventService;

        [SetUp]
        public void Init()
        {
            this.eventService = this.Container.Resolve<IEventService>();
        }

        [Test]
        public void AddEvent_AddNewEvent_GetCountEvents()
        {
            // Arrange
            int expectedCount = this.EventFakeRepositoryData.Count() + 1;

            var dto = new EventDto()
            {
                Id = 2,
                BeginDate = new DateTime(2025, 10, 20, 8, 30, 59),
                EndDate = new DateTime(2025, 10, 20, 10, 30, 59),
                Description = "2",
                LayoutId = 2,
                Name = "2",
            };

            // Act
            this.eventService.AddEvent(dto);

            // Assert
            Assert.AreEqual(expectedCount, this.EventFakeRepositoryData.Count());
        }

        [Test]
        public void UpdateEvent_NewEvent_GetEventDescription()
        {
            // Arrange
            var id = 2;
            var expectedDto = new EventDto()
            {
                Id = id,
                BeginDate = new DateTime(2025, 10, 20, 8, 30, 59),
                EndDate = new DateTime(2025, 10, 20, 10, 30, 59),
                Description = "2",
                LayoutId = 2,
                Name = "2",
            };

            // Act
            this.eventService.UpdateEvent(expectedDto);

            // Assert
            Assert.Multiple(() =>
            {
                var actualDto = this.EventFakeRepositoryData.First(x => x.Id == id);
                Assert.AreEqual(expectedDto.Description, actualDto.Description);
                Assert.AreEqual(expectedDto.LayoutId, actualDto.LayoutId);
                Assert.AreEqual(expectedDto.BeginDate, actualDto.BeginDate);
                Assert.AreEqual(expectedDto.EndDate, actualDto.EndDate);
                Assert.AreEqual(expectedDto.Name, actualDto.Name);
            });
        }

        [Test]
        public void DeleteEvent_EventId_GeteventsCount()
        {
            // Arrange
            int id = 2;
            int expectedCount = this.EventFakeRepositoryData.Count() - 1;

            // Act
            this.eventService.DeleteEvent(id);

            // Assert
            Assert.AreEqual(expectedCount, this.EventFakeRepositoryData.Count());
        }

        [Test]
        public void GetEvent_EventId_GetEventDescription()
        {
            // Arrange
            var id = 1;
            var expectedDto = this.EventFakeRepositoryData.First(x => x.Id == id);

            // Act
            var actualDto = this.eventService.GetEvent(id);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(expectedDto.Description, actualDto.Description);
                Assert.AreEqual(expectedDto.LayoutId, actualDto.LayoutId);
                Assert.AreEqual(expectedDto.BeginDate, actualDto.BeginDate);
                Assert.AreEqual(expectedDto.EndDate, actualDto.EndDate);
                Assert.AreEqual(expectedDto.Name, actualDto.Name);
            });
        }

        [Test]
        public void GetEvents_GetEventsCount()
        {
            // Arrange
            var expectedCount = this.EventFakeRepositoryData.Count();

            // Act
            var dtos = this.eventService.GetEvents();

            // Assert
            Assert.AreEqual(expectedCount, dtos.Count());
        }

        [Test]
        public void AddEvent_NonexistentLayout_GetException()
        {
            // Arrange
            var nonexistingLayoutId = 100000;
            var eventDto = new EventDto()
            {
                Id = 2,
                BeginDate = new DateTime(2025, 10, 20, 8, 30, 59),
                EndDate = new DateTime(2025, 10, 20, 10, 30, 59),
                Description = "2",
                LayoutId = nonexistingLayoutId,
                Name = "2",
            };

            // Act - delegate. Assert
            Assert.Throws<TicketManagementException>(
                () => this.eventService.AddEvent(eventDto));
        }

        [Test]
        public void AddEvent_NonexistentAreas_GetException()
        {
            // Arrange
            var layoutWithoutAreasId = 100;
            var dto = new EventDto()
            {
                Id = 2,
                BeginDate = new DateTime(2025, 10, 20, 8, 30, 59),
                EndDate = new DateTime(2025, 10, 20, 10, 30, 59),
                Description = "2",
                LayoutId = layoutWithoutAreasId,
                Name = "2",
            };

            // Act - delegate. Assert
            Assert.Throws<TicketManagementException>(
                () => this.eventService.AddEvent(dto));
        }

        [Test]
        public void AddEvent_NonexistentSeats_GetException()
        {
            // Arrange
            var layoutWithoutSeatsId = 101;

            var eventDto = new EventDto()
            {
                Id = 2,
                BeginDate = new DateTime(2025, 10, 20, 8, 30, 59),
                EndDate = new DateTime(2025, 10, 20, 10, 30, 59),
                Description = "2",
                LayoutId = layoutWithoutSeatsId,
                Name = "2",
            };

            // Act - delegate. Assert
            Assert.Throws<TicketManagementException>(
                () => this.eventService.AddEvent(eventDto));
        }

        [Test]
        public void AddEvent_IsDateInPast_GetException()
        {
            // Arrange
            var beginDateInPast = new DateTime(2016, 10, 20, 8, 30, 59);
            var endDateInPast = new DateTime(2016, 10, 20, 10, 30, 59);
            var eventDto = new EventDto()
            {
                Id = 2,
                BeginDate = beginDateInPast,
                EndDate = endDateInPast,
                Description = "2",
                LayoutId = 1,
                Name = "2",
            };

            // Act - delegate. Assert
            Assert.Throws<TicketManagementException>(
                () => this.eventService.AddEvent(eventDto));
        }

        [Test]
        public void AddEvent_IsLongerBeginDate_GetException()
        {
            // Arrange
            var beginDateInPast = new DateTime(2025, 10, 20, 8, 30, 59);
            var endDateInPast = new DateTime(2024, 10, 20, 10, 30, 59);
            var eventDto = new EventDto()
            {
                Id = 2,
                BeginDate = beginDateInPast,
                EndDate = endDateInPast,
                Description = "2",
                LayoutId = 1,
                Name = "2",
            };

            // Act - delegate. Assert
            Assert.Throws<TicketManagementException>(
                () => this.eventService.AddEvent(eventDto));
        }

        [Test]
        public void AddEvent_IsEventInLayoutSameTime_GetException()
        {
            // Arrange
            var dto = new EventDto()
            {
                Id = 2,
                BeginDate = new DateTime(2025, 12, 12, 12, 00, 00),
                EndDate = new DateTime(2025, 12, 12, 13, 00, 00),
                Description = "2",
                LayoutId = 1,
                Name = "2",
            };

            // Act - delegate. Assert
            Assert.Throws<TicketManagementException>(
                () => this.eventService.AddEvent(dto));
        }

        [Test]
        public void UpdateArea_NonexistentLayout_GetException()
        {
            // Arrange
            var nonexistingLayoutId = 100000;
            var eventDto = new EventDto()
            {
                Id = 2,
                BeginDate = new DateTime(2025, 10, 20, 8, 30, 59),
                EndDate = new DateTime(2025, 10, 20, 10, 30, 59),
                Description = "2",
                LayoutId = nonexistingLayoutId,
                Name = "2",
            };

            // Act - delegate. Assert
            Assert.Throws<TicketManagementException>(
                () => this.eventService.UpdateEvent(eventDto));
        }

        [Test]
        public void UpdateEvent_IsDateInPast_GetException()
        {
            // Arrange
            var beginDateInPast = new DateTime(2016, 10, 20, 8, 30, 59);
            var endDateInPast = new DateTime(2016, 10, 20, 10, 30, 59);
            var eventDto = new EventDto()
            {
                Id = 1,
                BeginDate = beginDateInPast,
                EndDate = endDateInPast,
                Description = "2",
                LayoutId = 1,
                Name = "2",
            };

            // Act - delegate. Assert
            Assert.Throws<TicketManagementException>(
                () => this.eventService.UpdateEvent(eventDto));
        }

        [Test]
        public void UpdateEvent_IsLongerBeginDate_GetException()
        {
            // Arrange
            var beginDateInPast = new DateTime(2025, 10, 20, 8, 30, 59);
            var endDateInPast = new DateTime(2024, 10, 20, 10, 30, 59);
            var eventDto = new EventDto()
            {
                Id = 1,
                BeginDate = beginDateInPast,
                EndDate = endDateInPast,
                Description = "2",
                LayoutId = 1,
                Name = "2",
            };

            // Act - delegate. Assert
            Assert.Throws<TicketManagementException>(
                () => this.eventService.UpdateEvent(eventDto));
        }

        [Test]
        public void DeleteArea_IdIsNull_GetException()
        {
            // Arrange
            var nonexistingId = 100000;

            // Act - delegate. Assert
            Assert.Throws<TicketManagementException>(
                () => this.eventService.DeleteEvent(nonexistingId));
        }

        public void GetEvent_IdIsNull_GetException()
        {
            // Arrange
            var nonexistingId = 100000;

            // Act - delegate. Assert
            Assert.Throws<TicketManagementException>(
                () => this.eventService.GetEvent(nonexistingId));
        }
    }
}
