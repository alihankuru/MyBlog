using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;
using MyBlog.EntityLayer.Concrete;

namespace MyBlog.PresentationLayer.ViewComponents.WriterLayoutViewComponents
{
    public class _CardsStatistic2Partial : ViewComponent
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly IArticleService _articleService;

        public _CardsStatistic2Partial(UserManager<AppUser> userManager, IArticleService articleService)
        {
            _userManager = userManager;
            _articleService = articleService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = _articleService.TGetArticlesWithCategoryByWriter(user.Id);

            return View(values);
        }

       

    }
}
