// ****************************************************************************
// <copyright file="IVenueValidator.cs" company="EPAM Systems">
// Copyright (c) EPAM Systems. All rights reserved.
// Author Dzianis Shcharbakou.
// </copyright>
// ****************************************************************************

using TicketManagement.BLL.ServiceValidators.Base;

namespace TicketManagement.BLL.ServiceValidators.Interfaces
{
    public interface IVenueValidator : IServiceValidator
    {
        void IsVenueNameExist(string name);
    }
}
