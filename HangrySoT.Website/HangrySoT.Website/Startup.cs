﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HangrySoT.Website.Startup))]
namespace HangrySoT.Website
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
