using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HWYDotNetTrainingBatch1.ConsoleApp2
{
    internal class HomeworkService
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
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            string query = "select * from Tbl_Homework";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            connection.Close();

            //for(int i=0; i<dt.Rows.Count; i++)
            //{
            //    DataRow dr = dt.Rows[i];
            //    Console.WriteLine(dr["No"]);
            //    Console.WriteLine(dr["Name"]);
            //    Console.WriteLine(dr["GitHubUserName"]);
            //    Console.WriteLine("------------------------------------");
            //}

            foreach(DataRow dr in dt.Rows)
            {
                Console.WriteLine(dr["No"]);
                Console.WriteLine(dr["Name"]);
                Console.WriteLine(dr["GitHubUserName"]);
                Console.WriteLine("------------------------------------");
            }
        }

        public void Detail(int no)
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            string query = $"select * from Tbl_Homework where No = {no}";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            connection.Close();

            if (dt.Rows.Count == 0)
            {
                Console.WriteLine("No record found.");
                return;
            }

            DataRow dr = dt.Rows[0];
            Console.WriteLine(dr["No"]);
            Console.WriteLine(dr["Name"]);
            Console.WriteLine(dr["GitHubUserName"]);
            Console.WriteLine("--------------------------");
        }

        public void Create()
        {
            Console.WriteLine("Enter Name: ");
            string name = Console.ReadLine()!;    

            Console.WriteLine("Enter GitHubUserName: ");
            string gitHubUserName = Console.ReadLine()!;

            Console.WriteLine("Enter GitHuhRepoLink: ");
            string gitHuhRepoLink = Console.ReadLine()!;

            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            string query = $@"
INSERT INTO [dbo].[Tbl_Homework]
           ([Name]
           ,[GitHubUserName]
           ,[GitHubRepoLink])
     VALUES
           (@Name
           ,@GitHubUserName
           ,@GitHubRepoLink)";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@GitHubUserName", gitHubUserName);
            cmd.Parameters.AddWithValue("@GitHubRepoLink", gitHuhRepoLink);


            //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //adapter.Fill(dt);

            connection.Close();
        }

        public void Update()
        {
            Console.WriteLine("Enter Id: ");
            string no = Console.ReadLine()!;

            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            string query = $"select * from Tbl_Homework where No = {no}";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            if (dt.Rows.Count == 0)
            {
                Console.WriteLine("No record found.");
                return;
            }

            Console.WriteLine("Enter Name: ");
            string name = Console.ReadLine()!;

            Console.WriteLine("Enter GitHubUserName: ");
            string gitHubUserName = Console.ReadLine()!;

            Console.WriteLine("Enter GitHuhRepoLink: ");
            string gitHuhRepoLink = Console.ReadLine()!;

            //SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            //connection.Open();

            string query2 = $@"
UPDATE [dbo].[Tbl_Homework]
   SET [Name] = @Name1
      ,[GitHubUserName] = @GitHubUserName1 
      ,[GitHubRepoLink] = @GitHubRepoLink1
 WHERE No = @Id";

            SqlCommand cmd2 = new SqlCommand(query2, connection);
            cmd2.Parameters.AddWithValue("@Id", no);
            cmd2.Parameters.AddWithValue("@Name1", name);
            cmd2.Parameters.AddWithValue("@GitHubUserName1", gitHubUserName);
            cmd2.Parameters.AddWithValue("@GitHubRepoLink1", gitHuhRepoLink);

            int result = cmd2.ExecuteNonQuery();

            //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //adapter.Fill(dt);

            connection.Close();
        }

        public void Delete()
        {
            Console.WriteLine("Enter Id: ");
            string no = Console.ReadLine()!;

            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            string query = $"select * from Tbl_Homework where NO = {no}";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            connection.Close();

            if (dt.Rows.Count == 0)
            {
                Console.WriteLine("No record found.");
                return;
            }
            if (dt.Rows.Count == 0)
                Console.WriteLine("Are you sure want to delete? (Y/N)");
            string confirm = Console.ReadLine()!;
            if (confirm.ToUpper() == "Y")
            {
                SqlConnection connection2 = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
                connection.Open();

                string query2 = $@"
Delete [dbo].[Tbl_Homework]
 WHERE No = @Id";

                SqlCommand cmd2 = new SqlCommand(query2, connection);
                cmd2.Parameters.AddWithValue("@Id", no);

                int result = cmd2.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void LoginWithStoredProcedure()
        {
            Console.Write("Enter UserName: ");
            string userName = Console.ReadLine()!;

            Console.Write("Enter Password: ");
            string password = Console.ReadLine()!;

            string query = @$"Sp_Login";

            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserName", userName);
            cmd.Parameters.AddWithValue("@Password", password);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            connection.Close();
        }



    }
}
   