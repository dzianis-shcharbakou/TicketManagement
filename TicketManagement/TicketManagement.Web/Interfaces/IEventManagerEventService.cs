﻿using System.Collections.Generic;
using TicketManagement.Web.Areas.EventManager.Data;
using TicketManagement.Web.Models.Event;
using EventViewModel = TicketManagement.Web.Areas.EventManager.Data.EventViewModel;

namespace TicketManagement.Web.Interfaces
{
    public interface IEventManagerEventService
    {
        List<IndexEventViewModel> GetIndexEventViewModels();
        EventViewModel GetEventViewModel();
        void CreateEvent(EventViewModel eventViewModel);
        EventViewModel GetEventViewModel(int eventId);
        void UpdateEvent(EventViewModel eventViewModel);
        void DeleteEvent(int id);
        void PublishEvent(int id);
        AreaViewModel GetAreaViewModel(int areaId);
        void ChangeCost(AreaViewModel areaVm);
        EventDetailViewModel GetEventDetailViewModel(int eventId);
        EventAreaDetailViewModel GetEventAreaDetailViewModel(int eventAreaId);
    }
}
