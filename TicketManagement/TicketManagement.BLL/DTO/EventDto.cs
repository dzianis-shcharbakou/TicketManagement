// ****************************************************************************
// <copyright file="EventDto.cs" company="EPAM Systems">
// Copyright (c) EPAM Systems. All rights reserved.
// Author Dzianis Shcharbakou.
// </copyright>
// ****************************************************************************

using System;

namespace TicketManagement.BLL.DTO
{
    public class EventDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime BeginDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Description { get; set; }

        public int LayoutId { get; set; }
    }
}
