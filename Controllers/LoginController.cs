using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MyPortfolio.Controllers
{
    public class LoginController : Controller
    {
        MyPortfolioDbEntities db = new MyPortfolioDbEntities();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            var values = db.Admin.FirstOrDefault(x => x.Username == admin.Username && x.Password == admin.Password);
            if (values != null)
            {
                FormsAuthentication.SetAuthCookie(values.Username,false);
                Session["username"] = values.Username.ToString();
                return RedirectToAction("Index", "Service");
            }
            return View();
        }
    }

}
