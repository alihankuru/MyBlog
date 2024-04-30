using MyBlog.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.DataAccessLayer.Abstract
{
    public interface ICommentDal:IGenericDal<Comment>
    {
        void InsertWithDifferent(Comment entity);
        List<Comment> GetCommentByBlog(int id);
        List<Comment> GetCommentsWithArticle();
        void ChangeStatus(int id);
        List<Comment> GetCommentsForWriter(int id);
        

    }
}
