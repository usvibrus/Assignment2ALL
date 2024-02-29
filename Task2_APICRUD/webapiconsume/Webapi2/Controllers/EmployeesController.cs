using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Webapi2.Controllers
{
    public class EmployeesController : Controller
    {

        Uri baseAddress = new Uri("https://localhost:65432/api");
        HttpClient client;
        // GET: Employees
        public ActionResult Index()
        {
            return View();
        }
    }
}