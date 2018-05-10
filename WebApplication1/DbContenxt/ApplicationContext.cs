using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.DbContenxt
{
    public class ApplicationContext: IdentityDbContext<ApplicationIdentityUser>
    {
        public ApplicationContext() : base("DefaultConnection")
        {

        }
    }
}