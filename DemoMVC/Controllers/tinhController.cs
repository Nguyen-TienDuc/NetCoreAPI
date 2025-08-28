using Microsoft.AspNetCore.Mvc;

namespace DemoMVC.Controllers
{
    public class tinhController : Controller
    {
       public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(double a, double b, string operation)
        {
            double result = 0;
            switch (operation)
            {
                case "add": result = a + b; break;
                case "sub": result = a - b; break;
                case "mul": result = a * b; break;
                case "div": result = b != 0 ? a / b : 0; break;
            }
            ViewBag.ketqua = result;
            return View();
        }
    }
}
