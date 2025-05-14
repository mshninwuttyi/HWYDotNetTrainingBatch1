using Microsoft.Data.SqlClient;
using System.Data;

namespace HWYDotNetTrainingBatch1.WinFormsApp
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text.Trim();
            string password = txtPassword.Text.Trim();

            string query = $"SELECT * FROM Tbl_User where UserName = @UserName and Password = @Password";
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = "HNINWUTTYI\\MSSQLSERVER2022",
                InitialCatalog = "DotNetTrainingBatch1",
                Password = "admin123!",
                TrustServerCertificate = true
            };  

            SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);

            connection.Open();

            SqlCommand cmd = new SqlCommand( query, connection);
            cmd.Parameters.AddWithValue ("@UserName", userName);
            cmd.Parameters.AddWithValue ("@Password", password);
            DataTable dt = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            sqlDataAdapter.Fill(dt);


            connection.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtUserName.Clear();
            txtPassword.Clear();
        }
    }
}
    