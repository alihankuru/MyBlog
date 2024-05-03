using Microsoft.AspNetCore.Mvc;

namespace MyBlog.PresentationLayer.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult Index(int? code)
        {
            return View();
        }

        public IActionResult Index2(int? code)
        {
           
            return View();
        }
    }
}
