﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReptileManager.Models;
using System.Threading.Tasks;

namespace ReptileManager.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
           
            ViewBag.Message = "Your application description page.";
            

            return View();
        }
        [Authorize]
        public ActionResult Contact()
        {
           ViewBag.Message = "Reptile Manager.";

            return View();
        }
        [Authorize]
        public ActionResult Chat()
        {
            return View();
        }
        
    }
}