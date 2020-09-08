// ****************************************************************************
// <copyright file="ValidatorBase.cs" company="EPAM Systems">
// Copyright (c) EPAM Systems. All rights reserved.
// Author Dzianis Shcharbakou.
// </copyright>
// ****************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using TicketManagement.BLL.Util;
using TicketManagement.DAL.Models.Base;

namespace TicketManagement.BLL.ServiceValidators.Base
{
    internal abstract class ValidatorBase : IServiceValidator
    {
        private const string NotFound = "NotFound";
        private const string ConcreteNotFound = "ConcreteNotFound";

        private readonly Dictionary<string, string> exceptionMessagies;

        public ValidatorBase()
        {
            this.exceptionMessagies = new Dictionary<string, string>
            {
                { NotFound, "{0} not found" },
                { ConcreteNotFound, "{0} with id={1} not found" },
            };
        }

        public void QueryResultValidate<T>(T result, int id)
            where T : IEntity
        {
            if (this.IsNull(result))
            {
                throw new TicketManagementException(
                    string.Format(
                        this.exceptionMessagies.First(x => x.Key == ConcreteNotFound).Value,
                        typeof(T).Name,
                        id), NotFound);
            }
        }

        public void CUDResultValidate<T>(object result, int id)
            where T : IEntity
        {
            if (Convert.ToInt32(result) == 0)
            {
                throw new TicketManagementException(
                   string.Format(
                       this.exceptionMessagies.First(x => x.Key == ConcreteNotFound).Value,
                       typeof(T).Name,
                       id), NotFound);
            }
        }

        private bool IsNull(object entity)
        {
            return entity == null;
        }
    }
}
