﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FamilyPlanner.Controllers
{
    public class WeatherController : Controller
    {
        // GET: Weather
        public ActionResult Index()
        {

            return View();
        }
    }
}