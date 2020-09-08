// ****************************************************************************
// <copyright file="LayoutServiceTests.cs" company="EPAM Systems">
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
    internal class LayoutServiceTests : Test
    {
        private ILayoutService layoutService;

        [SetUp]
        public void Init()
        {
            this.layoutService = this.Container.Resolve<ILayoutService>();
        }

        [Test]
        public void AddLayout_AddNewLayout_GetLayouts()
        {
            LayoutDto layoutDto = new LayoutDto
            {
                Description = "2",
                VenueId = 2,
                Name = "2",
            };

            int id = this.layoutService.AddLayout(layoutDto);

            LayoutDto layoutDtoTemp = this.layoutService.GetLayout(id);

            Assert.AreEqual("2", layoutDtoTemp.Description);
            Assert.AreEqual(2, layoutDtoTemp.VenueId);
            Assert.AreEqual("2", layoutDtoTemp.Name);
        }

        [Test]
        public void UpdateLayout_NewLayout_GetLayout()
        {
            LayoutDto layoutDto = new LayoutDto
            {
                Id = 2,
                Description = "2",
                VenueId = 2,
                Name = "2",
            };
            this.layoutService.UpdateLayout(layoutDto);

            LayoutDto layoutDtoTemp = this.layoutService.GetLayout(2);

            Assert.AreEqual("2", layoutDtoTemp.Description);
            Assert.AreEqual(2, layoutDtoTemp.VenueId);
            Assert.AreEqual("2", layoutDtoTemp.Name);
        }

        [Test]
        public void DeleteLayout_LayoutId_GetLayoutsCount()
        {
            this.layoutService.DeleteLayout(1);

            int layoutCount = this.layoutService.GetLayouts().Count();
            Assert.AreEqual(3, layoutCount);
        }

        [Test]
        public void GetLayout_LayoutId_GetLayout()
        {
            LayoutDto layoutDtoTemp = this.layoutService.GetLayout(1);

            Assert.AreEqual("First layout", layoutDtoTemp.Description);
            Assert.AreEqual("first", layoutDtoTemp.Name);
            Assert.AreEqual(1, layoutDtoTemp.VenueId);
        }

        [Test]
        public void GetLayouts_GetLayoutsCount()
        {
            int layoutDtoCount = this.layoutService.GetLayouts().Count();
            Assert.AreEqual(4, layoutDtoCount);
        }
    }
}
