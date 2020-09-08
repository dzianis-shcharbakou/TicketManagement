// ****************************************************************************
// <copyright file="IAreaService.cs" company="EPAM Systems">
// Copyright (c) EPAM Systems. All rights reserved.
// Author Dzianis Shcharbakou.
// </copyright>
// ****************************************************************************

using System.Collections.Generic;
using TicketManagement.BLL.DTO;

namespace TicketManagement.BLL.Interfaces
{
    internal interface IAreaService
    {
        IEnumerable<AreaDto> GetAreas();

        AreaDto GetArea(int id);

        int AddArea(AreaDto entity);

        void UpdateArea(AreaDto entity);

        void DeleteArea(int id);
    }
}
