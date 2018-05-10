using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class HomeViewModel : BaseViewModel
    {
        public string AccessTime { get; set; }
        public string UserName { get; set; }
        public bool IsAuthenticated { get; set; }
    }
}