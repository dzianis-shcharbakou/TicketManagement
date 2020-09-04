﻿// ****************************************************************************
// <copyright file="ILayoutService.cs" company="EPAM Systems">
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
    internal interface ILayoutService
    {
        IEnumerable<LayoutDto> GetLayouts();

        LayoutDto GetLayout(int id);

        int AddLayout(LayoutDto entity);

        void UpdateLayout(LayoutDto entity);

        void DeleteLayout(int id);
    }
}
