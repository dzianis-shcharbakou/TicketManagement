// ****************************************************************************
// <copyright file="TicketManagementException.cs" company="EPAM Systems">
// Copyright (c) EPAM Systems. All rights reserved.
// Author Dzianis Shcharbakou.
// </copyright>
// ****************************************************************************

using System;

namespace TicketManagement.BLL.Util
{
    public class TicketManagementException : Exception
    {
        public TicketManagementException(string message, string prop)
            : base(message)
        {
            this.Property = prop;
            this.Source = prop;
        }

        public string Property { get; protected set; }
    }
}
