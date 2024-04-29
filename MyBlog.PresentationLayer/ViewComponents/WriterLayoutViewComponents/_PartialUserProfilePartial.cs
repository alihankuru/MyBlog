using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlog.EntityLayer.Concrete;

namespace MyBlog.PresentationLayer.ViewComponents.WriterLayoutViewComponents
{
    public class _PartialUserProfilePartial:ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public _PartialUserProfilePartial(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var userInfo = await _userManager.FindByNameAsync(User.Identity.Name);

            ViewBag.id = userInfo.Id;
            ViewBag.name = userInfo.Name;
            ViewBag.surname = userInfo.Surname;
            ViewBag.image = userInfo.ImageUrl;

            return View(userInfo);
        }


    }
}
