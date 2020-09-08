// ****************************************************************************
// <copyright file="AreaServiceTests.cs" company="EPAM Systems">
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
    internal class AreaServiceTests : TestWithRepositoryBase
    {
        private IAreaService areaService;

        [SetUp]
        public void Init()
        {
            this.areaService = this.Container.Resolve<IAreaService>();
        }

        [Test]
        public void AddArea_AddNewArea_GetCountAreas()
        {
            // Arrange
            int layoutId = 1;
            int expectedCount = this.AreaFakeRepositoryData.Count() + 1;
            var dto = this.Fixture.Build<AreaDto>()
                .With(e => e.LayoutId, layoutId)
                .Create();

            // Act
            this.areaService.AddArea(dto);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(expectedCount, this.AreaFakeRepositoryData.Count());
            });
        }

        [Test]
        public void UpdateArea_NewArea_GetAreaDescription()
        {
            // Arrange
            var id = 1;
            var layoutId = 1;
            var expectedDto = this.Fixture.Build<AreaDto>()
                .With(e => e.Id, id)
                .With(e => e.LayoutId, layoutId)
                .Create();

            // Act
            this.areaService.UpdateArea(expectedDto);

            // Assert
            Assert.Multiple(() =>
            {
                var actualDto = this.AreaFakeRepositoryData.First(x => x.Id == id);
                Assert.AreEqual(expectedDto.Description, actualDto.Description);
                Assert.AreEqual(expectedDto.CoordX, actualDto.CoordX);
                Assert.AreEqual(expectedDto.CoordY, actualDto.CoordY);
                Assert.AreEqual(expectedDto.LayoutId, actualDto.LayoutId);
            });
        }

        [Test]
        public void DeleteArea_AreaId_GetAreasCount()
        {
            // Arrange
            int id = 1;
            int expectedCount = this.AreaFakeRepositoryData.Count() - 1;

            // Act
            this.areaService.DeleteArea(id);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(expectedCount, this.AreaFakeRepositoryData.Count());
            });
        }

        [Test]
        public void GetArea_AreaId_GetAreaDescription()
        {
            // Arrange
            var id = 1;
            var expectedDto = this.AreaFakeRepositoryData.First(x => x.Id == id);

            // Act
            var actualDto = this.areaService.GetArea(1);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(expectedDto.Description, actualDto.Description);
                Assert.AreEqual(expectedDto.CoordX, actualDto.CoordX);
                Assert.AreEqual(expectedDto.CoordY, actualDto.CoordY);
                Assert.AreEqual(expectedDto.LayoutId, actualDto.LayoutId);
            });
        }

        [Test]
        public void GetAreas_GetAreasCount()
        {
            // Arrange
            var expectedCount = this.AreaFakeRepositoryData.Count();

            // Act
            var dtos = this.areaService.GetAreas();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(expectedCount, dtos.Count());
            });
        }

        [Test]
        public void AddArea_NonexistentLayoutId_GetException()
        {
            // Arrange
            var nonexistingLayoutId = 100000;
            var dto = this.Fixture.Build<AreaDto>().With(e => e.LayoutId, nonexistingLayoutId).Create();

            // Act - delegate. Assert
            Assert.Multiple(() =>
            {
                Assert.Throws<TicketManagementException>(
                    () => this.areaService.AddArea(dto));
            });
        }

        [Test]
        public void AddArea_IsAreaDescription_GetException()
        {
            // Arrange
            var existingDescription = "First area of first layout";
            var id = 1;
            var layoutId = 1;
            var dto = this.Fixture.Build<AreaDto>()
                .With(e => e.Description, existingDescription)
                .With(e => e.Id, id)
                .With(e => e.LayoutId, layoutId)
                .Create();

            // Act - delegate. Assert
            Assert.Multiple(() =>
            {
                Assert.Throws<TicketManagementException>(
                    () => this.areaService.AddArea(dto));
            });
        }

        [Test]
        public void UpdateArea_NonexistentArea_GetException()
        {
            // Arrange
            var id = 100000;
            var existingLayoutId = 1;
            var dto = this.Fixture.Build<AreaDto>()
                .With(e => e.LayoutId, existingLayoutId)
                .With(e => e.Id, id)
                .Create();

            // Act - delegate. Assert
            Assert.Multiple(() =>
            {
                Assert.Throws<TicketManagementException>(
                    () => this.areaService.UpdateArea(dto));
            });
        }

        [Test]
        public void UpdateArea_NonexistentLayout_GetException()
        {
            // Arrange
            var id = 1;
            var nonexistingLayoutId = 100000;
            var dto = this.Fixture.Build<AreaDto>()
                .With(e => e.LayoutId, nonexistingLayoutId)
                .With(e => e.Id, id)
                .Create();

            // Act - delegate. Assert
            Assert.Multiple(() =>
            {
                Assert.Throws<TicketManagementException>(
                    () => this.areaService.UpdateArea(dto));
            });
        }

        [Test]
        public void UpdateArea_ExistentDescription_GetException()
        {
            // Arrange
            var existingDescription = "First area of first layout";
            var id = 1;
            var layoutId = 1;
            var dto = this.Fixture.Build<AreaDto>()
                .With(e => e.Description, existingDescription)
                .With(e => e.Id, id)
                .With(e => e.LayoutId, layoutId)
                .Create();

            // Act - delegate. Assert
            Assert.Multiple(() =>
            {
                Assert.Throws<TicketManagementException>(
                    () => this.areaService.UpdateArea(dto));
            });
        }

        [Test]
        public void GetArea_AreaIsNull_GetException()
        {
            // Arrange
            var id = 10000;

            // Act - delegate. Assert
            Assert.Multiple(() =>
            {
                Assert.Throws<TicketManagementException>(
                    () => this.areaService.GetArea(id));
            });
        }
    }
}
