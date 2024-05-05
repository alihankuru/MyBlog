using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;
using MyBlog.EntityLayer.Concrete;

namespace MyBlog.PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Tag")]
    public class TagController : Controller
    {
        private readonly ITagService _tagService;

        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }

        [Route("Index")]
        public IActionResult Index()
        {
            var values = _tagService.TGetListAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateTag()
        {

            return View();
        }


        [HttpPost]
        public IActionResult CreateTag(Tag tag)
        {
            _tagService.TInsert(tag);
            return RedirectToAction("Index", "tag");
        }
    }
}
