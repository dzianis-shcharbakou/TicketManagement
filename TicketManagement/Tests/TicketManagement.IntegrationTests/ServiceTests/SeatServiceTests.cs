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
using Test = TicketManagement.IntegrationTests.TestBase.TestBase;

namespace TicketManagement.IntegrationTests.ServiceTests
{
    internal class SeatServiceTests : Test
    {
        private ISeatService seatService;

        [SetUp]
        public void Init()
        {
            this.seatService = this.Container.Resolve<ISeatService>();
        }

        [Test]
        public void AddSeat_AddNewSeat_GetSeats()
        {
            SeatDto seatDto = new SeatDto
            {
                Row = 2,
                Number = 2,
                AreaId = 2,
            };

            int id = this.seatService.AddSeat(seatDto);

            SeatDto seatDtoTemp = this.seatService.GetSeat(id);

            Assert.AreEqual(2, seatDtoTemp.Row);
            Assert.AreEqual(2, seatDtoTemp.Number);
            Assert.AreEqual(2, seatDtoTemp.AreaId);
        }

        [Test]
        public void UpdateSeat_NewSeat_GetSeat()
        {
            SeatDto seatDto = new SeatDto
            {
                Id = 2,
                Row = 2,
                Number = 2,
                AreaId = 2,
            };
            this.seatService.UpdateSeat(seatDto);

            SeatDto seatDtoTemp = this.seatService.GetSeat(2);

            Assert.AreEqual(2, seatDtoTemp.Row);
            Assert.AreEqual(2, seatDtoTemp.Number);
            Assert.AreEqual(2, seatDtoTemp.AreaId);
        }

        [Test]
        public void DeleteSeat_SeatId_GetSeatsCount()
        {
            this.seatService.DeleteSeat(1);

            int seatCount = this.seatService.GetSeats().Count();
            Assert.AreEqual(39, seatCount);
        }

        [Test]
        public void GetSeat_SeatId_GetSeat()
        {
            SeatDto seatDtoTemp = this.seatService.GetSeat(1);

            Assert.AreEqual(1, seatDtoTemp.Row);
            Assert.AreEqual(1, seatDtoTemp.Number);
            Assert.AreEqual(1, seatDtoTemp.AreaId);
        }

        [Test]
        public void GetSeats_GetSeatsCount()
        {
            int seatDtoCount = this.seatService.GetSeats().Count();

            Assert.AreEqual(40, seatDtoCount);
        }
    }
}
