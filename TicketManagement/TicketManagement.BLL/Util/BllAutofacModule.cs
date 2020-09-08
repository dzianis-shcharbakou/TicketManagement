// ****************************************************************************
// <copyright file="BllAutofacModule.cs" company="EPAM Systems">
// Copyright (c) EPAM Systems. All rights reserved.
// Author Dzianis Shcharbakou.
// </copyright>
// ****************************************************************************

using Autofac;
using AutoMapper.Contrib.Autofac.DependencyInjection;
using TicketManagement.BLL.Interfaces;
using TicketManagement.BLL.Services;
using TicketManagement.BLL.ServiceValidators;
using TicketManagement.BLL.ServiceValidators.Interfaces;

namespace TicketManagement.BLL.Util
{
    public class BllAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<VenueService>()
                .As<IVenueService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<SeatService>()
                .As<ISeatService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<LayoutService>()
                .As<ILayoutService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<EventService>()
                .As<IEventService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<EventSeatService>()
                .As<IEventSeatService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<EventAreaService>()
                .As<IEventAreaService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<AreaService>()
                .As<IAreaService>()
                .InstancePerLifetimeScope();

            // vaidators
            builder.RegisterType<VenueValidator>()
                .As<IVenueValidator>()
                .InstancePerLifetimeScope();
            builder.RegisterType<SeatValidator>()
               .As<ISeatValidator>()
               .InstancePerLifetimeScope();
            builder.RegisterType<LayoutValidator>()
               .As<ILayoutValidator>()
               .InstancePerLifetimeScope();
            builder.RegisterType<EventValidator>()
               .As<IEventValidator>()
               .InstancePerLifetimeScope();
            builder.RegisterType<EventSeatValidator>()
               .As<IEventSeatValidator>()
               .InstancePerLifetimeScope();
            builder.RegisterType<EventAreaValidator>()
               .As<IEventAreaValidator>()
               .InstancePerLifetimeScope();
            builder.RegisterType<AreaValidator>()
               .As<IAreaValidator>()
               .InstancePerLifetimeScope();

            builder.AddAutoMapper(typeof(BllAutofacModule).Assembly);
        }
    }
}
