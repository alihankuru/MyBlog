﻿using MyBlog.BusinessLayer.Abstract;
using MyBlog.DataAccessLayer.Abstract;
using MyBlog.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.BusinessLayer.Concrete
{
    public class CommentManager : ICommentService
    {
        private readonly ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public List<Comment> TGetCommentsWithArticle()
        {
            return _commentDal.GetCommentsWithArticle();
        }

        public void InsertWithDifferent(Comment entity)
        {
            _commentDal.InsertWithDifferent(entity);    
        }

        public void TDelete(int id)
        {
           _commentDal.Delete(id);
        }

        public Comment TGetById(int id)
        {
           return _commentDal .GetById(id);
        }

        public List<Comment> TGetCommentByBlog(int id)
        {
            return _commentDal.GetCommentByBlog(id);
        }

        public List<Comment> TGetListAll()
        {
            return _commentDal.GetListAll();
        }

        public void TInsert(Comment entity)
        {
            _commentDal.Insert(entity);
        }

        public void TUpdate(Comment entity)
        {
            _commentDal.Update(entity);
        }

        public void TChangeStatus(int id)
        {
            _commentDal.ChangeStatus(id);
        }

        public List<Comment> TGetCommentsForWriter(int id)
        {
            return _commentDal.GetCommentsForWriter(id);
        }
    }
}
