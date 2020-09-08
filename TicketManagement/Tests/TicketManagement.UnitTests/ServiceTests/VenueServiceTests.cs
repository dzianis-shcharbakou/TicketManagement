// ****************************************************************************
// <copyright file="VenueServiceTests.cs" company="EPAM Systems">
// Copyright (c) EPAM Systems. All rights reserved.
// Author Dzianis Shcharbakou.
// </copyright>
// ****************************************************************************

using System.Linq;
using Autofac;
using AutoFixture;
using Moq;
using NUnit.Framework;
using TicketManagement.BLL.DTO;
using TicketManagement.BLL.Interfaces;
using TicketManagement.BLL.Util;
using TicketManagement.DAL.Models;
using TicketManagement.DAL.Repositories.Base;
using TicketManagement.UnitTests.ServiceTests.Base;

namespace TicketManagement.UnitTests.ServiceTests
{
    [TestFixture]
    internal class VenueServiceTests : TestWithRepositoryBase
    {
        private IVenueService venueService;

        [SetUp]
        public void Init()
        {
            this.venueService = this.Container.Resolve<IVenueService>();
        }

        [Test]
        public void AddVenue_AddNewVenue_GetCountVenues()
        {
            // Arrange
            int expectedCount = this.VenueFakeRepositoryData.Count() + 1;
            var dto = this.Fixture.Build<VenueDto>().Create();

            // Act
            this.venueService.AddVenue(dto);

            // Assert
            Assert.Multiple(() =>
            {
                this.Mock.Mock<IRepository<Venue>>().Verify(x => x.GetAll(), Times.Once);
                this.Mock.Mock<IRepository<Venue>>().Verify(x => x.Create(It.IsAny<Venue>()), Times.Once);
                Assert.AreEqual(expectedCount, this.VenueFakeRepositoryData.Count());
            });
        }

        [Test]
        public void UpdateVenue_NewVenue_GetVenueProperties()
        {
            // Arrange
            var id = 1;
            var expectedDto = this.Fixture.Build<VenueDto>().With(e => e.Id, id).Create();

            // Act
            this.venueService.UpdateVenue(expectedDto);

            // Assert
            Assert.Multiple(() =>
            {
                this.Mock.Mock<IRepository<Venue>>().Verify(x => x.GetAll(), Times.Once);
                this.Mock.Mock<IRepository<Venue>>().Verify(x => x.Update(It.IsAny<Venue>()), Times.Once);
                var actualDto = this.VenueFakeRepositoryData.First(x => x.Id == id);
                Assert.AreEqual(expectedDto.Description, actualDto.Description);
                Assert.AreEqual(expectedDto.Address, actualDto.Address);
                Assert.AreEqual(expectedDto.Name, actualDto.Name);
                Assert.AreEqual(expectedDto.Phone, actualDto.Phone);
            });
        }

        [Test]
        public void DeleteVenue_VenueId_GetVenuesCount()
        {
            // Arrange
            int id = 1;
            int expectedCount = this.VenueFakeRepositoryData.Count() - 1;

            // Act
            this.venueService.DeleteVenue(id);

            // Assert
            Assert.Multiple(() =>
            {
                this.Mock.Mock<IRepository<Venue>>().Verify(x => x.Delete(It.IsAny<int>()), Times.Once);
                Assert.AreEqual(expectedCount, this.VenueFakeRepositoryData.Count());
            });
        }

        [Test]
        public void GetVenue_VenueId_GetVenueProperties()
        {
            // Arrange
            var id = 1;
            var expectedDto = this.VenueFakeRepositoryData.First(x => x.Id == id);

            // Act
            var actualDto = this.venueService.GetVenue(id);

            // Assert
            Assert.Multiple(() =>
            {
                this.Mock.Mock<IRepository<Venue>>().Verify(x => x.GetById(It.IsAny<int>()), Times.Once);
                Assert.AreEqual(expectedDto.Description, actualDto.Description);
                Assert.AreEqual(expectedDto.Address, actualDto.Address);
                Assert.AreEqual(expectedDto.Name, actualDto.Name);
                Assert.AreEqual(expectedDto.Phone, actualDto.Phone);
            });
        }

