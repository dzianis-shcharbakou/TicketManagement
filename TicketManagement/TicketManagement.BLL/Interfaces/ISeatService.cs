// ****************************************************************************
// <copyright file="ISeatService.cs" company="EPAM Systems">
// Copyright (c) EPAM Systems. All rights reserved.
// Author Dzianis Shcharbakou.
// </copyright>
// ****************************************************************************

using System.Collections.Generic;
using TicketManagement.BLL.DTO;

namespace TicketManagement.BLL.Interfaces
{
    internal interface ISeatService
    {
        IEnumerable<SeatDto> GetSeats();

        SeatDto GetSeat(int id);

        int AddSeat(SeatDto entity);

        void UpdateSeat(SeatDto entity);

        void DeleteSeat(int id);
    }
}
