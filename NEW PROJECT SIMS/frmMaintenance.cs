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
    public partial class frmMaintenance : Form
    {
        SqlConnection cn;
        SqlCommand cm;
        SqlDataReader dr;
        

        public frmMaintenance()
        {
            InitializeComponent();
            cn = new SqlConnection(dbnconstring.connection);
        }
      

        private void btnAddnew1_Click(object sender, EventArgs e)
        {
            frmDepartment f = new frmDepartment(this);
            f.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void LoadRecord()
        {
           
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
      
 

        public void LoadBuilding()
        {
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

        public void LoadRecipient()
        {

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
        public void LoadUser()
        {
            try
            {
                dataGridView5.Rows.Clear();
                cn.Open();
                cm = new SqlCommand("select * from tblUser", cn);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    dataGridView5.Rows.Add(dr["username"].ToString(), dr["password"].ToString(), dr["position"].ToString(), dr["status"].ToString());
                }
                dr.Close();
                cn.Close();
                dataGridView5.ClearSelection();
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, var._title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAddnew1_Click_1(object sender, EventArgs e)
        {
            frmDepartment f = new frmDepartment(this);
            f.Show();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string colName = dataGridView1.Columns[e.ColumnIndex].Name;
                if (colName == "btnEdit")
                {
                    frmDepartment f = new frmDepartment(this);
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
                        LoadRecord();
                    }
                }
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, var._title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void LoadHead()
        {
            try
            {
                dataGridView1.Rows.Clear();
                cn.Open();
                cm = new SqlCommand("select * from tblDepartment where department like '%" + txtSearch.Text + "%' or dhead like '%" + txtSearch.Text + "%'", cn);
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

        public void LoadB()
        {
            try
            {
                dataGridView3.Rows.Clear();
                cn.Open();
                cm = new SqlCommand("select * from tblBuilding where buildingNo like '%" + txtSearch1.Text + "%' or building like '%" + txtSearch1.Text + "%'", cn);
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

        public void LoadR()
        {
            try
            {
                dataGridView4.Rows.Clear();
                cn.Open();
                cm = new SqlCommand("select * from tblRecipient where RName like '%" + txtSearch2.Text + "%' or position like '%" + txtSearch2.Text + "%'", cn);
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

        public void LoadU()
        {         
            try
            {
                dataGridView5.Rows.Clear();
                cn.Open();
                cm = new SqlCommand("select * from tblUser where username like '%" + txtSearch3.Text + "%' or position like '%" + txtSearch3.Text + "%' or status like '" + txtSearch3.Text + "%'", cn);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    dataGridView5.Rows.Add(dr["id"].ToString(), dr["username"].ToString(), dr["password"].ToString(), dr["position"].ToString(), dr["status"].ToString());
                }
                dr.Close();
                cn.Close();
                dataGridView5.ClearSelection();
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, var._title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void LoadRoom()
        {
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
           

        private void LoadRM()
        {
            try
            {
                dataGridView6.Rows.Clear();
                cn.Open();
                cm = new SqlCommand("select * from tblRoom where room like '%" + txtsearch5.Text + "%'", cn);
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

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            LoadHead();
        }

        private void btnAddNew2_Click_1(object sender, EventArgs e)
        {
            frmBuilding f = new frmBuilding(this);
            f.Show();
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string colName = dataGridView3.Columns[e.ColumnIndex].Name;
                if (colName == "btnEdit1")
                {
                    frmBuilding f = new frmBuilding(this);
                    f.btnSave1.Enabled = false;
                    f._id = dataGridView3.Rows[e.RowIndex].Cells[0].Value.ToString();
                    f.txtBuildingNo.Text = dataGridView3.Rows[e.RowIndex].Cells[1].Value.ToString();
                    f.txtBuilding.Text = dataGridView3.Rows[e.RowIndex].Cells[2].Value.ToString();
                    f.ShowDialog();
                }
                else if (colName == "btnDelete1")
                {
                    if (MessageBox.Show("Do you want to delete this record?", var._title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cn.Open();
                        cm = new SqlCommand("delete from tblBuilding where id like '" + dataGridView3.Rows[e.RowIndex].Cells[0].Value.ToString() + "' ", cn);
                        cm.ExecuteNonQuery();
                        cn.Close();
                        MessageBox.Show("Record has been successfully deleted!", var._title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadBuilding();
                    }

                }
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, var._title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {
            LoadHead();
        }

        private void txtSearch1_TextChanged(object sender, EventArgs e)
        {
            LoadB();
        }

        private void btnAddNew3_Click(object sender, EventArgs e)
        {
            frmRecipient f = new frmRecipient(this);
            f.Show();
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string colName = dataGridView4.Columns[e.ColumnIndex].Name;
                if (colName == "btnEdit2")
                {
                    frmRecipient f = new frmRecipient(this);
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
                        LoadRecipient();
                    }

                }
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, var._title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtSearch2_TextChanged(object sender, EventArgs e)
        {
            LoadR();
        }

        private void txtSearch3_TextChanged(object sender, EventArgs e)
        {
            LoadU();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmUser f = new frmUser(this);
            LoadU();
            f.Show();
        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string colName = dataGridView5.Columns[e.ColumnIndex].Name;
                if (colName == "btnEdit3")
                {
                    frmUser f = new frmUser(this);
                    f.btnSave3.Enabled = false;
                    f._id = dataGridView5.Rows[e.RowIndex].Cells[0].Value.ToString();
                    f.txtUser.Text = dataGridView5.Rows[e.RowIndex].Cells[1].Value.ToString();
                    f.txtPass.Text = dataGridView5.Rows[e.RowIndex].Cells[2].Value.ToString();
                    f.cboPosition.Text = dataGridView5.Rows[e.RowIndex].Cells[3].Value.ToString();
                    f.cboStatus.Text = dataGridView5.Rows[e.RowIndex].Cells[4].Value.ToString();
                    f.ShowDialog();
                }
                else if (colName == "btnDelete3")
                {
                    if (MessageBox.Show("Do you want to delete this record?", var._title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cn.Open();
                        cm = new SqlCommand("delete from tblUser where id like '" + dataGridView5.Rows[e.RowIndex].Cells[0].Value.ToString() + "'", cn);
                        cm.ExecuteNonQuery();
                        cn.Close();
                        MessageBox.Show("Record has been successfully deleted!", var._title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadU();
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
            frmRoom f = new frmRoom(this);
            f.Show();
        }

        private void txtsearch5_Click(object sender, EventArgs e)
        {
            LoadRM();
        }

        private void dataGridView6_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string colName = dataGridView6.Columns[e.ColumnIndex].Name;
                if (colName == "btnEdit4")
                {
                    frmRoom f = new frmRoom(this);
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
                        LoadRoom();
                    }

                }
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, var._title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtsearch5_TextChanged(object sender, EventArgs e)
        {
            LoadRM();
        }
    }
}










