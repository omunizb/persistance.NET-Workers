using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Workers.Models;

namespace Workers.Controllers
{
    public class EmployeesController : Controller
    {
        public IActionResult Index()
        {
            EmployeeContext context = HttpContext.RequestServices.GetService(typeof(Workers.Models.EmployeeContext)) as EmployeeContext;

            return View(context.GetAllEmployees());
        }
    }
}
