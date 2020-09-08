// ****************************************************************************
// <copyright file="ILayoutValidator.cs" company="EPAM Systems">
// Copyright (c) EPAM Systems. All rights reserved.
// Author Dzianis Shcharbakou.
// </copyright>
// ****************************************************************************

using TicketManagement.BLL.ServiceValidators.Base;

namespace TicketManagement.BLL.ServiceValidators.Interfaces
{
    public interface ILayoutValidator : IServiceValidator
    {
        void IsUniqLayoutNameInTheVenue(string nameLayout, int venueId);
    }
}
