// ****************************************************************************
// <copyright file="VenueService.cs" company="EPAM Systems">
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
    internal class VenueService : IVenueService
    {
        private readonly IRepository<Venue> venueRepository;
        private readonly IMapper mapper;
        private readonly IVenueValidator venueValidator;

        public VenueService(IRepository<Venue> venueRepository, IMapper mapper, IVenueValidator validator)
        {
            this.venueRepository = venueRepository;
            this.mapper = mapper;
            this.venueValidator = validator;
        }

        public int AddVenue(VenueDto entity)
        {
            this.venueValidator.IsVenueNameExist(entity.Name);

            Venue venue = this.mapper.Map<Venue>(entity);

            return Convert.ToInt32(this.venueRepository.Create(venue));
        }

        public void DeleteVenue(int id)
        {
            var result = this.venueRepository.Delete(id);

            this.venueValidator.CUDResultValidate<Venue>(result, id);
        }

        public VenueDto GetVenue(int id)
        {
            Venue venue = this.venueRepository.GetById(id);

            this.venueValidator.QueryResultValidate<Venue>(venue, id);

            return this.mapper.Map<Venue, VenueDto>(venue);
        }

        public IEnumerable<VenueDto> GetVenues()
        {
            var result = this.venueRepository.GetAll();
            return this.mapper.Map<IEnumerable<Venue>, IEnumerable<VenueDto>>(result);
        }

        public void UpdateVenue(VenueDto entity)
        {
            this.venueValidator.IsVenueNameExist(entity.Name);

            Venue venue = this.mapper.Map<Venue>(entity);

            var result = this.venueRepository.Update(venue);

            this.venueValidator.CUDResultValidate<Venue>(result, entity.Id);
        }
    }
}
