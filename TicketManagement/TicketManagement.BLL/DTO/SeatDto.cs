// ****************************************************************************
// <copyright file="SeatDto.cs" company="EPAM Systems">
// Copyright (c) EPAM Systems. All rights reserved.
// Author Dzianis Shcharbakou.
// </copyright>
// ****************************************************************************

namespace TicketManagement.BLL.DTO
{
    public class SeatDto
    {
        public int Id { get; set; }

        public int Row { get; set; }

        public int Number { get; set; }

        public int AreaId { get; set; }
    }
}
