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
using Test = TicketManagement.IntegrationTests.TestBase.TestBase;

namespace TicketManagement.IntegrationTests.ServiceTests
{
    internal class EventServiceTests : Test
    {
        private IEventService eventService;
        private IEventAreaService eventAreaService;
        private IEventSeatService eventSeatService;

        [SetUp]
        public void Init()
        {
            this.eventService = this.Container.Resolve<IEventService>();
            this.eventAreaService = this.Container.Resolve<IEventAreaService>();
            this.eventSeatService = this.Container.Resolve<IEventSeatService>();
        }

        [Test]
        public void AddEvent_AddNewEventNewAreasEventNewSeatsEvent_GetEvents()
        {
            EventDto eventDto = new EventDto
            {
                Id = 2,
                BeginDate = new DateTime(2025, 10, 20, 8, 30, 59),
                EndDate = new DateTime(2025, 10, 20, 10, 30, 59),
                Description = "2",
                LayoutId = 2,
                Name = "2",
            };

            int id = this.eventService.AddEvent(eventDto);

            EventDto eventDtoTemp = this.eventService.GetEvent(id);

            Assert.AreEqual("2", eventDtoTemp.Description);
            Assert.AreEqual(new DateTime(2025, 10, 20, 8, 30, 59), eventDtoTemp.BeginDate);
            Assert.AreEqual(new DateTime(2025, 10, 20, 10, 30, 59), eventDtoTemp.EndDate);
            Assert.AreEqual(2, eventDtoTemp.LayoutId);
            Assert.AreEqual("2", eventDtoTemp.Name);
            Assert.AreEqual(6, this.eventAreaService.GetEventAreas().Count());
            Assert.AreEqual(30, this.eventSeatService.GetEventSeats().Count());
        }

        [Test]
        public void UpdateEvent_NewEvent_GetEvent()
        {
            EventDto eventDto = new EventDto
            {
                Id = 2,
                BeginDate = new DateTime(2025, 10, 20, 8, 30, 59),
                EndDate = new DateTime(2025, 10, 20, 10, 30, 59),
                Description = "2",
                LayoutId = 3,
                Name = "2",
            };
            this.eventService.UpdateEvent(eventDto);

            EventDto eventDtoTemp = this.eventService.GetEvent(2);

            Assert.AreEqual(new DateTime(2025, 10, 20, 8, 30, 59), eventDtoTemp.BeginDate);
            Assert.AreEqual(new DateTime(2025, 10, 20, 10, 30, 59), eventDtoTemp.EndDate);
            Assert.AreEqual("2", eventDtoTemp.Description);
            Assert.AreEqual(3, eventDtoTemp.LayoutId);
            Assert.AreEqual("2", eventDtoTemp.Name);
        }

        [Test]
        public void DeleteEvent_EventId_GetEventsCount()
        {
            this.eventService.DeleteEvent(2);

            int eventDtoTemp = this.eventService.GetEvents().Count();
            Assert.AreEqual(1, eventDtoTemp);
            Assert.AreEqual(2, this.eventAreaService.GetEventAreas().Count());
            Assert.AreEqual(10, this.eventSeatService.GetEventSeats().Count());
        }

        [Test]
        public void GetEvent_EventId_GetEvent()
        {
            EventDto eventDtoTemp = this.eventService.GetEvent(1);

            Assert.AreEqual("First", eventDtoTemp.Description);
            Assert.AreEqual("First event", eventDtoTemp.Name);
            Assert.AreEqual(1, eventDtoTemp.LayoutId);
            Assert.AreEqual(new DateTime(2025, 12, 12, 12, 00, 00), eventDtoTemp.BeginDate);
            Assert.AreEqual(new DateTime(2025, 12, 12, 13, 00, 00), eventDtoTemp.EndDate);
        }

        [Test]
        public void GetEvents_GetEventsCount()
        {
            int eventDtoCount = this.eventService.GetEvents().Count();

            Assert.AreEqual(2, eventDtoCount);
        }
    }
}
