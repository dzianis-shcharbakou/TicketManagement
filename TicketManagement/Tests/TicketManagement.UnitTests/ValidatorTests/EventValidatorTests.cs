﻿// ****************************************************************************
// <copyright file="EventValidatorTests.cs" company="EPAM Systems">
// Copyright (c) EPAM Systems. All rights reserved.
// Author Dzianis Shcharbakou.
// </copyright>
// ****************************************************************************

using System;
using System.Collections.Generic;
using Autofac;
using Autofac.Extras.Moq;
using AutoFixture;
using FluentAssertions;
using NUnit.Framework;
using TicketManagement.BLL.Exceptions.EventExceptions;
using TicketManagement.BLL.ServiceValidators;
using TicketManagement.BLL.ServiceValidators.Interfaces;
using TicketManagement.DAL.Constants;
using TicketManagement.DAL.Models;
using TicketManagement.DAL.Repositories.Base;
using TicketManagement.UnitTests.FakeRepositories;

namespace TicketManagement.UnitTests.ValidatorTests
{
    [TestFixture]
    internal class EventValidatorTests
    {
        private IEventValidator eventValidator;

        private AutoMock Mock { get; set; }

        private Fixture Fixture { get; set; }

        [SetUp]
        public void Init()
        {
            this.Fixture = new Fixture();

            var layouts = new List<Layout>
            {
                new Layout() { Id = 1, Name = "first", Description = "First layout", VenueId = 1 },
                new Layout() { Id = 2, Name = "second", Description = "Second layout", VenueId = 1 },
                new Layout() { Id = 3, Name = "third", Description = "First layout", VenueId = 2 },
                new Layout() { Id = 4, Name = "forth", Description = "Second layout", VenueId = 2 },
                new Layout() { Id = 100, Name = "forth2", Description = "Second layout", VenueId = 2 },
                new Layout() { Id = 101, Name = "forth1", Description = "Second layout", VenueId = 2 },
            };
            var fakeLayoutRepository = new RepositoryFake<Layout>(layouts);

            var events = new List<Event>
            {
                new Event()
                {
                    Id = 1, BeginDateUtc = new DateTime(2025, 12, 12, 12, 00, 00),
                    EndDateUtc = new DateTime(2025, 12, 12, 13, 00, 00), Description = "First",
                    LayoutId = 1, Name = "First event", Published = false,
                },
                new Event()
                {
                    Id = 2, BeginDateUtc = new DateTime(2025, 12, 12, 13, 00, 00),
                    EndDateUtc = new DateTime(2025, 12, 12, 14, 00, 00), Description = "Second",
                    LayoutId = 2, Name = "Second event",  Published = true,
                },
            };
            var fakeEventRepository = new RepositoryFake<Event>(events);

            var areas = new List<Area>
            {
                new Area() { Id = 1, Description = "First area of first layout", CoordinateX = 1, CoordinateY = 1, LayoutId = 1 },
                new Area() { Id = 2, Description = "Second area of first layout", CoordinateX = 2, CoordinateY = 2, LayoutId = 1 },
                new Area() { Id = 3, Description = "First area of second layout", CoordinateX = 3, CoordinateY = 3, LayoutId = 2 },
                new Area() { Id = 4, Description = "Second area of second layout", CoordinateX = 4, CoordinateY = 4, LayoutId = 2 },
                new Area() { Id = 5, Description = "First area of third layout", CoordinateX = 1, CoordinateY = 1, LayoutId = 3 },
                new Area() { Id = 6, Description = "Second area of third layout", CoordinateX = 2, CoordinateY = 2, LayoutId = 3 },
                new Area() { Id = 7, Description = "First area of fourth layout", CoordinateX = 3, CoordinateY = 3, LayoutId = 4 },
                new Area() { Id = 8, Description = "Second area of fourth layout", CoordinateX = 4, CoordinateY = 4, LayoutId = 4 },
                new Area() { Id = 101, Description = "Second area of fourth layout", CoordinateX = 4, CoordinateY = 4, LayoutId = 101 },
            };
            var fakeAreaRepository = new RepositoryFake<Area>(areas);

            var seats = new List<Seat>()
            {
                new Seat() { Id = 1, AreaId = 1, Number = 1, Row = 1 },
                new Seat() { Id = 2, AreaId = 1, Number = 2, Row = 1 },
                new Seat() { Id = 3, AreaId = 1, Number = 3, Row = 1 },
                new Seat() { Id = 4, AreaId = 1, Number = 4, Row = 1 },
                new Seat() { Id = 5, AreaId = 1, Number = 5, Row = 1 },
                new Seat() { Id = 6, AreaId = 2, Number = 1, Row = 1 },
                new Seat() { Id = 7, AreaId = 2, Number = 2, Row = 1 },
                new Seat() { Id = 8, AreaId = 2, Number = 3, Row = 1 },
                new Seat() { Id = 9, AreaId = 2, Number = 4, Row = 1 },
                new Seat() { Id = 10, AreaId = 2, Number = 5, Row = 1 },
                new Seat() { Id = 11, AreaId = 3, Number = 1, Row = 1 },
                new Seat() { Id = 12, AreaId = 3, Number = 2, Row = 1 },
                new Seat() { Id = 13, AreaId = 3, Number = 3, Row = 1 },
                new Seat() { Id = 14, AreaId = 3, Number = 4, Row = 1 },
                new Seat() { Id = 15, AreaId = 3, Number = 5, Row = 1 },
                new Seat() { Id = 16, AreaId = 4, Number = 1, Row = 1 },
                new Seat() { Id = 17, AreaId = 4, Number = 2, Row = 1 },
                new Seat() { Id = 18, AreaId = 4, Number = 3, Row = 1 },
                new Seat() { Id = 19, AreaId = 4, Number = 4, Row = 1 },
                new Seat() { Id = 20, AreaId = 4, Number = 5, Row = 1 },
                new Seat() { Id = 21, AreaId = 5, Number = 1, Row = 1 },
                new Seat() { Id = 22, AreaId = 5, Number = 2, Row = 1 },
                new Seat() { Id = 23, AreaId = 5, Number = 3, Row = 1 },
                new Seat() { Id = 24, AreaId = 5, Number = 4, Row = 1 },
                new Seat() { Id = 25, AreaId = 5, Number = 5, Row = 1 },
                new Seat() { Id = 26, AreaId = 6, Number = 1, Row = 1 },
                new Seat() { Id = 27, AreaId = 6, Number = 2, Row = 1 },
                new Seat() { Id = 28, AreaId = 6, Number = 3, Row = 1 },
                new Seat() { Id = 29, AreaId = 6, Number = 4, Row = 1 },
                new Seat() { Id = 30, AreaId = 6, Number = 5, Row = 1 },
                new Seat() { Id = 31, AreaId = 7, Number = 1, Row = 1 },
                new Seat() { Id = 32, AreaId = 7, Number = 2, Row = 1 },
                new Seat() { Id = 33, AreaId = 7, Number = 3, Row = 1 },
                new Seat() { Id = 34, AreaId = 7, Number = 4, Row = 1 },
                new Seat() { Id = 35, AreaId = 7, Number = 5, Row = 1 },
                new Seat() { Id = 36, AreaId = 8, Number = 1, Row = 1 },
                new Seat() { Id = 37, AreaId = 8, Number = 2, Row = 1 },
                new Seat() { Id = 38, AreaId = 8, Number = 3, Row = 1 },
                new Seat() { Id = 39, AreaId = 8, Number = 4, Row = 1 },
                new Seat() { Id = 40, AreaId = 8, Number = 5, Row = 1 },
            };
            var fakeSeatsRepository = new RepositoryFake<Seat>(seats);

            var eventAreas = new List<EventArea>
            {
                new EventArea() { Id = 1, CoordinateX = 1, CoordinateY = 1, Description = "First area event", EventId = 1, Price = 100 },
                new EventArea() { Id = 2, CoordinateX = 1, CoordinateY = 1, Description = "Second area event", EventId = 1, Price = 100 },
                new EventArea() { Id = 3, CoordinateX = 2, CoordinateY = 2, Description = "First area event", EventId = 2, Price = 200 },
                new EventArea() { Id = 4, CoordinateX = 2, CoordinateY = 2, Description = "Second area event", EventId = 2, Price = 200 },
                new EventArea() { Id = 4, CoordinateX = 2, CoordinateY = 2, Description = "Area event without price", EventId = 2, Price = 0 },
            };
            var fakeEventAreaRepository = new RepositoryFake<EventArea>(eventAreas);

            var eventSeats = new List<EventSeat>
            {
                new EventSeat() { Id = 1, State = EventSeatState.Free, EventAreaId = 1, Row = 1, Number = 1 },
                new EventSeat() { Id = 2, State = EventSeatState.Free, EventAreaId = 1, Row = 1, Number = 2 },
                new EventSeat() { Id = 3, State = EventSeatState.Free, EventAreaId = 1, Row = 1, Number = 3 },
                new EventSeat() { Id = 4, State = EventSeatState.Free, EventAreaId = 1, Row = 1, Number = 4 },
                new EventSeat() { Id = 5, State = EventSeatState.Sold, EventAreaId = 1, Row = 1, Number = 5 },
                new EventSeat() { Id = 6, State = EventSeatState.InBasket, EventAreaId = 2, Row = 1, Number = 1 },
                new EventSeat() { Id = 7, State = EventSeatState.Sold, EventAreaId = 2, Row = 1, Number = 2 },
                new EventSeat() { Id = 8, State = EventSeatState.InBasket, EventAreaId = 2, Row = 1, Number = 3 },
                new EventSeat() { Id = 9, State = EventSeatState.Free, EventAreaId = 2, Row = 1, Number = 4 },
                new EventSeat() { Id = 10, State = EventSeatState.Free, EventAreaId = 2, Row = 1, Number = 5 },
                new EventSeat() { Id = 11, State = EventSeatState.Free, EventAreaId = 3, Row = 1, Number = 1 },
                new EventSeat() { Id = 12, State = EventSeatState.Free, EventAreaId = 3, Row = 1, Number = 2 },
                new EventSeat() { Id = 13, State = EventSeatState.Free, EventAreaId = 3, Row = 1, Number = 3 },
                new EventSeat() { Id = 14, State = EventSeatState.Free, EventAreaId = 3, Row = 1, Number = 4 },
                new EventSeat() { Id = 15, State = EventSeatState.Free, EventAreaId = 3, Row = 1, Number = 5 },
                new EventSeat() { Id = 16, State = EventSeatState.Free, EventAreaId = 4, Row = 1, Number = 1 },
                new EventSeat() { Id = 17, State = EventSeatState.Free, EventAreaId = 4, Row = 1, Number = 2 },
                new EventSeat() { Id = 18, State = EventSeatState.Free, EventAreaId = 4, Row = 1, Number = 3 },
                new EventSeat() { Id = 19, State = EventSeatState.Free, EventAreaId = 4, Row = 1, Number = 4 },
                new EventSeat() { Id = 20, State = EventSeatState.Free, EventAreaId = 4, Row = 1, Number = 5 },
            };
            var fakeEventSeatRepository = new RepositoryFake<EventSeat>(eventSeats);

            this.Mock = AutoMock.GetLoose(builder =>
            {
                builder.RegisterInstance(fakeLayoutRepository)
                .As<IRepository<Layout>>();
                builder.RegisterInstance(fakeEventRepository)
                .As<IRepository<Event>>();
                builder.RegisterInstance(fakeAreaRepository)
                .As<IRepository<Area>>();
                builder.RegisterInstance(fakeSeatsRepository)
               .As<IRepository<Seat>>();
                builder.RegisterInstance(fakeEventAreaRepository)
               .As<IRepository<EventArea>>();
                builder.RegisterInstance(fakeEventSeatRepository)
               .As<IRepository<EventSeat>>();
            });
        }

