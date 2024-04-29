using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlog.EntityLayer.Concrete;

namespace MyBlog.PresentationLayer.Areas.Writer.Controllers
{
    public class WriterLayoutController : Controller
    {

        private readonly UserManager<AppUser> _userManager;

        public WriterLayoutController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }


        [Area("Writer")]
        public IActionResult Index()
        {
            return View();
        }

        public async Task<PartialViewResult> PartialUserProfile()
        {
            var userInfo =  await _userManager.FindByNameAsync(User.Identity.Name);

            ViewBag.id = userInfo.Id;
            ViewBag.name = userInfo.Name;
            ViewBag.surname = userInfo.Surname;
            ViewBag.image = userInfo.ImageUrl;

            return PartialView();
        }


    }
}
