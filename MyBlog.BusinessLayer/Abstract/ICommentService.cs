﻿using MyBlog.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.BusinessLayer.Abstract
{
    public interface ICommentService:IGenericeService<Comment>
    {
        void InsertWithDifferent(Comment entity);
        List<Comment> TGetCommentsWithArticle();
        List<Comment> TGetCommentByBlog(int id);
        List<Comment> TGetCommentsForWriter(int id);
        void TChangeStatus(int id);
    }
}
