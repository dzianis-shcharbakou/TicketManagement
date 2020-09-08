// ****************************************************************************
// <copyright file="IEventAreaService.cs" company="EPAM Systems">
// Copyright (c) EPAM Systems. All rights reserved.
// Author Dzianis Shcharbakou.
// </copyright>
// ****************************************************************************

using System.Collections.Generic;
using TicketManagement.BLL.DTO;

namespace TicketManagement.BLL.Interfaces
{
    internal interface IEventAreaService
    {
        IEnumerable<EventAreaDto> GetEventAreas();

        EventAreaDto GetEventArea(int id);

        void UpdateEventArea(EventAreaDto entity);
    }
}
