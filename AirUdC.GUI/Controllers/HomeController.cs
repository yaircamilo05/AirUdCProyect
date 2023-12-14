﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirUdC.GUI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Manager() {

            ViewBag.Message = "hola";
            return View();
        }

        public ActionResult Parameters()
        {
            ViewBag.Message = "hola";
            return View();
        }

        public ActionResult Reports()
        {
            ViewBag.Message = "hola";
            return View();
        }
    }
}