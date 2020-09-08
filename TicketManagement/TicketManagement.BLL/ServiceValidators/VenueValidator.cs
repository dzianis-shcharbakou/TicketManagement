// ****************************************************************************
// <copyright file="VenueValidator.cs" company="EPAM Systems">
// Copyright (c) EPAM Systems. All rights reserved.
// Author Dzianis Shcharbakou.
// </copyright>
// ****************************************************************************

using System.Collections.Generic;
using System.Linq;
using TicketManagement.BLL.ServiceValidators.Base;
using TicketManagement.BLL.ServiceValidators.Interfaces;
using TicketManagement.BLL.Util;
using TicketManagement.DAL.Models;
using TicketManagement.DAL.Repositories.Base;

namespace TicketManagement.BLL.ServiceValidators
{
    internal class VenueValidator : ValidatorBase, IVenueValidator
    {
        private const string VenueWithExistingNameException = "VenueWithExistingNameException";

        private readonly Dictionary<string, string> exceptionMessagies;

        private readonly IRepository<Venue> venueRepository;

        public VenueValidator(IRepository<Venue> venueRepository)
        {
            this.exceptionMessagies = new Dictionary<string, string>();
            this.exceptionMessagies.Add(VenueWithExistingNameException, "venue with name={0} exists");

            this.venueRepository = venueRepository;
        }

        public void IsVenueNameExist(string name)
        {
            if (this.IsVenueName(name))
            {
                throw new TicketManagementException(
                    string.Format(
                        this.exceptionMessagies
                    .First(x => x.Key == VenueWithExistingNameException).Value, name),
                    VenueWithExistingNameException);
            }
        }

        private bool IsVenueName(string nameVenue)
        {
            var venueQuery = this.venueRepository.GetAll().Where(x => x.Name == nameVenue);
            return venueQuery.Any();
        }
    }
}
