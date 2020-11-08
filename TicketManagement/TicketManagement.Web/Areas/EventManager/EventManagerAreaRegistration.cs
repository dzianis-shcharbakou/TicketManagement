﻿using System.Web.Mvc;

namespace TicketManagement.Web.Areas.EventManager
{
    public class EventManagerAreaRegistration : AreaRegistration
    {
        public override string AreaName => "EventManager";

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "EventManager_default",
                "EventManager/{controller}/{action}/{id}",
                new { area =string.Empty, action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}