// ****************************************************************************
// <copyright file="TestWithRepositoryBase.cs" company="EPAM Systems">
// Copyright (c) EPAM Systems. All rights reserved.
// Author Dzianis Shcharbakou.
// </copyright>
// ****************************************************************************

using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Autofac.Extras.Moq;
using AutoFixture;
using NUnit.Framework;
using TicketManagement.DAL.Models;
using TicketManagement.DAL.Models.Base;
using TicketManagement.DAL.Repositories.Base;
using TicketManagement.UnitTests.FakeRepositories;
using TicketManagement.UnitTests.FakeRepositories.Util;
using Test = TicketManagement.UnitTests.TestBase.TestBase;

namespace TicketManagement.UnitTests.ServiceTests.Base
{
    public abstract class TestWithRepositoryBase : Test
    {
        private ImmutableList<Venue> fakeVenueRepositoryDataImmutable;
        private ImmutableList<Area> fakeAreaRepositoryDataImmutable;
        private ImmutableList<EventArea> fakeEventAreaRepositoryDataImmutable;
        private ImmutableList<EventSeat> fakeEventSeatRepositoryDataImmutable;
        private ImmutableList<Event> fakeEventRepositoryDataImmutable;
        private ImmutableList<Layout> fakeLayoutRepositoryDataImmutable;
        private ImmutableList<Seat> fakeSeatRepositoryDataImmutable;

        private List<Venue> fakeVenueRepositoryData;
        private List<Area> fakeAreaRepositoryData;
        private List<EventArea> fakeEventAreaRepositoryData;
        private List<EventSeat> fakeEventSeatRepositoryData;
        private List<Event> fakeEventRepositoryData;
        private List<Layout> fakeLayoutRepositoryData;
        private List<Seat> fakeSeatRepositoryData;

        public TestWithRepositoryBase()
        {
            this.fakeVenueRepositoryDataImmutable = InitializeFakeData.InitializeVenueData().ToImmutableList();
            this.fakeAreaRepositoryDataImmutable = InitializeFakeData.InitializeAreaData().ToImmutableList();
            this.fakeEventAreaRepositoryDataImmutable = InitializeFakeData.InitializeEventAreaData().ToImmutableList();
            this.fakeEventSeatRepositoryDataImmutable = InitializeFakeData.InitializeEventSeatData().ToImmutableList();
            this.fakeEventRepositoryDataImmutable = InitializeFakeData.InitializeEventData().ToImmutableList();
            this.fakeLayoutRepositoryDataImmutable = InitializeFakeData.InitializeLayoutData().ToImmutableList();
            this.fakeSeatRepositoryDataImmutable = InitializeFakeData.InitializeSeatData().ToImmutableList();
        }

        protected ImmutableList<Venue> VenueFakeRepositoryData
        {
            get { return this.fakeVenueRepositoryData.ToImmutableList(); }
        }

        protected ImmutableList<Area> AreaFakeRepositoryData
        {
            get { return this.fakeAreaRepositoryData.ToImmutableList(); }
        }

        protected ImmutableList<EventArea> EventAreaFakeRepositoryData
        {
            get { return this.fakeEventAreaRepositoryData.ToImmutableList(); }
        }

        protected ImmutableList<EventSeat> EventSeatFakeRepositoryData
        {
            get { return this.fakeEventSeatRepositoryData.ToImmutableList(); }
        }

        protected ImmutableList<Event> EventFakeRepositoryData
        {
            get { return this.fakeEventRepositoryData.ToImmutableList(); }
        }

        protected ImmutableList<Layout> LayoutFakeRepositoryData
        {
            get { return this.fakeLayoutRepositoryData.ToImmutableList(); }
        }

        protected ImmutableList<Seat> SeatFakeRepositoryData
        {
            get { return this.fakeSeatRepositoryData.ToImmutableList(); }
        }

        protected AutoMock Mock { get; private set; }

        protected Fixture Fixture { get; private set; }

        [SetUp]
        public void InitWithRepositoryBase()
        {
            this.Fixture = new Fixture();
            this.Mock = AutoMock.GetLoose();

            this.RegisterRepository<Venue>(ref this.fakeVenueRepositoryDataImmutable, ref this.fakeVenueRepositoryData);
            this.RegisterRepository<Area>(ref this.fakeAreaRepositoryDataImmutable, ref this.fakeAreaRepositoryData);
            this.RegisterRepository<EventArea>(ref this.fakeEventAreaRepositoryDataImmutable, ref this.fakeEventAreaRepositoryData);
            this.RegisterRepository<EventSeat>(ref this.fakeEventSeatRepositoryDataImmutable, ref this.fakeEventSeatRepositoryData);
            this.RegisterRepository<Event>(ref this.fakeEventRepositoryDataImmutable, ref this.fakeEventRepositoryData);
            this.RegisterRepository<Layout>(ref this.fakeLayoutRepositoryDataImmutable, ref this.fakeLayoutRepositoryData);
            this.RegisterRepository<Seat>(ref this.fakeSeatRepositoryDataImmutable, ref this.fakeSeatRepositoryData);

            this.Container = this.ContainerBuilder.Build();
        }

        public override void Dispose()
        {
            base.Dispose();
            this.Mock?.Dispose();
        }

        private void RegisterRepository<T>(ref ImmutableList<T> fakeRepositoryDataImmutable, ref List<T> fakeRepositoryData)
            where T : IEntity, new()
        {
            fakeRepositoryData = fakeRepositoryDataImmutable.ToList();

            var repositoryMoq = this.Mock.Mock<IRepository<T>>();
            var venueFakeRepository = new RepositoryFake<T>(fakeRepositoryData)
                .SetUpFakeRepository(repositoryMoq);

            // Register mock repository and build container
            this.ContainerBuilder.RegisterMock<IRepository<T>>(venueFakeRepository);
        }
    }
}
