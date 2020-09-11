using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing;

namespace EncrytedSignIn
{
    public partial class SignIn : Form
    {
        
        public SignIn()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\SHS\Documents\Visual Studio 2012\Projects\DATABASES\EncrytionDB.mdf;Integrated Security=True;Connect Timeout=30");
  
        private void btn_Click(object sender, EventArgs e)
        {
            string Password = "";
            bool IsExist = false;
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from SignIn where CONVERT(VARCHAR, Name)='" + txtname1.Text + "'", conn);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                Password = sdr.GetString(2);  //get the user password from db if the user name is exist in that.  
                IsExist = true;
            }
            conn.Close();
            if (IsExist)  //if record exis in db , it will return true, otherwise it will return false  
            {
                if (Cryptography.Decrypt(Password).Equals(txtpass1.Text))
                {
                    MessageBox.Show("Login Success", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SignUp su = new SignUp();
                    su.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Password is wrong!...", "error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else  //showing the error message if user credential is wrong  
            {
                MessageBox.Show("Please enter the valid credentials", "error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void SignIn_Load(object sender, EventArgs e)
        {
            label1.BackColor = System.Drawing.Color.Transparent;
            label2.BackColor = System.Drawing.Color.Transparent;
        //    txtname1.BackColor = System.Drawing.Color.Transparent;
        //    txtpass1.BackColor = System.Drawing.Color.Transparent;
            this.txtname1.AutoSize = false;
            this.txtpass1.AutoSize = false;
            this.txtname1.Size = new System.Drawing.Size(142, 27);
            this.txtpass1.Size = new System.Drawing.Size(142, 27);
        }    
    }
}
