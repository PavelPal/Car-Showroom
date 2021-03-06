﻿using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using CarShowroom.Binders;
using CarShowroom.Domain;

namespace CarShowroom
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            //Database.SetInitializer(new ApplicationDbInitializer());
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ModelBinders.Binders.Add(typeof(Cart), new CartModelBinder());
        }
    }
}