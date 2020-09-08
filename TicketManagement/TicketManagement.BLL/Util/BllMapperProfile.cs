// ****************************************************************************
// <copyright file="BllMapperProfile.cs" company="EPAM Systems">
// Copyright (c) EPAM Systems. All rights reserved.
// Author Dzianis Shcharbakou.
// </copyright>
// ****************************************************************************

using AutoMapper;
using TicketManagement.BLL.DTO;
using TicketManagement.DAL.Models;

namespace TicketManagement.BLL.Util
{
    public class BllMapperProfile : Profile
    {
        public BllMapperProfile()
        {
            this.AllowNullDestinationValues = true;

            this.CreateMap<EventArea, EventAreaDto>().ReverseMap();
            this.CreateMap<Event, EventDto>().ReverseMap();
            this.CreateMap<EventSeat, EventSeatDto>().ReverseMap();
            this.CreateMap<Area, AreaDto>().ReverseMap();
            this.CreateMap<Layout, LayoutDto>().ReverseMap();
            this.CreateMap<Seat, SeatDto>().ReverseMap();
            this.CreateMap<Venue, VenueDto>().ReverseMap();

            this.CreateMap<Area, EventArea>()
                .ForMember(x => x.EventId, opt => opt.Ignore())
                .ForMember(x => x.Price, opt => opt.Ignore());

            this.CreateMap<EventDto, EventArea>()
                .ForMember(d => d.EventId, a => a.MapFrom(s => s.Id))
                .ForMember(x => x.Price, opt => opt.Ignore())
                .ForMember(x => x.CoordX, opt => opt.Ignore())
                .ForMember(x => x.CoordY, opt => opt.Ignore())
                ;

            var eventAreaIdExpression = this.CreateMap<int, EventSeat>()
                .ForMember(d => d.EventAreaId, a => a.MapFrom(s => s))
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(x => x.Row, opt => opt.Ignore())
                .ForMember(x => x.Number, opt => opt.Ignore())
                .ForMember(x => x.State, opt => opt.Ignore());

            this.CreateMap<Seat, EventSeat>()
                .ForMember(x => x.State, opt => opt.Ignore())
                .ForMember(x => x.EventAreaId, opt => opt.Ignore());

            this.CreateMap<int, EventArea>()
                .ForMember(d => d.EventId, a => a.MapFrom(s => s))
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(x => x.Description, opt => opt.Ignore())
                .ForMember(x => x.Price, opt => opt.Ignore())
                .ForMember(x => x.CoordX, opt => opt.Ignore())
                .ForMember(x => x.CoordY, opt => opt.Ignore());
        }
    }
}
