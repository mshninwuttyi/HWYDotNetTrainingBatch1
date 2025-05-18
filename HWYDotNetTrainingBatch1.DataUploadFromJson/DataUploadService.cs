using HWYDotNetTrainingBatch1.Assigned.DreamDictionary.Databases.Models;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWYDotNetTrainingBatch1.DataUploadFromJson
{
    internal class DataUploadService
    {

        private readonly AppDbContext _dbContext;

        public DataUploadService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        //{
        //    DataSource = "HNINWUTTYI\\MSSQLSERVER2022",
        //    InitialCatalog = "DotNetTrainingBatch1",
        //    UserID = "sa",
        //    Password = "admin123!",
        //    TrustServerCertificate = true
        //};

        public int Read()
        {
            //SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            //connection.Open();

            string jsonStr = File.ReadAllText("DreamDictionary.json");
            var model = JsonConvert.DeserializeObject<DreamDictionaryResponseModel>(jsonStr)!;
            var lst = model.BlogHeader.ToList();
            foreach (var item in lst)
            {
                var blogHeader = new TblBlogHeader
                {
                    BlogId = item.BlogId,
                    BlogTitle = item.BlogTitle,
                };

                _dbContext.TblBlogHeaders.Add(blogHeader);
            }
            var result = _dbContext.SaveChanges();
            return result;
        }
}

    public class DreamDictionaryResponseModel
    {
        public Blogheader[] BlogHeader { get; set; }
        public Blogdetail[] BlogDetail { get; set; }
    }

    public class Blogheader
    {
        public int BlogId { get; set; }
        public string BlogTitle { get; set; }
    }

    public class Blogdetail
    {
        public int BlogDetailId { get; set; }
        public int BlogId { get; set; }
        public string BlogContent { get; set; }
    }
}



