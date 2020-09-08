// ****************************************************************************
// <copyright file="EventSeatServiceTests.cs" company="EPAM Systems">
// Copyright (c) EPAM Systems. All rights reserved.
// Author Dzianis Shcharbakou.
// </copyright>
// ****************************************************************************

using System.Linq;
using Autofac;
using NUnit.Framework;
using TicketManagement.BLL.Constants;
using TicketManagement.BLL.DTO;
using TicketManagement.BLL.Interfaces;
using Test = TicketManagement.IntegrationTests.TestBase.TestBase;

namespace TicketManagement.IntegrationTests.ServiceTests
{
    internal class EventSeatServiceTests : Test
    {
        private IEventSeatService eventSeatService;

        [SetUp]
        public void Init()
        {
            this.eventSeatService = this.Container.Resolve<IEventSeatService>();
        }

        [Test]
        public void UpdateEventSeat_NewState_GetEventSeat()
        {
            EventSeatDto eventSeatDto = new EventSeatDto
            {
                Id = 1,
                Number = 2,
                State = (int)EventSeatState.Selled,
                Row = 2,
                EventAreaId = 2,
            };

            this.eventSeatService.UpdateEventSeat(eventSeatDto);

            EventSeatDto eventSeatDtoTemp = this.eventSeatService.GetEventSeat(1);

            Assert.AreEqual(1, eventSeatDtoTemp.Number);
            Assert.AreEqual((int)EventSeatState.Selled, eventSeatDtoTemp.State);
            Assert.AreEqual(1, eventSeatDtoTemp.Row);
            Assert.AreEqual(1, eventSeatDtoTemp.EventAreaId);
        }

        [Test]
        public void GetEventSeat_EventSeatId_GetEventSeat()
        {
            EventSeatDto eventSeatDtoTemp = this.eventSeatService.GetEventSeat(1);

            Assert.AreEqual(1, eventSeatDtoTemp.Number);
            Assert.AreEqual((int)EventSeatState.Free, eventSeatDtoTemp.State);
            Assert.AreEqual(1, eventSeatDtoTemp.Row);
            Assert.AreEqual(1, eventSeatDtoTemp.EventAreaId);
        }

        [Test]
        public void GetEventSeats_GetEventSeatsCount()
        {
            int eventSeatDtoCount = this.eventSeatService.GetEventSeats().Count();

            Assert.AreEqual(20, eventSeatDtoCount);
        }
    }
}
