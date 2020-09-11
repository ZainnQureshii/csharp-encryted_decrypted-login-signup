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


namespace EncrytedSignIn
{
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\SHS\Documents\Visual Studio 2012\Projects\DATABASES\EncrytionDB.mdf;Integrated Security=True;Connect Timeout=30");

        private void ReloadForm1()
        {
          dataGridView1.Update();
            //and how many controls or settings you want, just add them here
        }

        DataTable dt = new DataTable();
        SqlDataAdapter sqlda = new SqlDataAdapter();

        private void Form1_Load(object sender, EventArgs e)
        {

   /*         conn.Open();

            SqlCommand cmd = new SqlCommand("select * from SignIn ORDER BY Id ASC", conn);
            SqlDataAdapter sqlda = new SqlDataAdapter(cmd);
            

            sqlda.Fill(dt);
            dataGridView1.DataSource = dt;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            conn.Close();

    */
        }

        
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if ( txtid.Text != "" && txtname.Text != "" && txtCpass.Text != "" && txtpass.Text != "")  //validating the fields whether the fields or empty or not  
            {
                if (txtCpass.Text.ToString().Trim().ToLower() == txtpass.Text.ToString().Trim().ToLower()) //validating Password textbox and confirm password textbox is match or unmatch    
                {
                    string UserName = txtname.Text;
                    string Password = Cryptography.Encrypt(txtpass.Text.ToString());   // Passing the Password to Encrypt method and the method will return encrypted string and stored in Password variable.  
                    string CPassword = Cryptography.Encrypt(txtCpass.Text.ToString());
                    
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("insert into SignIn values('"+int.Parse(txtid.Text)+"' ,'" + UserName + "' , '"+ Password +"' ,'" + CPassword + "')", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Record inserted successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Password and Confirm Password doesn't match!.. Please Check..", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);  //showing the error message if password and confirm password doesn't match  
                }
            }
            else
            {
                MessageBox.Show("Please fill all the fields!..", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);  //showing the error message if any fields is empty  
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }
  
    }
}
