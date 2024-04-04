using MyBlog.DataAccessLayer.Abstract;
using MyBlog.DataAccessLayer.Repositories;
using MyBlog.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.DataAccessLayer.EntityFramework
{
    public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
    {
        private List<Category> categories = new List<Category>();
        public Dictionary<string, int> GetCategoryCounts()
        {
            Dictionary<string, int> categoryCounts = categories
           .GroupBy(c => c.CategoryName)
           .ToDictionary(g => g.Key, g => g.Count());

            return categoryCounts;
        }
    }
}
