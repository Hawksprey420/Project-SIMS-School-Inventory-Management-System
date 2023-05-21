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
    public partial class frmStaffMaintenance : Form
    {
        SqlConnection cn;
        SqlCommand cm;
        SqlDataReader dr;
        
        public frmStaffMaintenance()
        {
            InitializeComponent();
            cn = new SqlConnection(dbnconstring.connection);
        }

        private void btnAddnew1_Click(object sender, EventArgs e)
        {
            frmStaffDepartment f = new frmStaffDepartment(this);
            f.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        public void LoadRecord1()
        {

            frmStaff f = new frmStaff();
            try
            {
                dataGridView1.Rows.Clear();
                cn.Open();
                cm = new SqlCommand("select * from tblDepartment", cn);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    dataGridView1.Rows.Add(dr["id"].ToString(), dr["department"].ToString(), dr["dhead"].ToString());
                }
                dr.Close();
                cn.Close();
                dataGridView1.ClearSelection();
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, var._title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        public void LoadBuilding1()
        {
            frmStaff f = new frmStaff();
            try
            {
                dataGridView3.Rows.Clear();
                cn.Open();
                cm = new SqlCommand("select * from tblBuilding", cn);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    dataGridView3.Rows.Add(dr["id"].ToString(), dr["buildingNo"].ToString(), dr["building"].ToString());
                }
                dr.Close();
                cn.Close();
                dataGridView3.ClearSelection();
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, var._title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void LoadRecipient1()
        {
            frmStaff f = new frmStaff();
            try
            {
                dataGridView4.Rows.Clear();
                cn.Open();
                cm = new SqlCommand("select * from tblRecipient", cn);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    dataGridView4.Rows.Add(dr["id"].ToString(), dr["RName"].ToString(), dr["position"].ToString());
                }
                dr.Close();
                cn.Close();
                dataGridView4.ClearSelection();
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, var._title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void LoadRoom1()
        {
            frmStaff f = new frmStaff();
            try
            {
                dataGridView6.Rows.Clear();
                cn.Open();
                cm = new SqlCommand("select * from tblRoom", cn);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    dataGridView6.Rows.Add(dr["id"].ToString(), dr["room"].ToString());
                }
                dr.Close();
                cn.Close();
                dataGridView6.ClearSelection();
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, var._title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string colName = dataGridView1.Columns[e.ColumnIndex].Name;
                if (colName == "btnEdit")
                {
                    frmStaffDepartment f = new frmStaffDepartment(this);
                    f.btnSave.Enabled = false;
                    f._id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    f.txtDepartment.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    f.txtDHead.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                    f.ShowDialog();
                }
                else if (colName == "btnDelete")
                {
                    if (MessageBox.Show("Do you want to delete this record?", var._title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cn.Open();
                        cm = new SqlCommand("delete from tblDepartment where id like '" + dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString() + "' ", cn);
                        cm.ExecuteNonQuery();
                        cn.Close();
                        MessageBox.Show("Record has been successfully deleted!", var._title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadRecord1();
                    }
                }
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, var._title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAddNew2_Click(object sender, EventArgs e)
        {
            frmStaffBuilding f = new frmStaffBuilding(this);
            f.Show();
        }

        private void btnAddNew3_Click(object sender, EventArgs e)
        {
            frmStaffRecipient f = new frmStaffRecipient(this);
            f.Show();
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string colName = dataGridView4.Columns[e.ColumnIndex].Name;
                if (colName == "btnEdit2")
                {
                    frmStaffRecipient f = new frmStaffRecipient(this);
                    f.btnSave2.Enabled = false;
                    f._id = dataGridView4.Rows[e.RowIndex].Cells[0].Value.ToString();
                    f.txtRecipient.Text = dataGridView4.Rows[e.RowIndex].Cells[1].Value.ToString();
                    f.txtPosition.Text = dataGridView4.Rows[e.RowIndex].Cells[2].Value.ToString();
                    f.ShowDialog();
                }
                else if (colName == "btnDelete2")
                {
                    if (MessageBox.Show("Do you want to delete this record?", var._title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cn.Open();
                        cm = new SqlCommand("delete from tblRecipient where id like '" + dataGridView4.Rows[e.RowIndex].Cells[0].Value.ToString() + "' ", cn);
                        cm.ExecuteNonQuery();
                        cn.Close();
                        MessageBox.Show("Record has been successfully deleted!", var._title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadRecipient1();
                    }

                }
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, var._title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridView6_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string colName = dataGridView6.Columns[e.ColumnIndex].Name;
                if (colName == "btnEdit4")
                {
                    frmStaffRoom f = new frmStaffRoom(this);
                    f.btnSave4.Enabled = false;
                    f._id = dataGridView6.Rows[e.RowIndex].Cells[0].Value.ToString();
                    f.txtRoom.Text = dataGridView6.Rows[e.RowIndex].Cells[1].Value.ToString();
                    f.ShowDialog();
                }
                else if (colName == "btnDelete4")
                {
                    if (MessageBox.Show("Do you want to delete this record?", var._title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cn.Open();
                        cm = new SqlCommand("delete from tblRoom where id like '" + dataGridView6.Rows[e.RowIndex].Cells[0].Value.ToString() + "' ", cn);
                        cm.ExecuteNonQuery();
                        cn.Close();
                        MessageBox.Show("Record has been successfully deleted!", var._title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadRoom1();
                    }

                }
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, var._title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmStaffRoom f = new frmStaffRoom(this);
            f.Show();
        }
    }
}
