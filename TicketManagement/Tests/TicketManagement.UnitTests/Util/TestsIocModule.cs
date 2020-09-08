// ****************************************************************************
// <copyright file="TestsIocModule.cs" company="EPAM Systems">
// Copyright (c) EPAM Systems. All rights reserved.
// Author Dzianis Shcharbakou.
// </copyright>
// ****************************************************************************

using System;
using Autofac;
using TicketManagement.BLL.Util;
using TicketManagement.DAL.Util;

namespace TicketManagement.UnitTests.Util
{
    internal class TestsIocModule : Module
    {
        private readonly string connectionString;
        private readonly string providerName;

        public TestsIocModule()
        {
            this.connectionString = string.Empty;
            this.providerName = string.Empty;
        }

        protected override void Load(ContainerBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException("builder");
            }

            builder.RegisterModule(new DalAutofacModule(this.connectionString, this.providerName));
            builder.RegisterModule(new BllAutofacModule());
        }
    }
}
