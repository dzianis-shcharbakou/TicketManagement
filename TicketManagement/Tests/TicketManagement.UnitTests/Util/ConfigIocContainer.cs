// ****************************************************************************
// <copyright file="ConfigIocContainer.cs" company="EPAM Systems">
// Copyright (c) EPAM Systems. All rights reserved.
// Author Dzianis Shcharbakou.
// </copyright>
// ****************************************************************************

using Autofac;

namespace TicketManagement.UnitTests.Util
{
    internal class ConfigIocContainer
    {
        public static ContainerBuilder GetContainerBuilder()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new TestsIocModule());

            return builder;
        }
    }
}
