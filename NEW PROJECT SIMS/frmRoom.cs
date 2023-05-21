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
    public partial class frmRoom : Form
    {
        SqlConnection cn;
        SqlCommand cm;
        frmMaintenance f;
        public string _id;

        public frmRoom(frmMaintenance f)
        {
            InitializeComponent();
            cn = new SqlConnection(dbnconstring.connection);
            this.f = f;
        }

        private void btnSave4_Click(object sender, EventArgs e)
        {
            try
            {   //validation for empty field!
                if (MessageBox.Show("Do you want to save this record?", var._title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("insert into tblRoom(room)values(@room)", cn);
                    cm.Parameters.AddWithValue("@room", txtRoom.Text);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Record has been successfully saved!", var._title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    f.LoadRoom();
                    Clear();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, var._title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnClear4_Click(object sender, EventArgs e)
        {
            Clear();
        }
        private void Clear()
        {
            txtRoom.Clear();
            btnSave4.Enabled = true;
            btnUpdate4.Enabled = false;
            txtRoom.Focus();
        }

        private void btnUpdate4_Click(object sender, EventArgs e)
        {
            try
            {   //validation for empty field!
                if (MessageBox.Show("Do you want to update this record?", var._title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("update tblRoom set room=@room where id=@id", cn);
                    cm.Parameters.AddWithValue("@room", txtRoom.Text);
                    cm.Parameters.AddWithValue("@id", _id);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Record has been successfully saved!", var._title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    f.LoadRoom();
                    this.Dispose();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, var._title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnClose4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
