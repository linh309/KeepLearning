using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.App_Start
{
    public class CustomViewEngine : RazorViewEngine
    {
        public CustomViewEngine()
        {
            var viewLocations = new string[] 
            {
                "~/Views/Pages/{1}/{0}.cshtml"
            };

            this.ViewLocationFormats = new string[]
            {
                "~/Views/Pages/{1}/{0}.cshtml"
            };
        }
    }
}