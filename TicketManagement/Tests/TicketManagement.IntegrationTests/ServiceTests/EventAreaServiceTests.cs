// ****************************************************************************
// <copyright file="EventAreaServiceTests.cs" company="EPAM Systems">
// Copyright (c) EPAM Systems. All rights reserved.
// Author Dzianis Shcharbakou.
// </copyright>
// ****************************************************************************

using System.Linq;
using Autofac;
using NUnit.Framework;
using TicketManagement.BLL.DTO;
using TicketManagement.BLL.Interfaces;
using Test = TicketManagement.IntegrationTests.TestBase.TestBase;

namespace TicketManagement.IntegrationTests.ServiceTests
{
    internal class EventAreaServiceTests : Test
    {
        private IEventAreaService eventAreaService;

        [SetUp]
        public void Init()
        {
            this.eventAreaService = this.Container.Resolve<IEventAreaService>();
        }

        [Test]
        public void UpdateEventArea_NewPrice_GetEventArea()
        {
            EventAreaDto eventAreaDto = new EventAreaDto
            {
                Id = 1,
                Description = "blabla5",
                CoordX = 1000,
                CoordY = 1000,
                Price = 1000,
                EventId = 2,
            };

            this.eventAreaService.UpdateEventArea(eventAreaDto);

            EventAreaDto eventAreaDtoTemp = this.eventAreaService.GetEventArea(1);

            Assert.AreEqual("First area of first layout", eventAreaDtoTemp.Description);
            Assert.AreEqual(1, eventAreaDtoTemp.CoordX);
            Assert.AreEqual(1, eventAreaDtoTemp.CoordY);
            Assert.AreEqual(1000, eventAreaDtoTemp.Price);
            Assert.AreEqual(1, eventAreaDtoTemp.EventId);
        }

        [Test]
        public void GetEventArea_EventAreaId_GetEventArea()
        {
            EventAreaDto eventAreaDtoTemp = this.eventAreaService.GetEventArea(1);

            Assert.AreEqual("First area of first layout", eventAreaDtoTemp.Description);
            Assert.AreEqual(1, eventAreaDtoTemp.CoordX);
            Assert.AreEqual(1, eventAreaDtoTemp.CoordY);
            Assert.AreEqual(100, eventAreaDtoTemp.Price);
            Assert.AreEqual(1, eventAreaDtoTemp.EventId);
        }

        [Test]
        public void GetEventAreas_GetEventAreasCount()
        {
            int eventAreaDtoCount = this.eventAreaService.GetEventAreas().Count();

            Assert.AreEqual(4, eventAreaDtoCount);
        }
    }
}
