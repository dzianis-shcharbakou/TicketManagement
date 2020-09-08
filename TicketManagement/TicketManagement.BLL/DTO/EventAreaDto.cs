// ****************************************************************************
// <copyright file="EventAreaDto.cs" company="EPAM Systems">
// Copyright (c) EPAM Systems. All rights reserved.
// Author Dzianis Shcharbakou.
// </copyright>
// ****************************************************************************

namespace TicketManagement.BLL.DTO
{
    public class EventAreaDto
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public int CoordX { get; set; }

        public int CoordY { get; set; }

        public decimal Price { get; set; }

        public int EventId { get; set; }
    }
}
