using Opencart_Gaurav.Areas.Admin.Models;
using Opencart_Gaurav.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Opencart_Gaurav.Areas.Admin.Controllers
{
    public class AdminLoginController : Controller
    {
        Database1Entities1 db = new Database1Entities1();
        // GET: Admin/AdminLogin
        public ActionResult Index()
        {
            return View();
        }
         
        public ActionResult  ALogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ALogin(AdminViewModel adm)
        {
            try
            {
                var login = db.MastersLogins.SingleOrDefault(a => a.AdminName == adm.name && a.Password == adm.password);
                if (login != null)
                {
                    Session["Aid"] = adm.Aid;
                    return RedirectToAction("Index", "Index");
                }

            }
            catch (Exception ex)
            {
                TempData["err"] = ex.Message;
            }
            return View();
        }
    }

}