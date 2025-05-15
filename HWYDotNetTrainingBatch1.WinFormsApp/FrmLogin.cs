using Microsoft.Data.SqlClient;
using System.Data;
using System.Reflection.Metadata;

namespace HWYDotNetTrainingBatch1.WinFormsApp
{
    public partial class FrmLogin : Form
    {
        private readonly SqlService _sqlService;
        public FrmLogin()
        {
            InitializeComponent();
            _sqlService = new SqlService();
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
            //SqlParameter parameter1 = new SqlParameter("@UserName", userName);
            //SqlParameter parameter2 = new SqlParameter("@Password", password);

            //List<SqlParameter> parameters = new List<SqlParameter>
            //{
            //    parameter1,
            //    parameter2
            //};

            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@UserName", userName),
                new SqlParameter("@Password", password)
            };

            //parameters.Add(parameter1);
            //parameters.Add(parameter2);

            DataTable dt = _sqlService.Query(query, parameters);

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("User doesn't exist");
                return;
            }
            MessageBox.Show("Login Successful.");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtUserName.Clear();
            txtPassword.Clear();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
    