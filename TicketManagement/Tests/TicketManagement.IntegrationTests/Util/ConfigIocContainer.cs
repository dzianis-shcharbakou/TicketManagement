// ****************************************************************************
// <copyright file="ConfigIocContainer.cs" company="EPAM Systems">
// Copyright (c) EPAM Systems. All rights reserved.
// Author Dzianis Shcharbakou.
// </copyright>
// ****************************************************************************

using Autofac;

namespace TicketManagement.IntegrationTests.Util
{
    internal class ConfigIocContainer
    {
        public static IContainer GetIocContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new TestsIocModule());

            return builder.Build();
        }
    }
}
