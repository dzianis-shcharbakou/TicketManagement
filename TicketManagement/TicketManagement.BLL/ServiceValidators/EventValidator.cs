// ****************************************************************************
// <copyright file="EventValidator.cs" company="EPAM Systems">
// Copyright (c) EPAM Systems. All rights reserved.
// Author Dzianis Shcharbakou.
// </copyright>
// ****************************************************************************

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using TicketManagement.BLL.Constants;
using TicketManagement.BLL.DTO;
using TicketManagement.BLL.ServiceValidators.Base;
using TicketManagement.BLL.ServiceValidators.Interfaces;
using TicketManagement.BLL.Util;
using TicketManagement.DAL.Models;
using TicketManagement.DAL.Repositories.Base;

namespace TicketManagement.BLL.ServiceValidators
{
    internal class EventValidator : ValidatorBase, IEventValidator
    {
        private const string EventIsNotDeletingException = "EventIsNotDeletingException";
        private const string LayoutNotHasAreasException = "LayoutNotHasAreasException";
        private const string AreasNotHasSeatsException = "AreasNotHasSeatsException";
        private const string CreateInPastException = "CreateInPastException";
        private const string BeginDateLongerEndDateException = "BeginDateLongerEndDateException";
        private const string CreateEventInSameTimeException = "CreateEventInSameTimeException";

        private readonly Dictionary<string, string> exceptionMessagies;

        private readonly IRepository<Event> eventRepository;
        private readonly IRepository<EventArea> eventAreaRepository;
        private readonly IRepository<EventSeat> eventSeatRepository;

        public EventValidator(IRepository<Event> eventRepository, IRepository<EventArea> eventAreaRepository, IRepository<EventSeat> eventSeatRepository)
        {
            this.exceptionMessagies = new Dictionary<string, string>
            {
                { EventIsNotDeletingException, "event is not deleting, because one or more ticket have been sold" },
                { LayoutNotHasAreasException, "event doesn't create because layout does not has areas" },
                { AreasNotHasSeatsException, "event doesn't create because areas does not has seats" },
                { CreateInPastException, "can not create an event in the past" },
                { BeginDateLongerEndDateException, "begin date cannot be longer than end date" },
                { CreateEventInSameTimeException, "event can not be created in same time with other event" },
            };

            this.eventRepository = eventRepository;
            this.eventAreaRepository = eventAreaRepository;
            this.eventSeatRepository = eventSeatRepository;
        }

        public void SoldTicketExist(int eventId)
        {
            if (this.IsSoldSeatExist(eventId))
            {
                throw new TicketManagementException(this.exceptionMessagies.First(x => x.Key == EventIsNotDeletingException).Value, EventIsNotDeletingException);
            }
        }

        public void ExistAreaForEvent(IEnumerable<AreaDto> areas)
        {
            if (areas.Count() < 1)
            {
                throw new TicketManagementException(this.exceptionMessagies.First(x => x.Key == LayoutNotHasAreasException).Value, LayoutNotHasAreasException);
            }
        }

        public void ExistSeatForEvent(IEnumerable<SeatDto> seats)
        {
            if (seats.Count() < 1)
            {
                throw new TicketManagementException(this.exceptionMessagies.First(x => x.Key == AreasNotHasSeatsException).Value, AreasNotHasSeatsException);
            }
        }

        public void IsAnyTicketSold(int eventId)
        {
            var isAnyTicketSold =
                                (from areasQ in this.eventAreaRepository.GetAll().Where(x => x.EventId == eventId)
                                 join eventQ in this.eventSeatRepository.GetAll() on areasQ.Id equals eventQ.EventAreaId
                                 select new { eventQ.State }).Any(x => x.State != 0);

            if (isAnyTicketSold)
            {
                throw new TicketManagementException("event is not deleting, because one or more ticket have been sold", "EventIsNotDeletingException");
            }
        }

        public void IsValidEventDates(EventDto eventDto)
        {
            if (this.IsDateInPast(eventDto.BeginDate))
            {
                throw new TicketManagementException(this.exceptionMessagies.First(x => x.Key == CreateInPastException).Value, CreateInPastException);
            }

            if (this.IsLongerBeginDate(eventDto.BeginDate, eventDto.EndDate))
            {
                throw new TicketManagementException(this.exceptionMessagies.First(x => x.Key == BeginDateLongerEndDateException).Value, BeginDateLongerEndDateException);
            }

            if (this.IsEventInLayoutSameTime(
                eventDto.LayoutId,
                eventDto.BeginDate.ToString("dd.MM.yyyy HH:mm"),
                eventDto.EndDate.ToString("dd.MM.yyyy HH:mm")))
            {
                throw new TicketManagementException(this.exceptionMessagies.First(x => x.Key == CreateEventInSameTimeException).Value, CreateEventInSameTimeException);
            }
        }

        private bool IsDateInPast(DateTime dateTime)
        {
            DateTime dt = DateTime.Now;
            long now = (long)TimeSpan.FromTicks(dt.Ticks).TotalMinutes;
            long begin = (long)TimeSpan.FromTicks(dateTime.Ticks).TotalMinutes;
            return now > begin;
        }

        private bool IsLongerBeginDate(DateTime beginDate, DateTime endDate)
        {
            long begin = (long)TimeSpan.FromTicks(beginDate.Ticks).TotalMinutes;
            long end = (long)TimeSpan.FromTicks(endDate.Ticks).TotalMinutes;
            return begin >= end;
        }

        private bool IsEventInLayoutSameTime(int layoutId, string beginDate, string endDate)
        {
            DateTime begin = Convert.ToDateTime(beginDate, new CultureInfo("ru"));
            DateTime end = Convert.ToDateTime(endDate, new CultureInfo("ru"));

            var seatsInAreasQvery =
                from a in this.eventRepository.GetAll().Where(x => x.LayoutId == layoutId)
                where (a.BeginDate <= begin && a.EndDate >= begin) ||
                          (a.BeginDate <= end && a.EndDate >= end) ||
                      (a.BeginDate >= begin && a.BeginDate <= end) ||
                          (a.EndDate >= begin && a.EndDate <= end)
                select new { a.Id };
            var events = seatsInAreasQvery.Any();
            return events;
        }

        private bool IsSoldSeatExist(int eventId)
        {
            var seatsInAreasQvery =
                    from eventArea in this.eventAreaRepository.GetAll().Where(x => x.EventId == eventId)
                    join eventSeat in this.eventSeatRepository.GetAll() on eventArea.Id equals eventSeat.EventAreaId
                    where eventSeat.State != (int)EventSeatState.Free
                    select new { eventSeat.State };

            return seatsInAreasQvery.Any();
        }
    }
}
