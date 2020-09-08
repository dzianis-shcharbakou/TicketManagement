// ****************************************************************************
// <copyright file="AutomapperConfigTests.cs" company="EPAM Systems">
// Copyright (c) EPAM Systems. All rights reserved.
// Author Dzianis Shcharbakou.
// </copyright>
// ****************************************************************************

using Autofac;
using AutoMapper;
using NUnit.Framework;
using Test = TicketManagement.UnitTests.TestBase.TestBase;

namespace TicketManagement.UnitTests.UtilTests
{
    internal class AutomapperConfigTests : Test
    {
        private MapperConfiguration mapperConfiguration;

        [SetUp]
        public void Init()
        {
            this.Container = this.ContainerBuilder.Build();
            this.mapperConfiguration = this.Container.Resolve<MapperConfiguration>();
        }

        [Test]
        public void CheckMapperConfig()
        {
            this.mapperConfiguration.AssertConfigurationIsValid();
        }
    }
}