        [TearDown]
        public void TearDown()
        {
            this.Mock?.Dispose();
        }

        [Test]
        public void PublishValidation_WhenPublishValidationEventWithNotPublishStatusAndAllAreaInEventHavePrice_ShouldNotBeThrowException()
        {
            // Arrange
            this.eventValidator = this.Mock.Create<EventValidator>();
            var dto = this.Fixture.Build<Event>()
                .With(e => e.Published, false)
                .Create();

            // Act
            Action validate = () => this.eventValidator.PublishValidation(dto);

            // Assert
            validate.Should().NotThrow();
        }

        [Test]
        public void PublishValidation_WhenPublishValidationEventWithPublishStatusAndAllAreaInEventHavePrice_ShouldBeThrowEventAlreadyPublishedException()
        {
            // Arrange
            this.eventValidator = this.Mock.Create<EventValidator>();
            var dto = this.Fixture.Build<Event>()
                .With(e => e.Published, true)
                .Create();

            // Act
            Action validate = () => this.eventValidator.PublishValidation(dto);

            // Assert
            validate.Should().Throw<EventAlreadyPublishedException>();
        }

        [Test]
        public void PublishValidation_WhenPublishValidationEventWithNotPublishStatusButSomeAreasInEventHaveNotPrice_ShouldBeThrowSomeAreaHasNotPriceException()
        {
            // Arrange
            this.eventValidator = this.Mock.Create<EventValidator>();
            var dto = this.Fixture.Build<Event>()
                .With(e => e.Id, 2)
                .With(e => e.Published, false)
                .Create();

            // Act
            Action validate = () => this.eventValidator.PublishValidation(dto);

            // Assert
            validate.Should().Throw<SomeAreaHasNotPriceException>();
        }

