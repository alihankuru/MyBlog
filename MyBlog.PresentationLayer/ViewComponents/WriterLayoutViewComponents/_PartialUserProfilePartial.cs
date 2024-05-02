using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyBlog.DataAccessLayer.Context;
using MyBlog.EntityLayer.Concrete;

namespace MyBlog.PresentationLayer.ViewComponents.WriterLayoutViewComponents
{
    public class _PartialUserProfilePartial:ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly BlogContext _context;

        public _PartialUserProfilePartial(UserManager<AppUser> userManager, BlogContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var userInfo = await _userManager.FindByNameAsync(User.Identity.Name);

            ViewBag.id = userInfo.Id;
            ViewBag.name = userInfo.Name;
            ViewBag.surname = userInfo.Surname;
            ViewBag.image = userInfo.ImageUrl;
         
                
            var blogCount = _context.Articles.Count(b => b.AppUserId == userInfo.Id);
            ViewBag.blogCount = blogCount;

            return View(userInfo);
        }


    }
}
