// ****************************************************************************
// <copyright file="AreaValidator.cs" company="EPAM Systems">
// Copyright (c) EPAM Systems. All rights reserved.
// Author Dzianis Shcharbakou.
// </copyright>
// ****************************************************************************

using System.Collections.Generic;
using System.Linq;
using TicketManagement.BLL.ServiceValidators.Base;
using TicketManagement.BLL.ServiceValidators.Interfaces;
using TicketManagement.BLL.Util;
using TicketManagement.DAL.Models;
using TicketManagement.DAL.Repositories.Base;

namespace TicketManagement.BLL.ServiceValidators
{
    internal class AreaValidator : ValidatorBase, IAreaValidator
    {
        private const string ExistAreaWithDescription = "ExistAreaWithDescription";

        private readonly Dictionary<string, string> exceptionMessagies;

        private readonly IRepository<Area> areaRepository;

        public AreaValidator(IRepository<Area> areaRepository)
        {
            this.exceptionMessagies = new Dictionary<string, string>();
            this.exceptionMessagies.Add(ExistAreaWithDescription, "there is area with this description in the layout");

            this.areaRepository = areaRepository;
        }

        public void IsUniqAreaNameInTheLayout(string nameArea, int layoutId)
        {
            if (this.IsAreaDescription(nameArea, layoutId))
            {
                throw new TicketManagementException(this.exceptionMessagies.First(x => x.Key == ExistAreaWithDescription).Value, ExistAreaWithDescription);
            }
        }

        private bool IsAreaDescription(string nameArea, int layoutId)
        {
            var areasQuery = this.areaRepository.GetAll().Where(x => x.LayoutId == layoutId && x.Description == nameArea);
            return areasQuery.Any();
        }
    }
}
