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
using System.IO;

namespace NEW_PROJECT_SIMS
{
    public partial class frmDocument : Form
    {
        SqlConnection cn;
        SqlCommand cm;
        SqlDataReader dr;
        


        public frmDocument()
        {
            InitializeComponent();
            cn = new SqlConnection(dbnconstring.connection);
            
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string colname = dataGridView1.Columns[e.ColumnIndex].Name;
                if (colname == "btnEdit")
                {
                    frmAddInv f = new frmAddInv(this);
                    f.Load1();
                    f.Load2();
                    f.Load3();
                    f.Load4();
                    cn.Open();
                    cm = new SqlCommand("select pic as picture, * from tblInventory where id like '" + dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString() + "'", cn);
                    dr = cm.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows)
                    {
                        long len = dr.GetBytes(0, 0, null, 0, 0);
                        byte[] array = new byte[System.Convert.ToInt32(len) + 1];
                        dr.GetBytes(0, 0, array, 0, System.Convert.ToInt32(len));
                        f._id = dr["id"].ToString();
                        f.txtQuantity.Text = dr["quantity"].ToString();
                        f.cboQuality.Text = dr["quality"].ToString();
                        f.txtDescription.Text = dr["description"].ToString();
                        f.txtBrand.Text = dr["brand"].ToString();
                        f.txtModel.Text = dr["model"].ToString();
                        f.txtSerialNo.Text = dr["serialNo"].ToString();
                        f.txtUnitCost.Text = dr["uc"].ToString();
                        f.dtAcqusition.Value = DateTime.Parse(dr["adate"].ToString());
                        f.cboDepartment.Text = dr["dv"].ToString();
                        f.cboDepartment.Text = dr["department"].ToString();
                        f.cboBuilding.Text = dr["building"].ToString();
                        f.cboRoom.Text = dr["room"].ToString();
                        f.cboRecipient.Text = dr["recipient"].ToString();


                        MemoryStream ms = new MemoryStream(array);
                        Bitmap bitmap = new Bitmap(ms);
                        f.picImage.BackgroundImage = bitmap;
                        f.btnSave.Enabled = false;
                    }
                    dr.Close();
                    cn.Close();
                    f.ShowDialog();
                }
                else if (colname == "btnDelete")
                {
                    if (MessageBox.Show("Do you want to delete this record?!", var._title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cn.Open();
                        cm = new SqlCommand("delete from tblInventory where id like '" + dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString() + "' ", cn);
                        cm.ExecuteNonQuery();
                        cn.Close();
                        MessageBox.Show("Record has been successfully deleted!", var._title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadInventory1();
                    }
                }
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, var._title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void LoadInventory1()
        {
            try
            {
                dataGridView1.Rows.Clear();
                cn.Open();
                cm = new SqlCommand("select * from tblInventory where quantity like '%" + txtSearch.Text + "%' or description like '%" + txtSearch.Text + "%' or recipient like '%" + txtSearch.Text + "%'", cn);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    dataGridView1.Rows.Add(dr["id"].ToString(), dr["quantity"].ToString(), dr["quality"].ToString(), dr["status"].ToString(), dr["description"].ToString(), dr["brand"].ToString(),
                        dr["model"].ToString(), dr["serialNo"].ToString(), dr["uc"].ToString(), DateTime.Parse(dr["adate"].ToString()).ToShortDateString(), dr["dv"].ToString(), dr["department"].ToString(), dr["building"].ToString(), dr["room"].ToString(), dr["recipient"].ToString());
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadInventory1();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}

    

