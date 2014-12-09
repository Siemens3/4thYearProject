using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AzureCal.Models;
namespace AzureCal.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Azure()
        {
            return View();
         
        }

        public ActionResult Confirm(AzureServiceModel Az)
        {
            if(ModelState.IsValid)
            {
               return RedirectToAction("Confirm", Az);
            }
            else
            {
                return View();

            }
        
        }

        public ActionResult Confirm()
        {
            return View();
        }
    }
}