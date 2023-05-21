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
    public partial class frmRecipient : Form
    {
        SqlConnection cn;
        SqlCommand cm;
        frmMaintenance f;
        public string _id;

        public frmRecipient(frmMaintenance f)
        {
            InitializeComponent();
            cn = new SqlConnection(dbnconstring.connection);
            this.f = f;
        }

        private void btnSave2_Click(object sender, EventArgs e)
        {
            try
            {   //validation for empty field!
                if (MessageBox.Show("Do you want to save this record?", var._title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("insert into tblRecipient (RName,position)values(@RName,@position)", cn);
                    cm.Parameters.AddWithValue("@RName", txtRecipient.Text);
                    cm.Parameters.AddWithValue("@position", txtPosition.Text);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Record has been successfully saved!", var._title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    f.LoadRecipient();
                    Clear();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, var._title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnClear2_Click(object sender, EventArgs e)
        {
            Clear();
        }
        private void Clear()
        {
            txtRecipient.Clear();
            txtPosition.Clear();
            btnSave2.Enabled = true;
            btnUpdate2.Enabled = false;
            txtRecipient.Focus();
        }

        private void btnUpdate2_Click(object sender, EventArgs e)
        {
            try
            {   //validation for empty field!
                if (MessageBox.Show("Do you want to update this record?", var._title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("update tblRecipient set RName=@RName, position=@position where id=@id", cn);
                    cm.Parameters.AddWithValue("@RName", txtRecipient.Text);
                    cm.Parameters.AddWithValue("position", txtPosition.Text);
                    cm.Parameters.AddWithValue("@id", _id);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Record has been successfully saved!", var._title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    f.LoadRecipient();
                    this.Dispose();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, var._title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnClose2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