        [Test]
        public void Validation_WhenValidationEventWithBeginDateInPast_ShouldBeThrowEventInPastException()
        {
            // Arrange
            this.eventValidator = this.Mock.Create<EventValidator>();
            var beginDate = DateTime.Now.AddDays(-1);
            var dto = this.Fixture.Build<Event>()
                .With(e => e.LayoutId, 2)
                .With(e => e.BeginDateUtc, beginDate)
                .Create();

            // Act
            Action validate = () => this.eventValidator.Validation(dto);

            // Assert
            validate.Should().Throw<EventInPastException>();
        }

        [Test]
        public void Validation_WhenValidationEventWithBeginDateLongerThenEndDate_ShouldBeThrowBeginDateLongerThenEndDateException()
        {
            // Arrange
            this.eventValidator = this.Mock.Create<EventValidator>();
            var beginDate = DateTime.Now.AddDays(5);
            var endDate = DateTime.Now.AddDays(4);
            var dto = this.Fixture.Build<Event>()
                .With(e => e.LayoutId, 2)
                .With(e => e.BeginDateUtc, beginDate)
                .With(e => e.EndDateUtc, endDate)
                .Create();

            // Act
            Action validate = () => this.eventValidator.Validation(dto);

            // Assert
            validate.Should().Throw<BeginDateLongerThenEndDateException>();
        }

