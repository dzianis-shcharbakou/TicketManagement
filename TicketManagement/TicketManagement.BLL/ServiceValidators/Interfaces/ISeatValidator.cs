// ****************************************************************************
// <copyright file="ISeatValidator.cs" company="EPAM Systems">
// Copyright (c) EPAM Systems. All rights reserved.
// Author Dzianis Shcharbakou.
// </copyright>
// ****************************************************************************

using TicketManagement.BLL.ServiceValidators.Base;

namespace TicketManagement.BLL.ServiceValidators.Interfaces
{
    public interface ISeatValidator : IServiceValidator
    {
        void IsSeatExist(int areaId, int row, int number);
    }
}
