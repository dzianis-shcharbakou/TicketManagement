// ****************************************************************************
// <copyright file="Venue.cs" company="EPAM Systems">
// Copyright (c) EPAM Systems. All rights reserved.
// Author Dzianis Shcharbakou.
// </copyright>
// ****************************************************************************

using TicketManagement.DAL.Models.Base;

namespace TicketManagement.DAL.Models
{
    public class Venue : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }
    }
}
