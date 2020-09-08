// ****************************************************************************
// <copyright file="IAreaValidator.cs" company="EPAM Systems">
// Copyright (c) EPAM Systems. All rights reserved.
// Author Dzianis Shcharbakou.
// </copyright>
// ****************************************************************************

using TicketManagement.BLL.ServiceValidators.Base;

namespace TicketManagement.BLL.ServiceValidators.Interfaces
{
    public interface IAreaValidator : IServiceValidator
    {
        void IsUniqAreaNameInTheLayout(string nameArea, int layoutId);
    }
}
