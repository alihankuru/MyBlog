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

        public List<Comment> GetCommentByBlog(int id)
        {
            var values = context.Comments.Where(x=>x.ArticleId==id).ToList();
            return values;
        }

        public void InsertWithDifferent(Comment entity)
        {
            context.Add(entity);
            context.SaveChanges();
        }
    }
}
