using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyPortfolio.Models;
namespace MyPortfolio.Controllers
{
    public class ProjectController : Controller
    {
     MyPortfolioDbEntities db = new MyPortfolioDbEntities();
        public ActionResult Index()
        {
            var values=db.Project.ToList();
            return View(values);
        }
    }
}