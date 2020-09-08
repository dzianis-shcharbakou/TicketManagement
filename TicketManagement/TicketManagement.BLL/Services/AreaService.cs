// ****************************************************************************
// <copyright file="AreaService.cs" company="EPAM Systems">
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
    public class AreaService : IAreaService
    {
        private readonly IRepository<Area> areaRepository;

        private readonly IRepository<Layout> layoutRepository;

        private readonly IMapper mapper;

        private readonly IAreaValidator areaValidator;

        public AreaService(IRepository<Area> area, IRepository<Layout> layout, IAreaValidator areaValidator, IMapper mapper)
        {
            this.areaRepository = area;
            this.layoutRepository = layout;
            this.mapper = mapper;
            this.areaValidator = areaValidator;
        }

        public int AddArea(AreaDto areaDto)
        {
            Layout layout = this.layoutRepository.GetById(areaDto.LayoutId);
            this.areaValidator.QueryResultValidate<Layout>(layout, areaDto.LayoutId);

            this.areaValidator.IsUniqAreaNameInTheLayout(areaDto.Description, areaDto.LayoutId);

            Area area = this.mapper.Map<Area>(areaDto);
            return Convert.ToInt32(this.areaRepository.Create(area));
        }

        public void UpdateArea(AreaDto areaDto)
        {
            Area area = this.areaRepository.GetById(areaDto.Id);
            this.areaValidator.QueryResultValidate<Area>(area, areaDto.Id);

            Layout layout = this.layoutRepository.GetById(areaDto.LayoutId);
            this.areaValidator.QueryResultValidate<Layout>(layout, areaDto.LayoutId);

            this.areaValidator.IsUniqAreaNameInTheLayout(areaDto.Description, areaDto.LayoutId);

            area = this.mapper.Map<Area>(areaDto);
            this.areaRepository.Update(area);
        }

        public void DeleteArea(int id)
        {
            var result = this.areaRepository.Delete(id);
            this.areaValidator.CUDResultValidate<Area>(result, id);
        }

        public AreaDto GetArea(int id)
        {
            Area area = this.areaRepository.GetById(id);
            this.areaValidator.QueryResultValidate<Area>(area, id);

            return this.mapper.Map<Area, AreaDto>(area);
        }

        public IEnumerable<AreaDto> GetAreas()
        {
            var result = this.areaRepository.GetAll();
            return this.mapper.Map<IEnumerable<Area>, List<AreaDto>>(result);
        }
    }
}
