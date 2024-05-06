using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;

namespace MyBlog.PresentationLayer.Controllers
{
    public class BlogController : Controller
    {
        private readonly IArticleService _articleService;

        public BlogController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public IActionResult BlogDetail(int id)
        {
           
            ViewBag.i = id;
            var values = _articleService.TGetById(id);

            ViewBag.createdDate = values.CreatedDate;
            ViewBag.title=values.Title;
            ViewBag.CoverImage = values.CoverImageUrl;
           

            var values2 = _articleService.TGetArticlesWithCategoryByArticleId(id);
            ViewBag.categoryName = values2.Category.CategoryName;
            @ViewBag.detail=values.Detail;

            ViewBag.author=values2.AppUser.Name;
            ViewBag.authorr = values2.AppUser.Surname;
            ViewBag.image = values2.AppUser.ImageUrl;
            ViewBag.about = values2.AppUser.About;

            return View();
        }

      
    }
}
