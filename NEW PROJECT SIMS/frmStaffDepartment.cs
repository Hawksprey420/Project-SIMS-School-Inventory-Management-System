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

    public partial class frmStaffDepartment : Form
    {
        SqlConnection cn;
        SqlCommand cm;
        frmStaffMaintenance f;

        public string _id;
        public frmStaffDepartment(frmStaffMaintenance f)
        {
            InitializeComponent();
            cn = new SqlConnection(dbnconstring.connection);
            this.f = f;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {   //validation for empty field!
                if (MessageBox.Show("Do you want to save this record?", var._title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("insert into tblDepartment (department,dhead)values(@department, @dhead)", cn);
                    cm.Parameters.AddWithValue("@department", txtDepartment.Text);
                    cm.Parameters.AddWithValue("@dhead", txtDHead.Text);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Record has been successfully saved!", var._title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    f.LoadRecord1();
                    Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, var._title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void Clear()
        {
            txtDepartment.Clear();
            txtDHead.Clear();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
            txtDepartment.Focus();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {   //validation for empty field!
                if (MessageBox.Show("Do you want to update this record?", var._title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("update tblDepartment set department=@department, dhead=@dhead where id=@id", cn);
                    cm.Parameters.AddWithValue("@department", txtDepartment.Text);
                    cm.Parameters.AddWithValue("@dhead", txtDHead.Text);
                    cm.Parameters.AddWithValue("@id", _id);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Record has been successfully saved!", var._title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    f.LoadRecord1();
                    this.Dispose();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, var._title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
