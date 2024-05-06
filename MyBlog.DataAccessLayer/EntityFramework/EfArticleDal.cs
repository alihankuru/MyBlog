using Microsoft.EntityFrameworkCore;
using MyBlog.DataAccessLayer.Abstract;
using MyBlog.DataAccessLayer.Context;
using MyBlog.DataAccessLayer.Repositories;
using MyBlog.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace MyBlog.DataAccessLayer.EntityFramework
{
    public class EfArticleDal : GenericRepository<Article>, IArticleDal
    {
        BlogContext context=new BlogContext();


        public List<Article> GetArticlesByWriter(int id)
        {
            var values=context.Articles.Where(x=>x.AppUserId==id).ToList();
            return values;
        }

        public List<Article> GetArticlesWithCategory()
        {
            var values = context.Articles.Include(x=>x.Category).ToList();
            return values;
        }

        public Article GetArticlesWithCategoryByArticleId(int id)
        {
            var values = context.Articles
                        .Where(x => x.ArticleId == id)
                        .Include(y => y.Category)
                        .Include(y => y.AppUser) // Include AppUser
                        .FirstOrDefault();
            return values;
        }

        public List<Article> GetArticlesWithCategoryByWriter(int id)
        {
            var values = context.Articles.Where(x=>x.AppUserId==id).Include(x => x.Category).Include(x => x.AppUser).ToList();
            return values;
        }

        public List<Article> GetListLast4Blog()
        {
            var values = context.Articles.OrderByDescending(x=>x.CreatedDate).Take(4).Include(x => x.Category).ToList();
            return values;
        }
       

    }
}
