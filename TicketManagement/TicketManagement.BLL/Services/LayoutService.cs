// ****************************************************************************
// <copyright file="LayoutService.cs" company="EPAM Systems">
// Copyright (c) EPAM Systems. All rights reserved.
// Author Dzianis Shcharbakou.
// </copyright>
// ****************************************************************************

using System;
using System.Collections.Generic;
using AutoMapper;
using TicketManagement.BLL.DTO;
using TicketManagement.BLL.Interfaces;
using TicketManagement.BLL.ServiceValidators.Interfaces;
using TicketManagement.DAL.Models;
using TicketManagement.DAL.Repositories.Base;

namespace TicketManagement.BLL.Services
{
    public class LayoutService : ILayoutService
    {
        private readonly IRepository<Layout> layoutRepository;

        private readonly IRepository<Venue> venueRepository;

        private readonly IMapper mapper;
        private readonly ILayoutValidator layoutValidator;

        public LayoutService(
            IRepository<Layout> layoutRepository,
            IRepository<Venue> venueRepository,
            IMapper mapper,
            ILayoutValidator layoutValidator)
        {
            this.layoutRepository = layoutRepository;
            this.venueRepository = venueRepository;
            this.mapper = mapper;
            this.layoutValidator = layoutValidator;
        }

        public int AddLayout(LayoutDto layoutDto)
        {
            Venue venue = this.venueRepository.GetById(layoutDto.VenueId);

            this.layoutValidator.QueryResultValidate<Venue>(venue, layoutDto.VenueId);

            this.layoutValidator.IsUniqLayoutNameInTheVenue(layoutDto.Name, layoutDto.VenueId);

            Layout layout = this.mapper.Map<Layout>(layoutDto);

            return Convert.ToInt32(this.layoutRepository.Create(layout));
        }

        public void UpdateLayout(LayoutDto layoutDto)
        {
            Layout layout = this.layoutRepository.GetById(layoutDto.Id);

            this.layoutValidator.QueryResultValidate<Layout>(layout, layoutDto.Id);

            Venue venue = this.venueRepository.GetById(layoutDto.VenueId);

            this.layoutValidator.QueryResultValidate<Venue>(venue, layoutDto.VenueId);

            this.layoutValidator.IsUniqLayoutNameInTheVenue(layoutDto.Name, layoutDto.VenueId);

            layout = this.mapper.Map<Layout>(layoutDto);

            var result = this.layoutRepository.Update(layout);
        }

        public void DeleteLayout(int id)
        {
            var result = this.layoutRepository.Delete(id);

            this.layoutValidator.CUDResultValidate<Layout>(result, id);
        }

        public LayoutDto GetLayout(int id)
        {
            Layout layout = this.layoutRepository.GetById(id);

            this.layoutValidator.QueryResultValidate<Layout>(layout, id);

            return this.mapper.Map<Layout, LayoutDto>(layout);
        }

        public IEnumerable<LayoutDto> GetLayouts()
        {
            var result = this.layoutRepository.GetAll();
            return this.mapper.Map<IEnumerable<Layout>, IEnumerable<LayoutDto>>(result);
        }
    }
}
