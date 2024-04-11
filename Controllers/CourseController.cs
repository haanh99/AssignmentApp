using Microsoft.AspNetCore.Mvc;

namespace AssignmentApp.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
