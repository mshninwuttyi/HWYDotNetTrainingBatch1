using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWYDotNetTrainingBatch1.ConsoleApp2
{
    internal class LoginDapperService
    {
        private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = "HNINWUTTYI\\MSSQLSERVER2022",
            InitialCatalog = "DotNetTrainingBatch1",
            UserID = "sa",
            Password = "admin123!",
            TrustServerCertificate = true
        };

        public void Read()
        {
            string query = "select * from tbl_user";
            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            var lst = db.Query<User>(query).ToList();

            foreach (var item in lst)
            {
                Console.WriteLine(item.Id);
                Console.WriteLine(item.UserName);
                Console.WriteLine(item.Password);
            }

        }

        public class User
        {
            public int Id { get; set; }     
            public string UserName { get; set; }     
            public string Password { get; set; }     
        }
    }
}
