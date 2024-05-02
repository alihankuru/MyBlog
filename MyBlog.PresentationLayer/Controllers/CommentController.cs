using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;
using MyBlog.EntityLayer.Concrete;
using MyBlog.PresentationLayer.Models;

namespace MyBlog.PresentationLayer.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost]

        public IActionResult CreateComment(LeaveACommentViewModel model)
        {
            _commentService.TInsert(new Comment()
            {
                ArticleId = model.ArticleId,
                Name = model.Name,
                Email = model.Email,
                CreatedDate = DateTime.Now,
                Message = model.Message,
                Description="aa",
            });

            return RedirectToAction("BlogDetail", "Blog");
        }

    }
}
