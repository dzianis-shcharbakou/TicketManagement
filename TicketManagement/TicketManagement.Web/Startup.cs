﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(TicketManagement.Web.Startup))]
namespace TicketManagement.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}