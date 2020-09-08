// ****************************************************************************
// <copyright file="InitializeFakeData.cs" company="EPAM Systems">
// Copyright (c) EPAM Systems. All rights reserved.
// Author Dzianis Shcharbakou.
// </copyright>
// ****************************************************************************

using System;
using System.Collections.Generic;
using TicketManagement.DAL.Models;

namespace TicketManagement.UnitTests.FakeRepositories.Util
{
    internal class InitializeFakeData
    {
        public static List<Area> InitializeAreaData()
        {
            return new List<Area>
            {
                new Area() { Id = 1, Description = "First area of first layout", CoordX = 1, CoordY = 1, LayoutId = 1 },
                new Area() { Id = 2, Description = "Second area of first layout", CoordX = 2, CoordY = 2, LayoutId = 1 },
                new Area() { Id = 3, Description = "First area of second layout", CoordX = 3, CoordY = 3, LayoutId = 2 },
                new Area() { Id = 4, Description = "Second area of second layout", CoordX = 4, CoordY = 4, LayoutId = 2 },
                new Area() { Id = 5, Description = "First area of third layout", CoordX = 1, CoordY = 1, LayoutId = 3 },
                new Area() { Id = 6, Description = "Second area of third layout", CoordX = 2, CoordY = 2, LayoutId = 3 },
                new Area() { Id = 7, Description = "First area of fourth layout", CoordX = 3, CoordY = 3, LayoutId = 4 },
                new Area() { Id = 8, Description = "Second area of fourth layout", CoordX = 4, CoordY = 4, LayoutId = 4 },
                new Area() { Id = 101, Description = "Second area of fourth layout", CoordX = 4, CoordY = 4, LayoutId = 101 },
            };
        }

        public static List<Layout> InitializeLayoutData()
        {
            return new List<Layout>
            {
                new Layout() { Id = 1, Name = "first", Description = "First layout", VenueId = 1 },
                new Layout() { Id = 2, Name = "second", Description = "Second layout", VenueId = 1 },
                new Layout() { Id = 3, Name = "third", Description = "First layout", VenueId = 2 },
                new Layout() { Id = 4, Name = "forth", Description = "Second layout", VenueId = 2 },
                new Layout() { Id = 100, Name = "forth2", Description = "Second layout", VenueId = 2 },
                new Layout() { Id = 101, Name = "forth1", Description = "Second layout", VenueId = 2 },
            };
        }

        public static List<EventArea> InitializeEventAreaData()
        {
            return new List<EventArea>
            {
                new EventArea() { Id = 1, CoordX = 1, CoordY = 1, Description = "First area event", EventId = 1, Price = 100 },
                new EventArea() { Id = 2, CoordX = 1, CoordY = 1, Description = "Second area event", EventId = 1, Price = 100 },
                new EventArea() { Id = 3, CoordX = 2, CoordY = 2, Description = "First area event", EventId = 2, Price = 200 },
                new EventArea() { Id = 4, CoordX = 2, CoordY = 2, Description = "Second area event", EventId = 2, Price = 200 },
            };
        }

        public static List<Event> InitializeEventData()
        {
            return new List<Event>
            {
                new Event()
                {
                    Id = 1, BeginDate = new DateTime(2025, 12, 12, 12, 00, 00),
                    EndDate = new DateTime(2025, 12, 12, 13, 00, 00), Description = "First",
                    LayoutId = 1, Name = "First event",
                },
                new Event()
                {
                    Id = 2, BeginDate = new DateTime(2025, 12, 12, 13, 00, 00),
                    EndDate = new DateTime(2025, 12, 12, 14, 00, 00), Description = "Second",
                    LayoutId = 2, Name = "Second event",
                },
            };
        }

        public static List<EventSeat> InitializeEventSeatData()
        {
            return new List<EventSeat>
            {
                new EventSeat() { Id = 1, State = 0, EventAreaId = 1, Row = 1, Number = 1 },
                new EventSeat() { Id = 2, State = 0, EventAreaId = 1, Row = 1, Number = 2 },
                new EventSeat() { Id = 3, State = 0, EventAreaId = 1, Row = 1, Number = 3 },
                new EventSeat() { Id = 4, State = 0, EventAreaId = 1, Row = 1, Number = 4 },
                new EventSeat() { Id = 5, State = 2, EventAreaId = 1, Row = 1, Number = 5 },
                new EventSeat() { Id = 6, State = 1, EventAreaId = 2, Row = 1, Number = 1 },
                new EventSeat() { Id = 7, State = 2, EventAreaId = 2, Row = 1, Number = 2 },
                new EventSeat() { Id = 8, State = 1, EventAreaId = 2, Row = 1, Number = 3 },
                new EventSeat() { Id = 9, State = 0, EventAreaId = 2, Row = 1, Number = 4 },
                new EventSeat() { Id = 10, State = 0, EventAreaId = 2, Row = 1, Number = 5 },
                new EventSeat() { Id = 11, State = 0, EventAreaId = 3, Row = 1, Number = 1 },
                new EventSeat() { Id = 12, State = 0, EventAreaId = 3, Row = 1, Number = 2 },
                new EventSeat() { Id = 13, State = 0, EventAreaId = 3, Row = 1, Number = 3 },
                new EventSeat() { Id = 14, State = 0, EventAreaId = 3, Row = 1, Number = 4 },
                new EventSeat() { Id = 15, State = 0, EventAreaId = 3, Row = 1, Number = 5 },
                new EventSeat() { Id = 16, State = 0, EventAreaId = 4, Row = 1, Number = 1 },
                new EventSeat() { Id = 17, State = 0, EventAreaId = 4, Row = 1, Number = 2 },
                new EventSeat() { Id = 18, State = 0, EventAreaId = 4, Row = 1, Number = 3 },
                new EventSeat() { Id = 19, State = 0, EventAreaId = 4, Row = 1, Number = 4 },
                new EventSeat() { Id = 20, State = 0, EventAreaId = 4, Row = 1, Number = 5 },
            };
        }

        public static List<Seat> InitializeSeatData()
        {
            return new List<Seat>()
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
        }

        public static List<Venue> InitializeVenueData()
        {
            return new List<Venue>
            {
                new Venue() { Id = 1, Description = "First venue", Name = "first", Address = "First venue address", Phone = "123 45 678 90 12" },
                new Venue() { Id = 2, Description = "Second venue", Name = "second", Address = "Second venue address", Phone = "123 45 678 90 12" },
            };
        }
    }
}
