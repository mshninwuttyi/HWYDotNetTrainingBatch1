using HWYDotNetTrainingBatch1.Assigned.DreamDictionary.Databases.Models;
using HWYDotNetTrainingBatch1.Assigned.DreamDictionary.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWYDotNetTrainingBatch1.Assigned.DreamDictionary.Domain.Features
{
    public class BlogService
    {
        private readonly AppDbContext _dbContext;

        public BlogService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ResponseModel GetBlogs()
        {
            try
            {
                var lst = _dbContext.TblBlogHeaders.ToList();
                return new ResponseModel(true, "Success", lst);
            }
            catch (Exception ex)
            {

                return new ResponseModel(false, ex.ToString());
            }
        }

        public ResponseModel GetBlogDetailById(int id)
        {
            try
            {
                var lst = _dbContext.TblBlogDetails.FirstOrDefault(x => x.BlogId == id);
                return new ResponseModel(true, "Success", lst);
            }
            catch (Exception ex)
            {

                return new ResponseModel(false, ex.ToString());
            }
        }
    }
}
