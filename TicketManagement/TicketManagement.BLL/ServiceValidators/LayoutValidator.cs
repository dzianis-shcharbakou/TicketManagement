// ****************************************************************************
// <copyright file="LayoutValidator.cs" company="EPAM Systems">
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
    internal class LayoutValidator : ValidatorBase, ILayoutValidator
    {
        private const string ExistLayoutWithThisNameException = "ExistLayoutWithThisNameException";

        private readonly Dictionary<string, string> exceptionMessagies;

        private readonly IRepository<Layout> layoutRepository;

        public LayoutValidator(IRepository<Layout> layoutRepository)
        {
            this.exceptionMessagies = new Dictionary<string, string>();
            this.exceptionMessagies.Add(ExistLayoutWithThisNameException, "there is layout with this name in the venue");

            this.layoutRepository = layoutRepository;
        }

        public void IsUniqLayoutNameInTheVenue(string nameLayout, int venueId)
        {
            if (this.IsLayoutName(nameLayout, venueId))
            {
                throw new TicketManagementException(this.exceptionMessagies.First(x => x.Key == ExistLayoutWithThisNameException).Value, ExistLayoutWithThisNameException);
            }
        }

        private bool IsLayoutName(string nameLayout, int venueId)
        {
            var query = this.layoutRepository.GetAll()
                .Where(x => x.Name == nameLayout && x.VenueId == venueId);

            return query.Any();
        }
    }
}
