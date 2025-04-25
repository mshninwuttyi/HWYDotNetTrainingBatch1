﻿using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