        [Test]
        public void Validation_WhenValidationEventWithExistingAnotherEventInLayoutInTheSameTime_ShouldBeThrowEventExistInTheLayoutInThisTimeException()
        {
            // Arrange
            this.eventValidator = this.Mock.Create<EventValidator>();
            const int layoutId = 1;
            var beginDate = new DateTime(2025, 12, 12, 12, 00, 00);
            var endDate = new DateTime(2025, 12, 12, 13, 00, 00);
            var dto = this.Fixture.Build<Event>()
                .With(e => e.LayoutId, layoutId)
                .With(e => e.BeginDateUtc, beginDate)
                .With(e => e.EndDateUtc, endDate)
                .Create();

            // Act
            Action validate = () => this.eventValidator.Validation(dto);

            // Assert
            validate.Should().Throw<EventExistInTheLayoutInThisTimeException>();
        }

        [Test]
        public void Validation_WhenValidationEventWithLayoutsWithoutAnyArea_ShouldBeThrowLayoutHasNotAreaException()
        {
            // Arrange
            this.eventValidator = this.Mock.Create<EventValidator>();
            const int layoutWithoutAreasId = 100;
            var beginDate = new DateTime(2025, 10, 20, 8, 30, 59);
            var endDate = new DateTime(2025, 10, 20, 10, 30, 59);
            var dto = this.Fixture.Build<Event>()
                .With(e => e.LayoutId, layoutWithoutAreasId)
                .With(e => e.BeginDateUtc, beginDate)
                .With(e => e.EndDateUtc, endDate)
                .Create();

            // Act
            Action validate = () => this.eventValidator.Validation(dto);

            // Assert
            validate.Should().Throw<LayoutHasNotAreaException>();
        }

        [Test]
        public void Validation_WhenValidationEventWithNonexistentSeatsInLayouts_ShouldBeThrowLayoutHasNotSeatException()
        {
            // Arrange
            this.eventValidator = this.Mock.Create<EventValidator>();
            const int layoutWithoutSeatsId = 101;
            var beginDate = new DateTime(2025, 10, 20, 8, 30, 59);
            var endDate = new DateTime(2025, 10, 20, 10, 30, 59);
            var dto = this.Fixture.Build<Event>()
                .With(e => e.LayoutId, layoutWithoutSeatsId)
                .With(e => e.BeginDateUtc, beginDate)
                .With(e => e.EndDateUtc, endDate)
                .Create();

            // Act
            Action validate = () => this.eventValidator.Validation(dto);

            // Assert
            validate.Should().Throw<LayoutHasNotSeatException>();
        }

