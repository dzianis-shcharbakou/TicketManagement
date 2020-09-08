// ****************************************************************************
// <copyright file="AreaServiceTests.cs" company="EPAM Systems">
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
    internal class AreaServiceTests : Test
    {
        private IAreaService areaService;

        [SetUp]
        public void Init()
        {
            this.areaService = this.Container.Resolve<IAreaService>();
        }

        [Test]
        public void AddArea_AddNewArea_GetAreas()
        {
            AreaDto areaDto = new AreaDto
            {
                Description = "blabla5",
                CoordX = 1000,
                CoordY = 1000,
                LayoutId = 1,
            };

            int id = this.areaService.AddArea(areaDto);

            AreaDto areaDtoTemp = this.areaService.GetArea(id);

            Assert.AreEqual("blabla5", areaDtoTemp.Description);
            Assert.AreEqual(1000, areaDtoTemp.CoordX);
            Assert.AreEqual(1000, areaDtoTemp.CoordY);
            Assert.AreEqual(1, areaDtoTemp.LayoutId);
        }

        [Test]
        public void UpdateArea_NewArea_GetArea()
        {
            AreaDto areaDto = new AreaDto
            {
                Id = 1,
                Description = "blablabla",
                CoordX = 100011,
                CoordY = 100011,
                LayoutId = 2,
            };
            this.areaService.UpdateArea(areaDto);

            AreaDto areaDtoTemp = this.areaService.GetArea(1);

            Assert.AreEqual("blablabla", areaDtoTemp.Description);
            Assert.AreEqual(100011, areaDtoTemp.CoordX);
            Assert.AreEqual(100011, areaDtoTemp.CoordY);
            Assert.AreEqual(2, areaDtoTemp.LayoutId);
        }

        [Test]
        public void DeleteArea_AreaId_GetAreasCount()
        {
            this.areaService.DeleteArea(8);

            int areaDtoTemp = this.areaService.GetAreas().Count();
            Assert.AreEqual(7, areaDtoTemp);
        }

        [Test]
        public void GetArea_AreaId_GetArea()
        {
            AreaDto areaDtoTemp = this.areaService.GetArea(1);

            Assert.AreEqual("First area of first layout", areaDtoTemp.Description);
            Assert.AreEqual(1, areaDtoTemp.CoordX);
            Assert.AreEqual(1, areaDtoTemp.CoordY);
            Assert.AreEqual(1, areaDtoTemp.LayoutId);
        }

        [Test]
        public void GetAreas_GetAreasCount()
        {
            int areaDtoCount = this.areaService.GetAreas().Count();

            Assert.AreEqual(8, areaDtoCount);
        }
    }
}
