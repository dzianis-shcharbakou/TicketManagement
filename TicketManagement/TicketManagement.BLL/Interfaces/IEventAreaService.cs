﻿// ****************************************************************************
// <copyright file="IEventAreaService.cs" company="EPAM Systems">
// Copyright (c) EPAM Systems. All rights reserved.
// Author Dzianis Shcharbakou.
// </copyright>
// ****************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