        [Test]
        public void GetVenues_GetVenuesCount()
        {
            // Arrange
            var expectedCount = this.VenueFakeRepositoryData.Count();

            // Act
            var dtos = this.venueService.GetVenues();

            // Assert
            Assert.Multiple(() =>
            {
                this.Mock.Mock<IRepository<Venue>>().Verify(x => x.GetAll(), Times.Once);
                Assert.AreEqual(expectedCount, dtos.Count());
            });
        }

        [Test]
        public void AddVenue_IsVenueName_GetException()
        {
            // Arrange
            var existingName = this.VenueFakeRepositoryData.First().Name;
            var dto = this.Fixture.Build<VenueDto>().With(e => e.Name, existingName).Create();

            // Act - delegate. Assert
            Assert.Multiple(() =>
            {
                Assert.Throws<TicketManagementException>(
                    () => this.venueService.AddVenue(dto));
                this.Mock.Mock<IRepository<Venue>>().Verify(x => x.GetAll(), Times.Once);
                this.Mock.Mock<IRepository<Venue>>().Verify(x => x.Create(It.IsAny<Venue>()), Times.Never);
            });
        }

        [Test]
        public void UpdateVenue_VenueIsNull_GetException()
        {
            // Arrange
            var idNotExistId = -1;
            var dto = this.Fixture.Build<VenueDto>().With(e => e.Id, idNotExistId).Create();

            // Act - delegate. Assert
            Assert.Multiple(() =>
            {
                Assert.Throws<TicketManagementException>(
                () => this.venueService.UpdateVenue(dto));
                this.Mock.Mock<IRepository<Venue>>().Verify(x => x.GetAll(), Times.Once);
                this.Mock.Mock<IRepository<Venue>>().Verify(x => x.Update(It.IsAny<Venue>()), Times.Once);
            });
        }

        [Test]
        public void UpdateVenue_IsVenueName_GetException()
        {
            // Arrange
            var existingVenueName = this.VenueFakeRepositoryData.First().Name;
            var venueIdForUpdate = this.VenueFakeRepositoryData.Last().Id;
            var dto = this.Fixture.Build<VenueDto>().With(e => e.Id, venueIdForUpdate).With(e => e.Name, existingVenueName).Create();

            // Act - delegate. Assert
            Assert.Multiple(() =>
            {
                Assert.Throws<TicketManagementException>(
                () => this.venueService.UpdateVenue(dto));
                this.Mock.Mock<IRepository<Venue>>().Verify(x => x.GetAll(), Times.Once);
                this.Mock.Mock<IRepository<Venue>>().Verify(x => x.Update(It.IsAny<Venue>()), Times.Never);
            });
        }

        [Test]
        public void GetVenue_VenueIsNull_GetException()
        {
            var idNotExist = -1;

            // Arrange
            // Act - delegate. Assert
            Assert.Multiple(() =>
            {
                Assert.Throws<TicketManagementException>(
                    () => this.venueService.GetVenue(idNotExist));
                this.Mock.Mock<IRepository<Venue>>().Verify(x => x.GetById(It.IsAny<int>()), Times.Once);
            });
        }

        [Test]
        public void DeleteVenue_VenueIsNull_GetException()
        {
            var idNotExist = 10;

            // Arrange
            // Act - delegate. Assert
            Assert.Multiple(() =>
            {
                Assert.Throws<TicketManagementException>(
                    () => this.venueService.DeleteVenue(idNotExist));
                this.Mock.Mock<IRepository<Venue>>().Verify(x => x.Delete(It.IsAny<int>()), Times.Once);
            });
        }
    }
}
