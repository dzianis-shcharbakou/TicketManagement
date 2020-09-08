// ****************************************************************************
// <copyright file="SeatService.cs" company="EPAM Systems">
// Copyright (c) EPAM Systems. All rights reserved.
// Author Dzianis Shcharbakou.
// </copyright>
// ****************************************************************************

using System;
using System.Collections.Generic;
using AutoMapper;
using TicketManagement.BLL.DTO;
using TicketManagement.BLL.Interfaces;
using TicketManagement.BLL.ServiceValidators.Interfaces;
using TicketManagement.DAL.Models;
using TicketManagement.DAL.Repositories.Base;

namespace TicketManagement.BLL.Services
{
    internal class SeatService : ISeatService
    {
        private readonly IRepository<Area> areaRepository;

        private readonly IRepository<Seat> seatRepository;

        private readonly IMapper mapper;
        private readonly ISeatValidator seatValidator;

        public SeatService(
            IRepository<Seat> seatRepository,
            IRepository<Area> areaRepository,
            IMapper mapper,
            ISeatValidator seatValidator)
        {
            this.seatRepository = seatRepository;
            this.areaRepository = areaRepository;
            this.mapper = mapper;
            this.seatValidator = seatValidator;
        }

        public int AddSeat(SeatDto seatDto)
        {
            Area area = this.areaRepository.GetById(seatDto.AreaId);

            this.seatValidator.QueryResultValidate<Area>(area, seatDto.AreaId);

            this.seatValidator.IsSeatExist(seatDto.AreaId, seatDto.Row, seatDto.Number);

            Seat seat = this.mapper.Map<Seat>(seatDto);

            return Convert.ToInt32(this.seatRepository.Create(seat));
        }

        public void UpdateSeat(SeatDto seatDto)
        {
            Seat seat = this.seatRepository.GetById(seatDto.Id);

            this.seatValidator.QueryResultValidate<Seat>(seat, seatDto.Id);

            Area area = this.areaRepository.GetById(seatDto.AreaId);

            this.seatValidator.QueryResultValidate<Area>(area, seatDto.AreaId);

            this.seatValidator.IsSeatExist(seatDto.AreaId, seatDto.Row, seatDto.Number);

            seat = this.mapper.Map<Seat>(seatDto);

            var result = this.seatRepository.Update(seat);
        }

        public void DeleteSeat(int id)
        {
            var result = this.seatRepository.Delete(id);

            this.seatValidator.CUDResultValidate<Seat>(result, id);
        }

        public SeatDto GetSeat(int id)
        {
            Seat seat = this.seatRepository.GetById(id);

            this.seatValidator.QueryResultValidate<Seat>(seat, id);

            return this.mapper.Map<Seat, SeatDto>(seat);
        }

        public IEnumerable<SeatDto> GetSeats()
        {
            var result = this.seatRepository.GetAll();
            return this.mapper.Map<IEnumerable<Seat>, IEnumerable<SeatDto>>(result);
        }
    }
}
