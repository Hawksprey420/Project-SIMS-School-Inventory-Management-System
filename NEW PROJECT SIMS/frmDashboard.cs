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
        private Timer timer;

        public frmDashboard()
        {
            InitializeComponent();
            cn = new SqlConnection(dbnconstring.connection);
            timer = new Timer();
            timer.Interval = 1000; // Set the interval to 1 second (1000 milliseconds)
            timer.Tick += Timer_Tick;
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
            this.Refresh();
        }

        private void lblInventory_Click(object sender, EventArgs e)
        {
            lblInventory.Refresh();
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
            string count = cm.ExecuteScalar().ToString();
            cn.Close();
            return count;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblRoom_Click(object sender, EventArgs e)
        {
            lblRoom.Refresh();
        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            UpdateCounts();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.Refresh();
        }
        private void UpdateCounts()
        {
            _ = lblInventory.Text;
            _ = lblDepartment.Text;
            _ = lblBuilding.Text;
            _ = lblRoom.Text;
            _ = lblRecipient.Text;
        }

        private void lblInventory_TextChanged(object sender, EventArgs e)
        {
       
        }
    }
}

     
    


