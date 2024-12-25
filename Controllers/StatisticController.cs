using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyPortfolio.Models;

namespace MyPortfolio.Controllers
{
    public class StatisticController : Controller
    {
        MyPortfolioDbEntities db = new MyPortfolioDbEntities();

        public ActionResult Index()
        {
            ViewBag.totalProjectCount = db.Project.Count();
            ViewBag.totalTestimonialCount = db.Testimonial.Count();
            ViewBag.sumWorkDay = db.Project.Sum(x => x.ComplateDay);
            ViewBag.AvgWorkDay = db.Project.Average(x => x.ComplateDay);
            ViewBag.AvgPrice = db.Project.Average(x => x.Price);

            var value = db.Project.Max(x => x.Price); // En yüksek fiyatı al
            ViewBag.MaxPriceProjectTitle = db.Project.Where(x => x.Price == value) // En yüksek fiyata sahip projeyi bul
                                                     .Select(y => y.Title)         // Sadece başlığı seç
                                                     .FirstOrDefault();            // İlk eşleşeni al

            var value2 = db.Category.Where(x=>x.CategoryName=="AspNet Core Web Geliştirme").Select(y => y.CategoryID).FirstOrDefault();
            ViewBag.CategoryCountByName = db.Project.Where(x => x.ProjectCategory == value2).Count();
            return View();

            
        }
    }
}