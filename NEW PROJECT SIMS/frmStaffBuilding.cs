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
    public partial class frmStaffBuilding : Form
    {
        SqlConnection cn;
        SqlCommand cm;
        frmStaffMaintenance f;
        public string _id;

        public frmStaffBuilding(frmStaffMaintenance f)
        {
            InitializeComponent();
            cn = new SqlConnection(dbnconstring.connection);
            this.f = f;
        }

        private void btnSave1_Click(object sender, EventArgs e)
        {
            try
            {   //validation for empty field!
                if (MessageBox.Show("Do you want to save this record?", var._title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("insert into tblBuilding (buildingNo,building)values (@buildingNo,@building)", cn);
                    cm.Parameters.AddWithValue("@buildingNo", txtBuildingNo.Text);
                    cm.Parameters.AddWithValue("@building", txtBuilding.Text);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Record has been successfully saved!", var._title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    f.LoadBuilding1();
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
            txtBuildingNo.Clear();
            txtBuilding.Clear();
            btnSave1.Enabled = true;
            btnUpdate1.Enabled = false;
            txtBuildingNo.Focus();
        }

        private void btnUpdate1_Click(object sender, EventArgs e)
        {
            try
            {   //validation for empty field!
                if (MessageBox.Show("Do you want to update this record?", var._title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("update tblBuilding set buildingNo=@buildingNo, building=@building where id=@id", cn);
                    cm.Parameters.AddWithValue("@buildingNo", txtBuildingNo.Text);
                    cm.Parameters.AddWithValue("@building", txtBuilding.Text);
                    cm.Parameters.AddWithValue("@id", _id);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Record has been successfully saved!", var._title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    f.LoadBuilding1();
                    this.Dispose();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, var._title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnClear1_Click(object sender, EventArgs e)
        {

        }

        private void btnClose1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
