// ****************************************************************************
// <copyright file="EventAreaService.cs" company="EPAM Systems">
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
    public class EventAreaService : IEventAreaService
    {
        private readonly IRepository<EventArea> eventAreaRepository;

        private readonly IRepository<EventSeat> eventSeatRepository;

        private readonly IRepository<Event> eventRepository;

        private readonly IMapper mapper;

        private readonly IEventAreaValidator eventAreaValidator;

        public EventAreaService(IRepository<EventArea> eventArea, IRepository<EventSeat> eventSeat, IRepository<Event> @event, IMapper mapper, IEventAreaValidator eventAreaValidator)
        {
            this.eventAreaRepository = eventArea;
            this.eventSeatRepository = eventSeat;
            this.eventRepository = @event;
            this.mapper = mapper;
            this.eventAreaValidator = eventAreaValidator;
        }

        public void UpdateEventArea(EventAreaDto eventAreaDto)
        {
            EventArea eventArea = this.eventAreaRepository.GetById(eventAreaDto.Id);

            this.eventAreaValidator.QueryResultValidate<EventArea>(eventArea, eventAreaDto.Id);

            eventArea.Price = eventAreaDto.Price;

            this.eventAreaRepository.Update(eventArea);
        }

        public EventAreaDto GetEventArea(int id)
        {
            EventArea eventArea = this.eventAreaRepository.GetById(id);

            this.eventAreaValidator.QueryResultValidate<EventArea>(eventArea, id);

            return this.mapper.Map<EventArea, EventAreaDto>(eventArea);
        }

        public IEnumerable<EventAreaDto> GetEventAreas()
        {
            var result = this.eventAreaRepository.GetAll();

            return this.mapper.Map<IEnumerable<EventArea>, List<EventAreaDto>>(result);
        }
    }
}
