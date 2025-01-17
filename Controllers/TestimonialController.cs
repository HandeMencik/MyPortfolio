﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyPortfolio.Models;

namespace MyPortfolio.Controllers
{
    public class TestimonialController : Controller
    {
        MyPortfolioDbEntities db = new MyPortfolioDbEntities();

        public ActionResult Index()
        {
            var values=db.Testimonial.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddTestimonial()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddTestimonial(Testimonial testimonial)
        {
            db.Testimonial.Add(testimonial);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteTestimonial(int id)
        {
            var value=db.Testimonial.Find(id);
            db.Testimonial.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateTestimonial(int id)
        {
            var value=db.Testimonial.Find(id);
            return View(value);

        }
        [HttpPost]  
        public ActionResult UpdateTestimonial(Testimonial testimonial)
        {
            var value = db.Testimonial.Find(testimonial.TestimonialID);
            value.NameSurname = testimonial.NameSurname;
            value.Title=testimonial.Title;
            value.ImageUrl= testimonial.ImageUrl;
            value.Commend= testimonial.Commend;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}