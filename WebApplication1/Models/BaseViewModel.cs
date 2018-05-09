using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class BaseViewModel
    {
        public string Controller { get; set; }
        public string Action { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}