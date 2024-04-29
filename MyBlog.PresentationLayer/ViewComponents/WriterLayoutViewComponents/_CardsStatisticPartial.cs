using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlog.DataAccessLayer.Context;
using MyBlog.EntityLayer.Concrete;
using System.Linq;

namespace MyBlog.PresentationLayer.ViewComponents.WriterLayoutViewComponents
{
    public class _CardsStatisticPartial : ViewComponent
    {
       

        private readonly UserManager<AppUser> _userManager;
        private readonly BlogContext _context;

        public _CardsStatisticPartial(UserManager<AppUser> userManager, BlogContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            var articleCount = _context.Articles.Count(a => a.AppUserId == user.Id);
            var commentCount = _context.Comments.Where(comment=>comment.Article.AppUserId == user.Id).Count();
            var categoryCount = _context.Categories.Count();
            var socialMediaCount = _context.SocialMedias.Count();


            ViewBag.ArticleCount = articleCount;
            ViewBag.CommentCount = commentCount;
            ViewBag.CategoryCount = categoryCount;
            ViewBag.SocialMediaCount = socialMediaCount;


            return View();
        }
    }
}
