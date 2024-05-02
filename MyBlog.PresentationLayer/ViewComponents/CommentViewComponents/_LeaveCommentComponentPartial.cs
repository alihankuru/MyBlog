using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;
using MyBlog.EntityLayer.Concrete;
using MyBlog.PresentationLayer.Areas.Admin.Models;
using MyBlog.PresentationLayer.Models;

namespace MyBlog.PresentationLayer.ViewComponents.CommentViewComponents
{
    public class _LeaveCommentComponentPartial:ViewComponent
    {
        private readonly ICommentService _commentService;

        public _LeaveCommentComponentPartial(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet]
        public IViewComponentResult Invoke(int id)
        {

            var value = new LeaveACommentViewModel()
            {
                ArticleId = id
            };
            return View(value);
        }




    }
}
