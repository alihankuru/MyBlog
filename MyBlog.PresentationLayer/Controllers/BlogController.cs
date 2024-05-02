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
            id = 1002;
            ViewBag.i = id;
            var values = _articleService.TGetById(id);
            ViewBag.createdDate = values.CreatedDate;
            ViewBag.title=values.Title;
           

            var values2 = _articleService.TGetArticlesWithCategoryByArticleId(id);
            ViewBag.categoryName = values2.Category.CategoryName;
            @ViewBag.detail=values.Detail;

            return View();
        }

      
    }
}
