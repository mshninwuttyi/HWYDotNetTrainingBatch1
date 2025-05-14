namespace HWYDotNetTrainingBatch1.WinFormsApp
{
    partial class FrmLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtUserName = new TextBox();
            lblUseName = new Label();
            lblPassword = new Label();
            txtPassword = new TextBox();
            btnLogin = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // txtUserName
            // 
            txtUserName.Location = new Point(75, 48);
            txtUserName.Margin = new Padding(4);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(301, 29);
            txtUserName.TabIndex = 0;
            txtUserName.TextChanged += btnLogin_Click;
            // 
            // lblUseName
            // 
            lblUseName.AutoSize = true;
            lblUseName.Location = new Point(75, 23);
            lblUseName.Margin = new Padding(4, 0, 4, 0);
            lblUseName.Name = "lblUseName";
            lblUseName.Size = new Size(84, 21);
            lblUseName.TabIndex = 1;
            lblUseName.Text = "Username:";
            lblUseName.Click += label1_Click;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(75, 98);
            lblPassword.Margin = new Padding(4, 0, 4, 0);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(79, 21);
            lblPassword.TabIndex = 2;
            lblPassword.Text = "Password:";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(75, 123);
            txtPassword.Margin = new Padding(4);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '.';
            txtPassword.Size = new Size(301, 29);
            txtPassword.TabIndex = 3;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(46, 125, 50);
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(223, 189);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(119, 37);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "&Login";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(84, 110, 122);
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(100, 189);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(119, 37);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "&Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(451, 293);
            Controls.Add(btnCancel);
            Controls.Add(btnLogin);
            Controls.Add(txtPassword);
            Controls.Add(lblPassword);
            Controls.Add(lblUseName);
            Controls.Add(txtUserName);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(4);
            Name = "FrmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtUserName;
        private Label lblUseName;
        private Label lblPassword;
        private TextBox txtPassword;
        private Button btnLogin;
        private Button btnCancel;
    }
}
