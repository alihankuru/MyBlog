using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;

namespace MyBlog.PresentationLayer.ViewComponents.DefaultViewComponents
{
    public class _SidebarFeatureComponentPartial:ViewComponent
    {
        private readonly IArticleService _articleService;

        public _SidebarFeatureComponentPartial(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _articleService.TGetListLast4Blog();
            return View(values);
        }
    }
}
