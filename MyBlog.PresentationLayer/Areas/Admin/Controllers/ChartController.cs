using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;
using MyBlog.DataAccessLayer.Context;
using MyBlog.PresentationLayer.Areas.Admin.Models;

namespace MyBlog.PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Chart")]
    public class ChartController : Controller
    {
        private readonly ICategoryService _categoryService;
        BlogContext _context;

        public ChartController(ICategoryService categoryService, BlogContext context)
        {
            _categoryService = categoryService;
            _context = context;
        }

        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("CategoryChart")]
        public IActionResult CategoryChart()
        {
            var values = _context.Articles.GroupBy(x => x.CategoryId).Select(y => new ChartViewModel
            {
                categoryname = _context.Categories.Where(x => x.CategoryId == y.Key).Select(z => z.CategoryName).FirstOrDefault(),
                count = y.Count(),
            }).ToList();

            return Json(new { jsonlist = values });

        }

    }
}
