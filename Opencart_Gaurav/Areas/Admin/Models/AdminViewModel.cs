using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Opencart_Gaurav.Areas.Admin.Models
{
    public class AdminViewModel
    {
        public string name { get; set; }

        public string password { get; set; }

        public int Aid { get; set; }
        public  bool RememberMe { get; set; }
    }
}
