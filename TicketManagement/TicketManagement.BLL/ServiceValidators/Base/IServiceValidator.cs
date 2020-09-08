// ****************************************************************************
// <copyright file="IServiceValidator.cs" company="EPAM Systems">
// Copyright (c) EPAM Systems. All rights reserved.
// Author Dzianis Shcharbakou.
// </copyright>
// ****************************************************************************

using TicketManagement.DAL.Models.Base;

namespace TicketManagement.BLL.ServiceValidators.Base
{
    public interface IServiceValidator
    {
        void QueryResultValidate<T>(T result, int id)
            where T : IEntity;

        void CUDResultValidate<T>(object result, int id)
            where T : IEntity;
    }
}
