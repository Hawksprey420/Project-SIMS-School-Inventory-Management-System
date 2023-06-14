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
    public partial class frmDashboard : Form
    {
        SqlConnection cn;
        SqlCommand cm;
        SqlDataReader dr;

        public frmDashboard()
        {
            InitializeComponent();
            cn = new SqlConnection(dbnconstring.connection);
        }

        private void btnInventory_Click_1(object sender, EventArgs e)
        {
            frmInventory f = new frmInventory();
            f.TopLevel = false;
            panel7.Controls.Add(f);
            f.LoadInventory();
            f.Show();
        }

        private void btnDocument_Click_1(object sender, EventArgs e)
        {
            frmDocument f = new frmDocument();
            f.TopLevel = false;
            panel7.Controls.Add(f);
            f.LoadInventory1();
            f.Show();
        }

        private void btnMaintenance_Click_1(object sender, EventArgs e)
        {
            frmMaintenance f = new frmMaintenance();
            f.TopLevel = false;
            panel7.Controls.Add(f);
            f.LoadRecord();
            f.Show();
            f.LoadBuilding();
            f.LoadRecipient();
            f.LoadUser();
            f.LoadU();
            f.LoadRoom();
        }

        private void btnLogOut_Click_1(object sender, EventArgs e)
        {
            DialogResult res;
            res = MessageBox.Show("Do you want to Log Out?", "Log Out", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                this.Show();
            }
        }

        private void lblUser_Click(object sender, EventArgs e)
        {

        }

        private void lblInventory_Click(object sender, EventArgs e)
        {

        }
        public void LoadAdmin()
        {
            try
            {
                cn.Open();
                cm = new SqlCommand("select * from tblUser where username like '%" + user.Text + "%' and position like 'Admin" + Pos.Text + "%'", cn);
                cm.Parameters.AddWithValue("@username", user.Text);
                cm.Parameters.AddWithValue("@position", Pos.Text);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {

                    user.Text = dr["username"].ToString();
                    Pos.Text = dr["position"].ToString();

                }
                dr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, var._title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            lblInventory.Text = CountRecords("select count (*) from tblInventory");
            lblDepartment.Text = CountRecords("select count (*) from tblDepartment");
            lblBuilding.Text = CountRecords("select count (*) from tblBuilding");
            lblRoom.Text = CountRecords("select count (*) from tblRoom");
            lblRecipient.Text = CountRecords("select count (*) from tblRecipient");
        }

        public string CountRecords(string sql)
        {
            cn.Open();
            cm = new SqlCommand (sql, cn);
            string _count = cm.ExecuteScalar().ToString();
            cn.Close();
            return _count;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

     
    


