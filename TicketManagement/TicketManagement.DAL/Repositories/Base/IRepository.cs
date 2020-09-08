// ****************************************************************************
// <copyright file="IRepository.cs" company="EPAM Systems">
// Copyright (c) EPAM Systems. All rights reserved.
// Author Dzianis Shcharbakou.
// </copyright>
// ****************************************************************************

using System.Collections.Generic;

namespace TicketManagement.DAL.Repositories.Base
{
    public interface IRepository<T>
    {
        object Create(T entity);

        object Update(T entity);

        object Delete(int id);

        T GetById(int id);

        IEnumerable<T> GetAll();
    }
}
