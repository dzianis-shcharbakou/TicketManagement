// ****************************************************************************
// <copyright file="SeatServiceTests.cs" company="EPAM Systems">
// Copyright (c) EPAM Systems. All rights reserved.
// Author Dzianis Shcharbakou.
// </copyright>
// ****************************************************************************

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
    internal class SeatServiceTests : TestWithRepositoryBase
    {
        private ISeatService seatService;

        [SetUp]
        public void Init()
        {
            this.seatService = this.Container.Resolve<ISeatService>();
        }

        [Test]
        public void AddSeat_AddNewSeat_GetCountSeats()
        {
            // Arrange
            int expectedCount = this.SeatFakeRepositoryData.Count() + 1;
            var seatDto = new SeatDto
            {
                Row = 9,
                Number = 9,
                AreaId = 1,
            };

            // Act
            this.seatService.AddSeat(seatDto);

            // Assert
            Assert.AreEqual(expectedCount, this.SeatFakeRepositoryData.Count());
        }

        [Test]
        public void UpdateSeat_NewSeat_GetSeatRow()
        {
            // Arrange
            var expectedDto = new SeatDto
            {
                Id = 1,
                Row = 9,
                Number = 9,
                AreaId = 1,
            };

            // Act
            this.seatService.UpdateSeat(expectedDto);

            // Assert
            Assert.Multiple(() =>
            {
                var actualDto = this.SeatFakeRepositoryData.First(x => x.Id == expectedDto.Id);
                Assert.AreEqual(expectedDto.Number, actualDto.Number);
                Assert.AreEqual(expectedDto.Row, actualDto.Row);
                Assert.AreEqual(expectedDto.AreaId, actualDto.AreaId);
            });
        }

        [Test]
        public void DeleteSeat_SeatId_GetSeatsCount()
        {
            // Arrange
            int id = 1;
            int expectedCount = this.SeatFakeRepositoryData.Count() - 1;

            // Act
            this.seatService.DeleteSeat(id);

            // Assert
            Assert.AreEqual(expectedCount, this.SeatFakeRepositoryData.Count());
        }

        [Test]
        public void GetSeat_SeatId_GetSeatNumber()
        {
            // Arrange
            var id = 1;
            var expectedDto = this.SeatFakeRepositoryData.First(x => x.Id == id);

            // Act
            var actualDto = this.seatService.GetSeat(1);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(expectedDto.Number, actualDto.Number);
                Assert.AreEqual(expectedDto.Row, actualDto.Row);
                Assert.AreEqual(expectedDto.AreaId, actualDto.AreaId);
            });
        }

        [Test]
        public void GetSeats_GetSeatsCount()
        {
            // Arrange
            var expectedCount = this.SeatFakeRepositoryData.Count();

            // Act
            var dtos = this.seatService.GetSeats();

            // Assert
            Assert.AreEqual(expectedCount, dtos.Count());
        }

        [Test]
        public void AddSeat_NonexistentArea_GetException()
        {
            // Arrange
            var nonexistingAreaId = 100000;
            var dto = new SeatDto
            {
                Id = 9,
                Row = 9,
                Number = 9,
                AreaId = nonexistingAreaId,
            };

            // Act - delegate. Assert
            Assert.Throws<TicketManagementException>(
                () => this.seatService.AddSeat(dto));
        }

        [Test]
        public void AddSeat_IsSeatRowAndNumber_GetException()
        {
            // Arrange
            var dto = new SeatDto
            {
                Id = 41,
                Row = 1,
                Number = 1,
                AreaId = 1,
            };

            // Act - delegate. Assert
            Assert.Throws<TicketManagementException>(
                () => this.seatService.AddSeat(dto));
        }

        [Test]
        public void UpdateSeat_SeatIsNull_GetException()
        {
            // Arrange
            var id = 100000;
            var seatDto = new SeatDto
            {
                Id = id,
                Row = 1,
                Number = 100,
                AreaId = 1,
            };

            // Act - delegate. Assert
            Assert.Throws<TicketManagementException>(
                () => this.seatService.UpdateSeat(seatDto));
        }

        [Test]
        public void UpdateSeat_NonexistentArea_GetException()
        {
            var nonexistingAreaId = 100000;

            // Arrange
            var seatDto = new SeatDto
            {
                Id = 1,
                Row = 1,
                Number = 100,
                AreaId = nonexistingAreaId,
            };

            // Act - delegate. Assert
            Assert.Throws<TicketManagementException>(
                () => this.seatService.UpdateSeat(seatDto));
        }

        [Test]
        public void UpdateSeat_IsSeatRowAndNumber_GetException()
        {
            // Arrange
            var seatDto = new SeatDto
            {
                Id = 1,
                Row = 1,
                Number = 1,
                AreaId = 1,
            };

            // Act - delegate. Assert
            Assert.Throws<TicketManagementException>(
                () => this.seatService.UpdateSeat(seatDto));
        }

        [Test]
        public void DeleteSeat_IdIsNull_GetException()
        {
            // Arrange
            var id = 100000;

            // Act - delegate. Assert
            Assert.Throws<TicketManagementException>(
                () => this.seatService.DeleteSeat(id));
        }

        [Test]
        public void GetSeat_IdIsNull_GetException()
        {
            // Arrange
            var id = 100000;

            // Act - delegate. Assert
            Assert.Throws<TicketManagementException>(
                () => this.seatService.GetSeat(id));
        }
    }
}
