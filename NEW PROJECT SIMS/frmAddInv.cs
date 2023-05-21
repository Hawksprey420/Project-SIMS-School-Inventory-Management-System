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

    public partial class frmAddInv : Form
    {
        SqlConnection cn;
        SqlCommand cm;
        SqlDataReader dr;
        frmInventory f;
        frmDocument d;
      
        
        public string _id;

        public frmAddInv(frmInventory f)
        {
            InitializeComponent();
            cn = new SqlConnection(dbnconstring.connection);
            this.f = f;
            Load1();
            Load2();
            Load3();
            Load4();

        }
        public frmAddInv(frmDocument d)
        {
            InitializeComponent();
            cn = new SqlConnection(dbnconstring.connection);
            this.d = d;
            Load1();
            Load2();
            Load3();
            Load4();
        }
   

        public void Load1()
        {
            try
            {
                cboDepartment.Items.Clear();
                cn.Open();
                cm = new SqlCommand("select * from tblDepartment", cn);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    cboDepartment.Items.Add(dr["department"].ToString());
                }
                dr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, var._title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void Load2()
        {
            try
            {
                cboBuilding.Items.Clear();
                cn.Open();
                cm = new SqlCommand("select * from tblBuilding", cn);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    cboBuilding.Items.Add(dr["building"].ToString());
                }
                dr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, var._title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void Load3()
        {
            try
            {
                cboRoom.Items.Clear();
                cn.Open();
                cm = new SqlCommand("select * from tblRoom", cn);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    cboRoom.Items.Add(dr["room"].ToString());
                }
                dr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, var._title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void Load4()
        {
            try
            {
                cboRecipient.Items.Clear();
                cn.Open();
                cm = new SqlCommand("select * from tblRecipient", cn);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    cboRecipient.Items.Add(dr["RName"].ToString());
                }
                dr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, var._title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtUnitCost_TextChanged(object sender, EventArgs e)
        {
            decimal unitCost = 0m;
            if (decimal.TryParse(txtUnitCost.Text, out unitCost))
            {
                decimal residualValue = unitCost * 0.05m;
                decimal usefulLifeInMonths = 20 * 12;
                if (usefulLifeInMonths == 0)
                {
                    MessageBox.Show("Error: The useful life in months cannot be zero.");
                    txtUnitCost.Text = "";
                    return;
                }
                decimal monthlyDepreciation = (unitCost - residualValue) / usefulLifeInMonths;
                txtDV.Text = "P" + monthlyDepreciation.ToString("N2");
            }
            else
            {
                txtDV.Text = "";
            }

            txtDV.ReadOnly = true;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //validation for empty field 
                if (MessageBox.Show("Do you want to save this record?", var._title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    MemoryStream ms = new MemoryStream();
                    picImage.BackgroundImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    byte[] arrImage = ms.GetBuffer();
                    cn.Open();
                    cm = new SqlCommand("insert into tblInventory (quantity, quality, status, description, brand, model, serialNo, uc, adate, dv, department, building, room, recipient, pic)values" +
                        "(@quantity, @quality, @status, @description, @brand, @model, @serialNo, @uc, @adate, @dv, @department, @building, @room, @recipient, @pic)", cn);
                    cm.Parameters.AddWithValue("@quantity", txtQuantity.Text);
                    cm.Parameters.AddWithValue("@quality", cboQuality.Text);
                    cm.Parameters.AddWithValue("status", cboStatus.Text);
                    cm.Parameters.AddWithValue("@description", txtDescription.Text);
                    cm.Parameters.AddWithValue("@brand", txtBrand.Text);
                    cm.Parameters.AddWithValue("@model", txtModel.Text);
                    cm.Parameters.AddWithValue("@serialNo", txtSerialNo.Text);
                    cm.Parameters.AddWithValue("@uc", txtUnitCost.Text);
                    cm.Parameters.AddWithValue("@adate", dtAcqusition.Value);
                    cm.Parameters.AddWithValue("@dv", txtDV.Text);
                    cm.Parameters.AddWithValue("@department", cboDepartment.Text);
                    cm.Parameters.AddWithValue("@building", cboBuilding.Text);
                    cm.Parameters.AddWithValue("@room", cboRoom.Text);
                    cm.Parameters.AddWithValue("@recipient", cboRecipient.Text);
                    cm.Parameters.AddWithValue("@pic", arrImage);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Record has been successfully saved", var._title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    f.LoadInventory();
                    Clear();
                 
                }
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, var._title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
        public void Clear()
        {
            picImage.BackgroundImage = Image.FromFile(Application.StartupPath + @"\PNS.jpeg");
            txtQuantity.Clear();
            cboQuality.Text = "";
            cboStatus.Text = "";
            txtDescription.Clear();
            txtBrand.Clear();
            txtModel.Clear();
            txtSerialNo.Clear();
            txtUnitCost.Clear();
            dtAcqusition.Value = DateTime.Now;
            txtDV.Clear();
            cboDepartment.Text = "";
            cboBuilding.Text = "";
            cboRoom.Text = "";
            cboRecipient.Text = "";
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
            txtQuantity.Clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                //validation for empty
                if (MessageBox.Show("Do you want to update this record?", var._title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    MemoryStream ms = new MemoryStream();
                    picImage.BackgroundImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    byte[] arrImage = ms.GetBuffer();
                    cn.Open();
                    cm = new SqlCommand("update tblInventory set quantity=@quantity, quality=@quality, status=@status, description=@description, brand=@brand, model=@model, serialNo=@serialNo, uc=@uc, adate=@adate, dv=@dv, department=@department, building=@building, room=@room, recipient=@recipient, pic=@pic where id =@id", cn);
                    cm.Parameters.AddWithValue("quantity", txtQuantity.Text);
                    cm.Parameters.AddWithValue("quality", cboQuality.Text);
                    cm.Parameters.AddWithValue("status", cboStatus.Text);
                    cm.Parameters.AddWithValue("description", txtDescription.Text);
                    cm.Parameters.AddWithValue("brand", txtBrand.Text);
                    cm.Parameters.AddWithValue("model", txtModel.Text);
                    cm.Parameters.AddWithValue("serialNo", txtSerialNo.Text);
                    cm.Parameters.AddWithValue("uc", txtUnitCost.Text);
                    cm.Parameters.AddWithValue("adate", dtAcqusition.Value);
                    cm.Parameters.AddWithValue("dv", txtDV.Text);
                    cm.Parameters.AddWithValue("department", cboDepartment.Text);
                    cm.Parameters.AddWithValue("building", cboBuilding.Text);
                    cm.Parameters.AddWithValue("room", cboRoom.Text);
                    cm.Parameters.AddWithValue("recipient", cboRecipient.Text);
                    cm.Parameters.AddWithValue("pic", arrImage);
                    cm.Parameters.AddWithValue("@id", _id);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Record has been successfully updated!", var._title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    f.LoadInventory();
                    this.Dispose();
                }
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, var._title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnPic_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.Filter = "Image Files (*.png)|*.png|(*.jpg)|*.jpg|(*.gif)|*.gif";
                openFileDialog1.ShowDialog();
                picImage.BackgroundImage = Image.FromFile(openFileDialog1.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, var._title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
