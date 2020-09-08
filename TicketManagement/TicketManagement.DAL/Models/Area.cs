// ****************************************************************************
// <copyright file="Area.cs" company="EPAM Systems">
// Copyright (c) EPAM Systems. All rights reserved.
// Author Dzianis Shcharbakou.
// </copyright>
// ****************************************************************************

using TicketManagement.DAL.Models.Base;

namespace TicketManagement.DAL.Models
{
    public class Area : IEntity
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public int CoordX { get; set; }

        public int CoordY { get; set; }

        public int LayoutId { get; set; }
    }
}
