// ****************************************************************************
// <copyright file="VenueServiceTests.cs" company="EPAM Systems">
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
    [TestFixture]
    internal class VenueServiceTests : Test
    {
        private IVenueService venueService;

        [SetUp]
        public void Init()
        {
            this.venueService = this.Container.Resolve<IVenueService>();
        }

        [Test]
        public void AddVenue_AddNewVenue_GetVenues()
        {
            VenueDto venueDto = new VenueDto
            {
                Description = "3",
                Name = "3",
                Address = "3",
                Phone = "3",
            };

            int id = this.venueService.AddVenue(venueDto);
            VenueDto seatDtoTemp = this.venueService.GetVenue(id);

            Assert.AreEqual("3", seatDtoTemp.Name);
            Assert.AreEqual("3", seatDtoTemp.Address);
            Assert.AreEqual("3", seatDtoTemp.Description);
            Assert.AreEqual("3", seatDtoTemp.Phone);
        }

        [Test]
        public void UpdateVenue_NewVenue_GetVenue()
        {
            VenueDto venueDto = new VenueDto
            {
                Id = 2,
                Description = "3",
                Name = "3",
                Address = "3",
                Phone = "3",
            };
            this.venueService.UpdateVenue(venueDto);

            VenueDto venueDtoTemp = this.venueService.GetVenue(2);

            Assert.AreEqual("3", venueDtoTemp.Description);
            Assert.AreEqual("3", venueDtoTemp.Name);
            Assert.AreEqual("3", venueDtoTemp.Address);
            Assert.AreEqual("3", venueDtoTemp.Phone);
        }

        [Test]
        public void DeleteVenue_VenueId_GetVenuesCount()
        {
            this.venueService.DeleteVenue(1);

            int venueCount = this.venueService.GetVenues().Count();
            Assert.AreEqual(1, venueCount);
        }

        [Test]
        public void GetVenue_VenueId_GetVenue()
        {
            VenueDto venueDtoTemp = this.venueService.GetVenue(1);

            Assert.AreEqual("First venue", venueDtoTemp.Description);
            Assert.AreEqual("first", venueDtoTemp.Name);
            Assert.AreEqual("First venue address", venueDtoTemp.Address);
            Assert.AreEqual("123 45 678 90 12", venueDtoTemp.Phone);
        }

        [Test]
        public void GetVenues_GetVenuesCount()
        {
            int venueDtoCount = this.venueService.GetVenues().Count();

            Assert.AreEqual(2, venueDtoCount);
        }
    }
}
