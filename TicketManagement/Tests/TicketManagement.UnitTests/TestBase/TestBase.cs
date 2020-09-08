// ****************************************************************************
// <copyright file="TestBase.cs" company="EPAM Systems">
// Copyright (c) EPAM Systems. All rights reserved.
// Author Dzianis Shcharbakou.
// </copyright>
// ****************************************************************************

using System;
using Autofac;
using NUnit.Framework;
using TicketManagement.UnitTests.Util;

namespace TicketManagement.UnitTests.TestBase
{
    public abstract class TestBase : IDisposable
    {
        protected ContainerBuilder ContainerBuilder { get; private set; }

        protected IContainer Container { get; set; }

        [SetUp]
        public void InitBase()
        {
            this.ContainerBuilder = ConfigIocContainer.GetContainerBuilder();
        }

        public virtual void Dispose()
        {
            this.Container?.Dispose();
        }
    }
}
