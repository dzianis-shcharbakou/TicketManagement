﻿// ****************************************************************************
// <copyright file="VenueValidator.cs" company="EPAM Systems">
// Copyright (c) EPAM Systems. All rights reserved.
// Author Dzianis Shcharbakou.
// </copyright>
// ****************************************************************************

using System.Linq;
using TicketManagement.BLL.Exceptions.VenueExceptions;
using TicketManagement.BLL.ServiceValidators.Interfaces;
using TicketManagement.DAL.Models;
using TicketManagement.DAL.Repositories.Base;

namespace TicketManagement.BLL.ServiceValidators
{
    public class VenueValidator : IVenueValidator
    {
        private readonly IRepository<Venue> venueRepository;

        public VenueValidator(IRepository<Venue> venueRepository)
        {
            this.venueRepository = venueRepository;
        }

        public void Validation(Venue entity)
        {
            if (this.venueRepository.GetAll().Any(x => x.Name == entity.Name))
            {
                throw new VenueWithThisNameExistException($"Venue with name:{entity.Name} already exist.");
            }
        }
    }
}
