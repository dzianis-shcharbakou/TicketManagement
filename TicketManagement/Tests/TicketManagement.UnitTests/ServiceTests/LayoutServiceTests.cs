// ****************************************************************************
// <copyright file="LayoutServiceTests.cs" company="EPAM Systems">
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
    internal class LayoutServiceTests : TestWithRepositoryBase
    {
        private ILayoutService layoutService;

        [SetUp]
        public void Init()
        {
            this.layoutService = this.Container.Resolve<ILayoutService>();
        }

        [Test]
        public void AddLayout_AddNewLayout_GetCountLayouts()
        {
            // Arrange
            int venueId = 1;
            int expectedCount = this.LayoutFakeRepositoryData.Count() + 1;
            var dto = this.Fixture.Build<LayoutDto>()
                .With(e => e.VenueId, venueId)
                .Create();

            // Act
            this.layoutService.AddLayout(dto);

            // Assert
            Assert.AreEqual(expectedCount, this.LayoutFakeRepositoryData.Count());
        }

        [Test]
        public void UpdateLayout_NewLayout_GetLayoutDescription()
        {
            // Arrange
            var id = 1;
            var venueId = 1;
            var expectedDto = this.Fixture.Build<LayoutDto>()
                .With(e => e.Id, id)
                .With(e => e.VenueId, venueId)
                .Create();

            // Act
            this.layoutService.UpdateLayout(expectedDto);

            // Assert
            Assert.Multiple(() =>
            {
                var actualDto = this.LayoutFakeRepositoryData.First(x => x.Id == id);
                Assert.AreEqual(expectedDto.Description, actualDto.Description);
                Assert.AreEqual(expectedDto.VenueId, actualDto.VenueId);
                Assert.AreEqual(expectedDto.Name, actualDto.Name);
            });
        }

        [Test]
        public void DeleteLayout_LayoutId_GetLayoutsCount()
        {
            // Arrange
            int id = 1;
            int expectedCount = this.LayoutFakeRepositoryData.Count() - 1;

            // Act
            this.layoutService.DeleteLayout(id);

            // Assert
            Assert.AreEqual(expectedCount, this.LayoutFakeRepositoryData.Count());
        }

        [Test]
        public void GetLayout_LayoutId_GetLayoutDescription()
        {
            // Arrange
            var id = 1;
            var expectedDto = this.LayoutFakeRepositoryData.First(x => x.Id == id);

            // Act
            var actualDto = this.layoutService.GetLayout(id);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(expectedDto.Description, actualDto.Description);
                Assert.AreEqual(expectedDto.VenueId, actualDto.VenueId);
                Assert.AreEqual(expectedDto.Name, actualDto.Name);
            });
        }

        [Test]
        public void GetEvents_GetEventsCount()
        {
            // Arrange
            var expectedCount = this.LayoutFakeRepositoryData.Count();

            // Act
            var dtos = this.layoutService.GetLayouts();

            // Assert
            Assert.AreEqual(expectedCount, dtos.Count());
        }

        [Test]
        public void AddLayout_NonexistentVenue_GetException()
        {
            // Arrange
            var nonexistingVenueId = 100000;
            var dto = this.Fixture.Build<LayoutDto>().With(e => e.VenueId, nonexistingVenueId).Create();

            // Act - delegate. Assert
            Assert.Throws<TicketManagementException>(
                () => this.layoutService.AddLayout(dto));
        }

        [Test]
        public void AddLayout_IsLayoutName_GetException()
        {
            // Arrange
            var existingName = "first";
            var id = 5;
            var venueId = 1;
            var dto = this.Fixture.Build<LayoutDto>()
                .With(e => e.Name, existingName)
                .With(e => e.Id, id)
                .With(e => e.VenueId, venueId)
                .Create();

            // Act - delegate. Assert
            Assert.Throws<TicketManagementException>(
                () => this.layoutService.AddLayout(dto));
        }

        [Test]
        public void UpdateLayout_NonexistentArea_GetException()
        {
            // Arrange
            var id = 100000;
            var existingVenueId = 1;
            var dto = this.Fixture.Build<LayoutDto>()
                .With(e => e.VenueId, existingVenueId)
                .With(e => e.Id, id)
                .Create();

            // Act - delegate. Assert
            Assert.Throws<TicketManagementException>(
                () => this.layoutService.UpdateLayout(dto));
        }

        [Test]
        public void UpdateLayout_NonexistentVenue_GetException()
        {
            // Arrange
            var id = 1;
            var nonexistingVenueId = 100000;
            var dto = this.Fixture.Build<LayoutDto>()
                .With(e => e.VenueId, nonexistingVenueId)
                .With(e => e.Id, id)
                .Create();

            // Act - delegate. Assert
            Assert.Throws<TicketManagementException>(
                () => this.layoutService.UpdateLayout(dto));
        }

        [Test]
        public void UpdateLayout_IsLayoutName_GetException()
        {
            // Arrange
            var existingName = "first";
            var id = 1;
            var venueId = 1;
            var dto = this.Fixture.Build<LayoutDto>()
                .With(e => e.Name, existingName)
                .With(e => e.Id, id)
                .With(e => e.VenueId, venueId)
                .Create();

            // Act - delegate. Assert
            Assert.Throws<TicketManagementException>(
                () => this.layoutService.UpdateLayout(dto));
        }

        [Test]
        public void GetLayout_LayoutIsNull_GetException()
        {
            // Arrange
            var id = 10000;

            // Act - delegate. Assert
            Assert.Throws<TicketManagementException>(
                () => this.layoutService.GetLayout(id));
        }
    }
}
