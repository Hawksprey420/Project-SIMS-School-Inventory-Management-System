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

namespace NEW_PROJECT_SIMS
{
    public partial class frmLogin : Form
    {
       
        public frmLogin()
        {
            InitializeComponent();
         
        }

        SqlConnection cn = new SqlConnection(@"Data Source=Hawksprey;Initial Catalog=sims;Integrated Security=True");   

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username, password;
            username = txtuser.Text;
            password = txtpass.Text;

            try
            {
                string login = "select * from tblUser where username = '" + txtuser.Text + "' AND password = '" + txtpass.Text + "'";
                SqlCommand sqlcmd = new SqlCommand(login, cn);
                sqlcmd.Parameters.AddWithValue("@username", txtuser.Text);
                sqlcmd.Parameters.AddWithValue("@password", txtpass.Text);
                DataTable dt = new DataTable();

                SqlDataAdapter sqlsda = new SqlDataAdapter(login, cn);
                sqlsda.Fill(dt);

                if (dt.Rows.Count == 1 == dt.Rows[0]["status"].ToString().Equals("Active"))
                {
                    this.Hide();

                    if (dt.Rows[0]["position"].ToString().Equals("Admin"))
                    {
                        MessageBox.Show("You are now logged in as an Admin");
                        frmDashboard admin = new frmDashboard();
                        admin.LoadAdmin();
                        admin.Show();
                        this.Hide();
                    }
                    else if (dt.Rows[0]["position"].ToString().Equals("Staff"))
                    {
                        MessageBox.Show("You are now logged in as an staff");
                        frmStaff f = new frmStaff();
                        f.LoadStaff();
                        f.Show();
                        this.Hide();
                    }
                }

                else
                {
                    if (dt.Rows[0]["status"].ToString().Equals("Inactive"))
                    {
                        MessageBox.Show("Inactive Account", var._title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtuser.Clear();
                        txtpass.Clear();
                        txtuser.Focus();
                    }


                }
            }
            catch
            {
                MessageBox.Show("Invalid Username or Password", var._title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtuser.Clear();
                txtpass.Clear();
                txtuser.Focus();

            }
            finally
            {
                cn.Close();
            }
        }

        private void lblClearFields_Click(object sender, EventArgs e)
        {
            txtuser.Clear();
            txtpass.Clear();
            txtuser.Focus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult res;
            res = MessageBox.Show("Do you want to exit", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                this.Show();
            }
        }

        private void txtuser_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}

    

