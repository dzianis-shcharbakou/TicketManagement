// ****************************************************************************
// <copyright file="SeatValidator.cs" company="EPAM Systems">
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
    internal class SeatValidator : ValidatorBase, ISeatValidator
    {
        private const string ShouldBeUniqueRowAndNumber = "ShouldBeUniqueRowAndNumber";

        private readonly Dictionary<string, string> exceptionMessagies;

        private readonly IRepository<Seat> seatRepository;

        public SeatValidator(IRepository<Seat> seatRepository)
        {
            this.exceptionMessagies = new Dictionary<string, string>();
            this.exceptionMessagies.Add(ShouldBeUniqueRowAndNumber, "row and number of seat should be unique for area");

            this.seatRepository = seatRepository;
        }

        public void IsSeatExist(int areaId, int row, int number)
        {
            if (this.IsSeatWithRowAndNumber(areaId, row, number))
            {
                throw new TicketManagementException(this.exceptionMessagies.First(x => x.Key == ShouldBeUniqueRowAndNumber).Value, ShouldBeUniqueRowAndNumber);
            }
        }

        private bool IsSeatWithRowAndNumber(int areaId, int row, int number)
        {
            var seatQuery = this.seatRepository.GetAll()
                .Where(x => x.AreaId == areaId && x.Row == row && x.Number == number);

            return seatQuery.Any();
        }
    }
}
