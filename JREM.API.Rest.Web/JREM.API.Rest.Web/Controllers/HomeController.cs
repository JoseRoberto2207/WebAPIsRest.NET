using JREM.API.Rest.Core;
using JREM.API.Rest.Logic;
using JREM.API.Rest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JREM.API.Rest.Web.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public string GetEmpDetails()
        {
            return "Vithal Wadje";

        }
        public ActionResult Index()
        {
            try
            {
                var logicEngine = new LogicEngine();
                var logic = (List<Product>)logicEngine.GetProducts().Result;

                ViewBag.Products = logic;
                ViewBag.TotalProducts = logic.Count();
            }
            catch (Exception ex)
            {
                throw;
            }
            return View();
        }
    }
}
