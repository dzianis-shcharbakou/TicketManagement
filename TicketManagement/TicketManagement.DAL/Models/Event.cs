// ****************************************************************************
// <copyright file="Event.cs" company="EPAM Systems">
// Copyright (c) EPAM Systems. All rights reserved.
// Author Dzianis Shcharbakou.
// </copyright>
// ****************************************************************************

using System;
using TicketManagement.DAL.Models.Base;

namespace TicketManagement.DAL.Models
{
    public class Event : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime BeginDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Description { get; set; }

        public int LayoutId { get; set; }
    }
}
