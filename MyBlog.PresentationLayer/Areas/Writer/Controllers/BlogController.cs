using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyBlog.BusinessLayer.Abstract;
using MyBlog.EntityLayer.Concrete;

namespace MyBlog.PresentationLayer.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Route("Writer/Blog")]
    public class BlogController : Controller
    {
        
        private readonly UserManager<AppUser> _userManager;
        private readonly IArticleService _articleService;
        private readonly ICategoryService _categoryService;
        private readonly ITagService _tagService;
        private readonly IArticleTagService _articletagService;

        public BlogController(UserManager<AppUser> userManager, IArticleService articleService, ICategoryService categoryService, ITagService tagService, IArticleTagService articletagService)
        {
            _userManager = userManager;
            _articleService = articleService;
            _categoryService = categoryService;
            _tagService = tagService;
            _articletagService = articletagService;
        }

        [Route("MyBlogList")]
        public async Task<IActionResult> MyBlogList(string searchString)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = _articleService.TGetArticlesWithCategoryByWriter(user.Id);

            // If a search string is provided, filter the articles
            if (!string.IsNullOrEmpty(searchString))
            {
                values = values.Where(article => article.Title.Contains(searchString)).ToList();
            }

            return View(values);
        }

        [Route("DeleteBlog/{id}")]
        public IActionResult DeleteBlog(int id)
        {
            _articleService.TDelete(id);
            return RedirectToAction("MyBlogList", "Blog", new { area = "Writer" });
        }

        [HttpGet]
        [Route("UpdateBlog/{id}")]
        public IActionResult UpdateBlog(int id)
        {
            List<SelectListItem> valuess = (from x in _categoryService.TGetListAll()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryId.ToString()
                                           }).ToList();

            ViewBag.v = valuess;

            var values = _articleService.TGetById(id);
            return View(values);
        }

        [HttpPost]
        [Route("UpdateBlog/{id}")]
        public async Task<IActionResult> UpdateBlog(Article article) {

            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            article.CreatedDate = DateTime.Now;
            article.AppUserId = user.Id;

            _articleService.TUpdate(article);
            return RedirectToAction("MyBlogList", "Blog", new { area = "Writer" });
        }

        [HttpGet]
        [Route("CreateBlog")]
        public IActionResult CreateBlog()
        {
            List<SelectListItem> values = (from x in _categoryService.TGetListAll()
                                           select new SelectListItem
                                           {
                                               Text=x.CategoryName,
                                               Value=x.CategoryId.ToString()
                                           }).ToList();

            ViewBag.v = values;
            return View();
        }

        [HttpPost]
        [Route("CreateBlog")]
        public async Task<IActionResult> CreateBlog(Article article)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            article.CreatedDate = DateTime.Now;
            article.AppUserId=user.Id;

            _articleService.TInsert(article);
            return RedirectToAction("MyBlogList", "Blog", new { area = "Writer" });
        }


        [HttpGet]
        [Route("CreateTagBlog/{id}")]
        public IActionResult CreateTagBlog(int id)
        {
            id = 1002;
            var value = _tagService.TGetListAll();
            ViewBag.ArticleId = id;

            // Mevcut bloğa zaten ekli olan etiketleri al
            var existingTags = _articletagService.TGetWithTagByArticle(id);

            // Bloğa ekli olan etiketlerin TagId'lerini bir listede sakla
            var existingTagIds = existingTags.Select(t => t.TagId).ToList();

            // Tüm etiketleri alırken, zaten ekli olanları seçili olarak işaretle
            List<SelectListItem> TagValues = (from x in value
                                              select new SelectListItem
                                              {
                                                  Text = x.TagTitle,
                                                  Value = x.TagId.ToString(),
                                                  Selected = existingTagIds.Contains(x.TagId) // Bu etiket zaten ekli mi?
                                              }).ToList();

            ViewBag.TagValues = TagValues;
            return View();
        }

        [HttpPost]
        [Route("CreateTagBlog/{id}")]
        public async Task<IActionResult> CreateTagBlog(List<int> SelectedTags, int id)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            if (SelectedTags != null && SelectedTags.Any())
            {
                foreach (var tagId in SelectedTags)
                {
                    var articleTag = new ArticleTag
                    {
                        ArticleId = id,
                        TagId = tagId
                    };
                    _articletagService.TInsert(articleTag);
                }
            }

            return RedirectToAction("MyBlogList", "Blog", new { area = "Writer" });
        }


    }
}
