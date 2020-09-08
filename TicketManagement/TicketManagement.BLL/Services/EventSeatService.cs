// ****************************************************************************
// <copyright file="EventSeatService.cs" company="EPAM Systems">
// Copyright (c) EPAM Systems. All rights reserved.
// Author Dzianis Shcharbakou.
// </copyright>
// ****************************************************************************

using System.Collections.Generic;
using AutoMapper;
using TicketManagement.BLL.DTO;
using TicketManagement.BLL.Interfaces;
using TicketManagement.BLL.ServiceValidators.Interfaces;
using TicketManagement.DAL.Models;
using TicketManagement.DAL.Repositories.Base;

namespace TicketManagement.BLL.Services
{
    public class EventSeatService : IEventSeatService
    {
        private readonly IRepository<EventSeat> eventSeatRepository;

        private readonly IMapper mapper;

        private readonly IEventSeatValidator eventSeatValidator;

        public EventSeatService(IRepository<EventSeat> eventSeat, IMapper mapper, IEventSeatValidator eventSeatValidator)
        {
            this.eventSeatRepository = eventSeat;
            this.mapper = mapper;
            this.eventSeatValidator = eventSeatValidator;
        }

        public void UpdateEventSeat(EventSeatDto eventSeatDto)
        {
            EventSeat eventSeat = this.eventSeatRepository.GetById(eventSeatDto.Id);

            this.eventSeatValidator.QueryResultValidate<EventSeat>(eventSeat, eventSeatDto.Id);

            eventSeat.State = eventSeatDto.State;

            this.eventSeatRepository.Update(eventSeat);
        }

        public EventSeatDto GetEventSeat(int id)
        {
            EventSeat eventSeat = this.eventSeatRepository.GetById(id);

            this.eventSeatValidator.QueryResultValidate<EventSeat>(eventSeat, id);

            return this.mapper.Map<EventSeat, EventSeatDto>(eventSeat);
        }

        public IEnumerable<EventSeatDto> GetEventSeats()
        {
            var result = this.eventSeatRepository.GetAll();

            return this.mapper.Map<IEnumerable<EventSeat>, List<EventSeatDto>>(result);
        }
    }
}
