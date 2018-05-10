using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.AppIdentityUser;

namespace WebApplication1.AppIdentityUser
{
    public class AppUser : IdentityUser, IUser<string>
    {

    }

    public static class AppUserContext
    {
        public static List<AppUser> AppUserList { get; set; }
        static AppUserContext()
        {
            AppUserList = new List<AppUser>();
        }
        public static bool Add(AppUser user)
        {
            AppUserList.Add(user);
            return true;
        }
    }

    public class AppUserStore : IUserStore<AppUser>, IUserPasswordStore<AppUser>
    {
        public Task CreateAsync(AppUser user)
        {
            var added = AppUserContext.Add(user);
            var listUser = AppUserContext.AppUserList;

            return Task.FromResult(added);
        }

        public Task DeleteAsync(AppUser user)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<AppUser> FindByIdAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<AppUser> FindByNameAsync(string userName)
        {
            var user = AppUserContext.AppUserList.FirstOrDefault(u => u.UserName == userName);
            return Task.FromResult<AppUser>(user);
            //throw new NotImplementedException();
        }

        public Task<string> GetPasswordHashAsync(AppUser user)
        {
            //should hash the password that entered by user
            //then get password hash from db and then compare 2 password
            var dbUser = AppUserContext.AppUserList.FirstOrDefault(u => u.UserName == user.UserName);
            var passwordHash = dbUser.PasswordHash;
            return Task.FromResult(passwordHash);
        }

        public Task<bool> HasPasswordAsync(AppUser user)
        {
            throw new NotImplementedException();
        }

        public Task SetPasswordHashAsync(AppUser user, string passwordHash)
        {
            return Task.FromResult<string>(user.PasswordHash = passwordHash);
            //throw new NotImplementedException();
        }

        public Task UpdateAsync(AppUser user)
        {
            throw new NotImplementedException();
        }
    }

    public class AppUserManager : UserManager<AppUser>
    {
        public AppUserManager(IUserStore<AppUser> store) : base(store)
        {

        }
    }
}

namespace WebApplication1.Controllers
{
    public class AccountController : Controller
    {
        private AppUserManager _appUserManager { get; set; }

        public AccountController() : this(new AppUserManager(new AppUserStore())) { }

        public AccountController(AppUserManager appUserManager)
        {
            _appUserManager = appUserManager;
        }

        public async Task<ActionResult> Login()
        {
            //var userStore = new AppUserStore();
            //var userManager = new UserManager<AppUser>(userStore);

            //var user = new AppUser { UserName = "linh3" };
            //var result = await userManager.CreateAsync(user, "123456");

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(IdentityUser model)
        {
            //var userStore = new UserStore<IdentityUser>();
            //var userManager = new UserManager<IdentityUser>(userStore);
            //var user = userManager.Find(model.UserName, "123456");
            //if (user != null)
            //{
            //    //var authenticationManager1 = HttpContext.Current.GetOwinContext().Authentication;
            //    var context = HttpContext.GetOwinContext();
            //    var authenticationManager = context.Authentication;
            //    var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
            //    authenticationManager.SignIn(new AuthenticationProperties { IsPersistent = true }, userIdentity);
            //    return RedirectToAction("Index", "Home");
            //}
            string password = "123456";
            var user = _appUserManager.FindAsync(model.UserName, password);
            if (user.Result != null)
            {
                var context = HttpContext.GetOwinContext();
                var authenticationManager = context.Authentication;
                var userIdentity = _appUserManager.CreateIdentity(user.Result, DefaultAuthenticationTypes.ApplicationCookie);
                authenticationManager.SignIn(new AuthenticationProperties { IsPersistent = true }, userIdentity);
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        public ActionResult Logout()

        {
            var context = HttpContext.GetOwinContext();
            var authenticationManager = context.Authentication;
            authenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            //get user from database


            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> Register(IdentityUser model)
        {
            //var userStore = new UserStore<IdentityUser>();
            //var userManager = new UserManager<IdentityUser>(userStore);

            //var identityUser = new IdentityUser(model.UserName);
            //var result = _usre userManager.Create(identityUser, "123456");

            //_appUserManager.Create<AppUser>(identityUser, "");

            var appUser = new AppUser { UserName = model.UserName };
            var result = await _appUserManager.CreateAsync(appUser, "123456");

            return View(model);
        }
    }
}