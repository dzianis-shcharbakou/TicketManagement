// ****************************************************************************
// <copyright file="EventService.cs" company="EPAM Systems">
// Copyright (c) EPAM Systems. All rights reserved.
// Author Dzianis Shcharbakou.
// </copyright>
// ****************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using AutoMapper;
using TicketManagement.BLL.DTO;
using TicketManagement.BLL.Extensions;
using TicketManagement.BLL.Interfaces;
using TicketManagement.BLL.ServiceValidators.Interfaces;
using TicketManagement.BLL.Util;
using TicketManagement.DAL.Models;
using TicketManagement.DAL.Repositories.Base;

namespace TicketManagement.BLL.Services
{
    public class EventService : IEventService
    {
        private readonly IRepository<Area> areaRepository;

        private readonly IRepository<Seat> seatRepository;

        private readonly IRepository<Layout> layoutRepository;

        private readonly IRepository<Event> eventRepository;

        private readonly IRepository<EventArea> eventAreaRepository;

        private readonly IRepository<EventSeat> eventSeatRepository;

        private readonly IMapper mapper;

        private readonly IEventValidator eventValidator;

        public EventService(
            IRepository<Area> areaRepository,
            IRepository<Seat> seatRepository,
            IRepository<Layout> layoutRepository,
            IRepository<Event> eventRepository,
            IRepository<EventArea> eventAreaRepository,
            IRepository<EventSeat> eventSeatRepository,
            IMapper mapper,
            IEventValidator eventValidator)
        {
            this.areaRepository = areaRepository;
            this.seatRepository = seatRepository;
            this.layoutRepository = layoutRepository;
            this.eventRepository = eventRepository;
            this.eventAreaRepository = eventAreaRepository;
            this.eventSeatRepository = eventSeatRepository;
            this.mapper = mapper;
            this.eventValidator = eventValidator;
        }

        public void UpdateEvent(EventDto eventDto)
        {
            Event @event;
            @event = this.UpdateValidation(eventDto);
            if (@event.LayoutId != eventDto.LayoutId)
            {
                this.DeleteValidation(eventDto.Id);
                this.AddValidation(eventDto, out List<Area> areasAdd, out List<Seat> seatsAdd);
                try
                {
                    List<int> eventAreaIdList = this.eventAreaRepository.GetAll().Where(x => x.EventId == @event.Id).Select(x => x.Id).ToList();

                    using (var transaction = new TransactionScope())
                    {
                        // cascade delete eventarea and eventseat
                        foreach (var item in eventAreaIdList)
                        {
                            this.eventAreaRepository.Delete(item);
                        }

                        @event = this.mapper.Map<Event>(eventDto);
                        this.eventRepository.Update(@event);

                        foreach (Area area in areasAdd)
                        {
                            List<Seat> seatsAddId = seatsAdd.FindAll(x => x.AreaId == area.Id);

                            EventArea eventArea = this.mapper.MergeInto<EventArea>(area, eventDto);

                            int id = Convert.ToInt32(this.eventAreaRepository.Create(eventArea));
                            foreach (Seat seat in seatsAddId)
                            {
                                EventSeat eventSeat = this.mapper.MergeInto<EventSeat>(seat, id);

                                this.eventSeatRepository.Create(eventSeat);
                            }
                        }

                        transaction.Complete();
                    }
                }
                catch (TransactionAbortedException)
                {
                    throw new TicketManagementException("TransactionAbortedException Message", "TransactionAbortedException");
                }
            }
            else
            {
                @event.Name = eventDto.Name;
                @event.BeginDate = eventDto.BeginDate;
                @event.EndDate = eventDto.EndDate;
                @event.Description = eventDto.Description;
                var result = this.eventRepository.Update(@event);
                this.eventValidator.CUDResultValidate<Event>(result, @event.Id);
            }
        }

        public int AddEvent(EventDto eventDto)
        {
            this.AddValidation(eventDto, out List<Area> areas, out List<Seat> seats);

            Event @event = this.mapper.Map<Event>(eventDto);

            try
            {
                using (var transaction = new TransactionScope())
                {
                    int id = Convert.ToInt32(this.eventRepository.Create(@event));

                    foreach (Area area in areas)
                    {
                        List<Seat> seatsAddId = seats.FindAll(x => x.AreaId == area.Id);
                        EventArea eventArea = this.mapper.MergeInto<EventArea>(area, id);

                        int eventAreaId = Convert.ToInt32(this.eventAreaRepository.Create(eventArea));

                        foreach (Seat seat in seatsAddId)
                        {
                            EventSeat eventSeat = this.mapper.MergeInto<EventSeat>(seat, eventAreaId);

                            this.eventSeatRepository.Create(eventSeat);
                        }
                    }

                    transaction.Complete();

                    return id;
                }
            }
            catch (TransactionAbortedException)
            {
                throw new TicketManagementException("TransactionAbortedException Message", "TransactionAbortedException");
            }
        }

        public void DeleteEvent(int id)
        {
            this.DeleteValidation(id);
            try
            {
                using (var transaction = new TransactionScope())
                {
                    var result = this.eventRepository.Delete(id);
                    transaction.Complete();
                    this.eventValidator.CUDResultValidate<Event>(result, id);
                }
            }
            catch (TransactionAbortedException)
            {
                throw new TicketManagementException("TransactionAbortedException Message: ", "TransactionAbortedException");
            }
        }

        public EventDto GetEvent(int id)
        {
            Event @event = this.eventRepository.GetById(id);
            this.eventValidator.QueryResultValidate<Event>(@event, id);

            return this.mapper.Map<EventDto>(@event);
        }

        public IEnumerable<EventDto> GetEvents()
        {
            var result = this.eventRepository.GetAll();
            return this.mapper.Map<IEnumerable<Event>, IEnumerable<EventDto>>(result);
        }

        private Event UpdateValidation(EventDto eventDto)
        {
            Event @event = this.eventRepository.GetById(eventDto.Id);
            this.eventValidator.QueryResultValidate<Event>(@event, eventDto.Id);

            this.eventValidator.IsValidEventDates(eventDto);

            this.eventValidator.IsAnyTicketSold(eventDto.Id);

            return @event;
        }

        private void AddValidation(EventDto eventDto, out List<Area> areas, out List<Seat> seats)
        {
            var areasQuery = this.areaRepository.GetAll().Where(x => x.LayoutId == eventDto.LayoutId);

            var seatsInAreasQuery =
                from areasQ in areasQuery
                join seatsQ in this.seatRepository.GetAll() on areasQ.Id equals seatsQ.AreaId
                select new Seat { Id = seatsQ.Id, AreaId = seatsQ.AreaId, Number = seatsQ.Number, Row = seatsQ.Row };

            Layout layout = this.layoutRepository.GetById(eventDto.LayoutId);
            this.eventValidator.QueryResultValidate<Layout>(layout, eventDto.LayoutId);

            areas = areasQuery.ToList();

            this.eventValidator.ExistAreaForEvent(this.mapper.Map<IEnumerable<AreaDto>>(areasQuery));

            seats = seatsInAreasQuery.ToList();

            this.eventValidator.ExistSeatForEvent(this.mapper.Map<IEnumerable<SeatDto>>(seatsInAreasQuery));

            this.eventValidator.IsValidEventDates(eventDto);
        }

        private void DeleteValidation(int id)
        {
            Event @event = this.eventRepository.GetById(id);
            this.eventValidator.QueryResultValidate<Event>(@event, id);

            this.eventValidator.SoldTicketExist(@event.Id);
        }
    }
}
