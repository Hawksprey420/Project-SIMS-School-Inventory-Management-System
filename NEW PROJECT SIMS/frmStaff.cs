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
    public partial class frmStaff : Form
    {
        SqlConnection cn;
        SqlCommand cm;
        SqlDataReader dr;

        public frmStaff()
        {
            InitializeComponent();
            cn = new SqlConnection(dbnconstring.connection);
        }

        private void btnLogOut_Click(object sender, EventArgs e)
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

        private void btnInventory_Click(object sender, EventArgs e)
        {
            frmInventory f = new frmInventory();
            f.TopLevel = false;
            panel7.Controls.Add(f);
            f.LoadInventory();
            f.Show();
        }

        private void btnDocument_Click(object sender, EventArgs e)
        {
            frmDocument f = new frmDocument();
            f.TopLevel = false;
            panel7.Controls.Add(f);
            f.LoadInventory1();
            f.Show();
        }

        private void btnMaintenance_Click(object sender, EventArgs e)
        {
            frmStaffMaintenance f = new frmStaffMaintenance();
            f.TopLevel = false;
            panel7.Controls.Add(f);
            f.LoadRecord1();
            f.LoadBuilding1();
            f.LoadRecipient1();
            f.LoadRoom1();
            f.Show();
        }

        public void LoadStaff()
        {
            try
            {
                cn.Open();
                cm = new SqlCommand("select * from tblUser where username like '%" + user.Text + "%' and position like 'Staff" + Pos.Text + "%'", cn);
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
            lblInventory.Text = CountRecords("select count (*) from tblInventory");
            lblDepartment.Text = CountRecords("select count (*) from tblDepartment");
            lblBuilding.Text = CountRecords("select count (*) from tblBuilding");
            lblRoom.Text = CountRecords("select count (*) from tblRoom");
            lblRecipient.Text = CountRecords("select count (*) from tblRecipient");
        }

        public string CountRecords(string sql)
        {
            cn.Open();
            cm = new SqlCommand(sql, cn);
            string count = cm.ExecuteScalar().ToString();
            cn.Close();
            return count;
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    
}
