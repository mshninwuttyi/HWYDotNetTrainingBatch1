using HWYDotNetTrainingBatch1.Assigned.DreamDictionary.Databases.Models;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWYDotNetTrainingBatch1.DataUploadFromJson
{
    public class DataUploadService
    {

        //        //private readonly AppDbContext _dbContext;

        //        //public DataUploadService(AppDbContext dbContext)
        //        //{
        //        //    _dbContext = dbContext;
        //        //}

        private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = "HNINWUTTYI\\MSSQLSERVER2022",
            InitialCatalog = "DotNetTrainingBatch1",
            UserID = "sa",
            Password = "admin123!",
            TrustServerCertificate = true
        };

        public void UploadBlogHeaderFromJson()
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            string jsonStr = File.ReadAllText("DreamDictionary.json");
            var model = JsonConvert.DeserializeObject<DreamDictionaryResponseModel>(jsonStr)!;
            var lst = model.BlogHeader.ToList();

            foreach (var item in lst)
            {
                string query = $@"
INSERT INTO [dbo].[Tbl_BlogHeader]
           ([BlogTitle])
     VALUES
           (@BlogTitle)";

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@BlogTitle", item.BlogTitle);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                connection.Close();
            }
        }


        public void UploadBlogDetailFromJson()
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            string jsonStr = File.ReadAllText("DreamDictionary.json");
            var model = JsonConvert.DeserializeObject<DreamDictionaryResponseModel>(jsonStr)!;
            var lst = model.BlogDetail.ToList();

            foreach (var item in lst)
            {
                string query = $@"
INSERT INTO [dbo].[Tbl_BlogDetail]
           ([BlogId]
            ,[BlogContent]
            )
     VALUES
           (@BlogId
            ,@BlogContent)";

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@BlogId", item.BlogId);
                cmd.Parameters.AddWithValue("@BlogContent", item.BlogContent);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                connection.Close();
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
}



