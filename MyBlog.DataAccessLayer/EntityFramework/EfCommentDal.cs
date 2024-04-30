using Microsoft.EntityFrameworkCore;
using MyBlog.DataAccessLayer.Abstract;
using MyBlog.DataAccessLayer.Context;
using MyBlog.DataAccessLayer.Repositories;
using MyBlog.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.DataAccessLayer.EntityFramework
{
    public class EfCommentDal : GenericRepository<Comment>, ICommentDal
    {
        BlogContext context = new BlogContext();

        public void ChangeStatus(int id)
        {
            // Find the comment by its ID
            var comment = context.Set<Comment>().Find(id);

            // Check if the comment exists
            if (comment != null)
            {
                // Change the status
                comment.Status = !comment.Status;

                // Save the changes to the database
                context.SaveChanges();
            }
        }

        public List<Comment> GetCommentByBlog(int id)
        {
            var values = context.Comments.Where(x=>x.ArticleId==id).ToList();
            return values;
        }

        public List<Comment> GetCommentsForWriter(int id)
        {
            var values = context.Comments
        .Where(comment => comment.Article.AppUserId == id).OrderByDescending(comment => comment.CreatedDate) // Assuming there's a CreatedDate property
        .Take(3)
        .ToList();

           
            return values;
        }

        public List<Comment> GetCommentsWithArticle()
        {
            var values = context.Comments.Include(x=>x.Article).ThenInclude(article => article.AppUser).ToList();

            return values;
        }

        public void InsertWithDifferent(Comment entity)
        {
            context.Add(entity);
            context.SaveChanges();
        }
    }
}
