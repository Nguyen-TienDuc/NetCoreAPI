using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DemoMVC.Models;

namespace DemoMVC.Controllers
{
    public class EmployeeController : Controller
    {
                public IActionResult Index()
        {
            return View();
        }
        [HttpPost] [HttpPost]
        public IActionResult Index(Employee em)
        {
            if (ModelState.IsValid)
            {
                string strOutput = $"Xin chào {em.FullName} (PersonId: {em.PersonId})" +
                                   $" - EmployeeId: {em.EmployeeId}" +
                                   $" - Tuổi: {em.Age}" +
                                   $" - Địa chỉ: {em.Address}";
                ViewBag.ThongTin = strOutput;
            }
            return View();
        }
        
    }
}