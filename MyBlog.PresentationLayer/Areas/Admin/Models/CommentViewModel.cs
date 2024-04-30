using System.ComponentModel.DataAnnotations;

namespace MyBlog.PresentationLayer.Areas.Admin.Models
{
    public class CommentViewModel
    {
      
            public int BlogId { get; set; } // BlogId özelliği eklendi
            public string Name { get; set; }
            public string Email { get; set; }
            public string Message { get; set; }
        
    }
}