        [Test]
        public void Validation_WhenValidationEventWithValidFields_ShouldNotBeThrowException()
        {
            // Arrange
            this.eventValidator = this.Mock.Create<EventValidator>();
            const int layoutWithoutSeatsId = 1;
            var beginDate = new DateTime(2025, 10, 20, 8, 30, 59);
            var endDate = new DateTime(2025, 10, 20, 10, 30, 59);
            var dto = this.Fixture.Build<Event>()
                .With(e => e.LayoutId, layoutWithoutSeatsId)
                .With(e => e.BeginDateUtc, beginDate)
                .With(e => e.EndDateUtc, endDate)
                .Create();

            // Act
            Action validate = () => this.eventValidator.Validation(dto);

            // Assert
            validate.Should().NotThrow();
        }

        [Test]
        public void UpdateValidation_WhenUpdateValidationEventWithTheSameLayout_ShouldNotBeThrowException()
        {
            // Arrange
            this.eventValidator = this.Mock.Create<EventValidator>();
            const int eventId = 1;
            const int layoutId = 1;
            var dto = new Event()
            {
                Id = eventId,
                BeginDateUtc = new DateTime(2026, 12, 12, 12, 00, 00),
                EndDateUtc = new DateTime(2026, 12, 12, 13, 00, 00),
                Description = "First2",
                LayoutId = layoutId,
                Name = "First event2",
            };

            // Act
            Action validate = () => this.eventValidator.UpdateValidation(dto);

            // Assert
            validate.Should().NotThrow();
        }

        [Test]
        public void UpdateValidation_WhenUpdateValidationEventWithAnotherLayoutIdAndExistingSoldSeats_ShouldBeThrowLayoutHasSoldSeatAndCouldNotBeChangeException()
        {
            // Arrange
            this.eventValidator = this.Mock.Create<EventValidator>();
            const int eventId = 1;
            const int layoutId = 2;
            var dto = new Event()
            {
                Id = eventId,
                BeginDateUtc = new DateTime(2026, 12, 12, 12, 00, 00),
                EndDateUtc = new DateTime(2026, 12, 12, 13, 00, 00),
                Description = "First2",
                LayoutId = layoutId,
                Name = "First event2",
            };

            // Act
            Action validate = () => this.eventValidator.UpdateValidation(dto);

            // Assert
            validate.Should().Throw<LayoutHasSoldSeatAndCouldNotBeChangeException>();
        }

        [Test]
        public void UpdateValidation_WhenUpdateValidationEventWithoutSoldSeats_ShouldNotBeThrowException()
        {
            // Arrange
            this.eventValidator = this.Mock.Create<EventValidator>();
            const int eventId = 2;
            var dto = new Event()
            {
                Id = eventId,
                BeginDateUtc = new DateTime(2028, 12, 12, 13, 00, 00),
                EndDateUtc = new DateTime(2028, 12, 12, 14, 00, 00),
                Description = "Second",
                LayoutId = 1,
                Name = "Second event",
            };

            // Act
            Action validate = () => this.eventValidator.UpdateValidation(dto);

            // Assert
            validate.Should().NotThrow();
        }

        [Test]
        public void DeleteValidation_WhenDeleteValidationEventWithExistingSoldSeats_ShouldBeThrowLayoutHasSoldSeatAndCouldNotBeChangeException()
        {
            // Arrange
            this.eventValidator = this.Mock.Create<EventValidator>();
            const int eventIdWithExistingSoldSeats = 1;

            // Act
            Action validate = () => this.eventValidator.DeleteValidation(eventIdWithExistingSoldSeats);

            // Assert
            validate.Should().Throw<LayoutHasSoldSeatAndCouldNotBeChangeException>();
        }

        [Test]
        public void DeleteValidation_WhenDeleteValidationEventWithoutSoldSeats_ShouldNotBeThrowException()
        {
            // Arrange
            this.eventValidator = this.Mock.Create<EventValidator>();
            const int eventWithoutSoldSeats = 2;

            // Act
            Action validate = () => this.eventValidator.DeleteValidation(eventWithoutSoldSeats);

            // Assert
            validate.Should().NotThrow();
        }
    }
}
