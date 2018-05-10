using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var userIdentity = User.Identity;
            var model = new HomeViewModel { AccessTime = DateTime.Now.ToString() };
            var isLogin = false;

            if (userIdentity is WindowsIdentity)
            {
                WindowsIdentity windowsIdentity = userIdentity as WindowsIdentity;
                isLogin = windowsIdentity != null && windowsIdentity.User != null;
            }
            else if (userIdentity is ClaimsIdentity)
            {
                var claimIdentity = userIdentity as ClaimsIdentity;
                isLogin = claimIdentity != null && claimIdentity.IsAuthenticated && !string.IsNullOrEmpty(claimIdentity.Name);
            }

            if (isLogin)
            {
                var userName = userIdentity.Name;
                var isAuthenticated = User.Identity.IsAuthenticated;
                model.UserName = userName;
                model.IsAuthenticated = isAuthenticated;
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}