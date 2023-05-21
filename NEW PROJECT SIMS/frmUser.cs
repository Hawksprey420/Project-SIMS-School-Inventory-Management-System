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
    public partial class frmUser : Form
    {

        SqlConnection cn;
        SqlCommand cm;
        frmMaintenance f;
        public string _id;


        public frmUser(frmMaintenance f)
        {
            InitializeComponent();
            cn = new SqlConnection(dbnconstring.connection);
            this.f = f;
        }

        private void btnClose3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSave3_Click(object sender, EventArgs e)
        {
            try
            {   //validation for empty field!
                if (MessageBox.Show("Do you want to save this record?", var._title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("insert into tblUser (username, password, position, status)values(@username, @password, @position, @status)", cn);
                    cm.Parameters.AddWithValue("@username", txtUser.Text);
                    cm.Parameters.AddWithValue("@password", txtPass.Text);
                    cm.Parameters.AddWithValue("position", cboPosition.Text);
                    cm.Parameters.AddWithValue("@status", cboStatus.Text);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Record has been successfully saved!", var._title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    f.LoadU();
                    this.Dispose();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, var._title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Clear()
        {
            txtUser.Clear();
            txtPass.Clear();
            cboPosition.Text = "";
            cboStatus.Text = "";
            btnSave3.Enabled = true;
            btnUpdate3.Enabled = false;
            txtUser.Focus();
        }

        private void btnClear3_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnUpdate3_Click(object sender, EventArgs e)
        {
            
            try
            {   //validation for empty field!
                if (MessageBox.Show("Do you want to update this record?", var._title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("update tblUser set username=@username, password=@password, position=@position, status=@status where id=@id", cn);
                    cm.Parameters.AddWithValue("@username", txtUser.Text);
                    cm.Parameters.AddWithValue("@password", txtPass.Text);
                    cm.Parameters.AddWithValue("position", cboPosition.Text);
                    cm.Parameters.AddWithValue("@status", cboStatus.Text);
                    cm.Parameters.AddWithValue("@id", _id);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Record has been successfully saved!", var._title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    f.LoadU();
                    this.Dispose();
                }

            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, var._title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                f.LoadU();
            }
        }

        private void btnClose2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
    

