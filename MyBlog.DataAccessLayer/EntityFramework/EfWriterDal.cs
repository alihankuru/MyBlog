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
    public class EfWriterDal : GenericRepository<Writer>, IWriterDal
    {
        BlogContext context = new BlogContext();
        public void ChangeStatus(int id)
        {
        
            var user = context.Set<AppUser>().Find(id);

        
            if (user != null)
            {
            
                user.Status = !user.Status;

             
                context.SaveChanges();
            }
        }

        public int GetWriterCount()
        {
            return 1;
        }
    }
}
