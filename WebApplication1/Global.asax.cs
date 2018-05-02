﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebApplication1.App_Start;

namespace WebApplication1
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //var razorViewEgine = ViewEngines.Engines.OfType<RazorViewEngine>().FirstOrDefault();
            //razorViewEgine.ViewLocationFormats = new string[]
            //{
            //    "~/Views/Pages/{1}/{0}.cshtml"
            //};

            var viewEngines = ViewEngines.Engines;
            viewEngines.Add(new CustomViewEngine());

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
