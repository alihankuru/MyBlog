using MyBlog.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.BusinessLayer.Abstract
{
    public interface IArticleService:IGenericeService<Article>
    {
        List<Article> TGetArticlesByWriter(int id);

        List<Article> TGetArticlesWithCategoryByWriter(int id);
        Article TGetArticlesWithCategoryByArticleId(int id);

        List<Article> TGetListLast4Blog();

    }
}
