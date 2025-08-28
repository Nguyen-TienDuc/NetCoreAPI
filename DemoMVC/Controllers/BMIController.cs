using Microsoft.AspNetCore.Mvc;

namespace DemoMVC.Controllers
{
    public class BMIController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(double weight, double height)
        {
            double bmi = weight / (height * height);
            string status = "";

            if (bmi < 18.5) status = "Gầy";
            else if (bmi < 24.9) status = "Bình thường";
            else if (bmi < 29.9) status = "Thừa cân";
            else status = "Béo phì";

            ViewBag.BMI = bmi;
            ViewBag.Status = status;

            return View();
        }
    }
}
