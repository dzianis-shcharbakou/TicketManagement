// ****************************************************************************
// <copyright file="DalAutofacModule.cs" company="EPAM Systems">
// Copyright (c) EPAM Systems. All rights reserved.
// Author Dzianis Shcharbakou.
// </copyright>
// ****************************************************************************

using Autofac;
using TicketManagement.DAL.Models;
using TicketManagement.DAL.Repositories;
using TicketManagement.DAL.Repositories.Base;

namespace TicketManagement.DAL.Util
{
    public class DalAutofacModule : Module
    {
        private readonly string connectionString;
        private readonly string provider;

        public DalAutofacModule(string connectionString, string provider)
        {
            this.connectionString = connectionString;
            this.provider = provider;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<VenueRepository>()
                .As<IRepository<Venue>>()
                .WithParameter("connectionString", this.connectionString)
                .WithParameter("provider", this.provider)
                .InstancePerLifetimeScope();

            builder.RegisterType<SeatRepository>()
                .As<IRepository<Seat>>()
                .WithParameter("connectionString", this.connectionString)
                .WithParameter("provider", this.provider)
                .InstancePerLifetimeScope();

            builder.RegisterType<LayoutRepository>()
                .As<IRepository<Layout>>()
                .WithParameter("connectionString", this.connectionString)
                .WithParameter("provider", this.provider)
                .InstancePerLifetimeScope();

            builder.RegisterType<EventSeatRepository>()
                .As<IRepository<EventSeat>>()
                .WithParameter("connectionString", this.connectionString)
                .WithParameter("provider", this.provider)
                .InstancePerLifetimeScope();

            builder.RegisterType<EventRepository>()
                .As<IRepository<Event>>()
                .WithParameter("connectionString", this.connectionString)
                .WithParameter("provider", this.provider)
                .InstancePerLifetimeScope();

            builder.RegisterType<EventAreaRepository>()
                .As<IRepository<EventArea>>()
                .WithParameter("connectionString", this.connectionString)
                .WithParameter("provider", this.provider)
                .InstancePerLifetimeScope();

            builder.RegisterType<AreaRepository>()
                .As<IRepository<Area>>()
                .WithParameter("connectionString", this.connectionString)
                .WithParameter("provider", this.provider)
                .InstancePerLifetimeScope();
        }
    }
}
