// ****************************************************************************
// <copyright file="IEventValidator.cs" company="EPAM Systems">
// Copyright (c) EPAM Systems. All rights reserved.
// Author Dzianis Shcharbakou.
// </copyright>
// ****************************************************************************

using System.Collections.Generic;
using TicketManagement.BLL.DTO;
using TicketManagement.BLL.ServiceValidators.Base;

namespace TicketManagement.BLL.ServiceValidators.Interfaces
{
    public interface IEventValidator : IServiceValidator
    {
        void SoldTicketExist(int eventId);

        void ExistAreaForEvent(IEnumerable<AreaDto> area);

        void ExistSeatForEvent(IEnumerable<SeatDto> area);

        void IsValidEventDates(EventDto eventDto);

        void IsAnyTicketSold(int eventId);
    }
}
