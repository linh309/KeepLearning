using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Config
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            filterContext.Result = new ViewResult { ViewName = "~/Views/Shared/Exception.cshtml" };
            filterContext.ExceptionHandled = true;

            // ( new RedirectResult("~/Shared/Exception.cshtml");
            //var filter = filterContext;
            //throw new NotImplementedException("Custom exception filter -- 1");
        }
    }

    public class CustomResultFilter : IResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
            var viewData = filterContext.Controller.ViewData;
            var viewModel = viewData.Model as BaseViewModel;
            if (viewModel != null)
            {
                viewModel.End = DateTime.Now; 
            }
        }

        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            var viewData = filterContext.Controller.ViewData;
            var viewModel = viewData.Model as BaseViewModel;
            if (viewModel != null)
            {
                //viewModel.Action = filterContext.Controller.ControllerContext.RouteData.Route.
                viewModel.Controller = filterContext.RequestContext.RouteData.Values["controller"].ToString();
                viewModel.Action = filterContext.RequestContext.RouteData.Values["action"].ToString();
                viewModel.Start = DateTime.Now;

            }


            //throw new NotImplementedException();
        }
    }
}