using Microsoft.AspNetCore.Mvc;

namespace JobRecruitmentApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
