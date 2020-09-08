// ****************************************************************************
// <copyright file="IVenueService.cs" company="EPAM Systems">
// Copyright (c) EPAM Systems. All rights reserved.
// Author Dzianis Shcharbakou.
// </copyright>
// ****************************************************************************

using System.Collections.Generic;
using TicketManagement.BLL.DTO;

namespace TicketManagement.BLL.Interfaces
{
    internal interface IVenueService
    {
        IEnumerable<VenueDto> GetVenues();

        VenueDto GetVenue(int id);

        int AddVenue(VenueDto entity);

        void UpdateVenue(VenueDto entity);

        void DeleteVenue(int id);
    }
}
