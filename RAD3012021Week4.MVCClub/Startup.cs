﻿using ActivityTracker;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RAD3012021Week4.MVCClub.Startup))]
namespace RAD3012021Week4.MVCClub
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            Activity.Track("Starting week 4 lab");
            ConfigureAuth(app);
        }
    }
}
