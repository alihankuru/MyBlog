using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyBlog.BusinessLayer.Abstract;
using MyBlog.EntityLayer.Concrete;
using MyBlog.PresentationLayer.Areas.Admin.Models;

namespace MyComment.PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Comment")]
    public class CommentController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
     
        private readonly ICommentService _commentService;

        public CommentController(UserManager<AppUser> userManager, ICommentService commentService)
        {
            _userManager = userManager;
            _commentService = commentService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = _commentService.TGetCommentsWithArticle();

            return View(values);
        }

        [Route("ChangeStatusComment/{id}")]
        public IActionResult ChangeStatusComment(int id)
        {
            _commentService.TChangeStatus(id);
            return RedirectToAction("Index", "Comment", new { area = "Admin" });
        }

       


    }
}
