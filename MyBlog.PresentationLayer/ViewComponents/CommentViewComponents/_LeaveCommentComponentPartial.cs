using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;
using MyBlog.EntityLayer.Concrete;
using MyBlog.PresentationLayer.Areas.Admin.Models;

namespace MyBlog.PresentationLayer.ViewComponents.CommentViewComponents
{
    public class _LeaveCommentComponentPartial:ViewComponent
    {
        private readonly ICommentService _commentService;

        public _LeaveCommentComponentPartial(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            id = 1002;
            var values = _commentService.TGetCommentByBlog(id);
            ViewBag.BlogId = id;

            return View(values);
        }

       

    }
}
