﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicketManagement.Web.WcfInfrastructure
{
    public static class CredentialsContainer
    {
        public static string UserName { get; set; }

        public static string Password { get; set; }

        public static string Token { get; set; }
    }
}