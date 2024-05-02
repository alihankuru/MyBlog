using MyBlog.EntityLayer.Concrete;

namespace MyBlog.PresentationLayer.Models
{
    public class LeaveACommentViewModel
    {
        public int ArticleId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
    }
}
