// ****************************************************************************
// <copyright file="EventSeat.cs" company="EPAM Systems">
// Copyright (c) EPAM Systems. All rights reserved.
// Author Dzianis Shcharbakou.
// </copyright>
// ****************************************************************************

using TicketManagement.DAL.Models.Base;

namespace TicketManagement.DAL.Models
{
    public class EventSeat : IEntity
    {
        public int Id { get; set; }

        public int Row { get; set; }

        public int Number { get; set; }

        public int State { get; set; }

        public int EventAreaId { get; set; }
    }
}
