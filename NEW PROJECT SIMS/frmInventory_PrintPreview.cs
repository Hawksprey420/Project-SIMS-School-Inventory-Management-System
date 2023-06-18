using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEW_PROJECT_SIMS
{
    public partial class frmInventory_PrintPreview : Form
    {
        public frmInventory_PrintPreview()
        {
            InitializeComponent();
        }

        private void frmInventory_PrintPreview_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'simsDataSet.tblRecipient' table. You can move, or remove it, as needed.
            this.tblRecipientTableAdapter.Fill(this.simsDataSet.tblRecipient);
            // TODO: This line of code loads data into the 'simsDataSet.tblInventory' table. You can move, or remove it, as needed.
            this.tblInventoryTableAdapter.Fill(this.simsDataSet.tblInventory);

            this.reportViewer1.RefreshReport();
        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.tblRecipientTableAdapter.FillBy(this.simsDataSet.tblRecipient);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.simsDataSet.EnforceConstraints = false;
        



            // TODO: This line of code loads data into the 'simsDataSet.tblRecipient' table. You can move, or remove it, as needed.
            this.tblRecipientTableAdapter.Fill(this.simsDataSet.tblRecipient);
            // TODO: This line of code loads data into the 'simsDataSet.tblInventory' table. You can move, or remove it, as needed.
            this.tblInventoryTableAdapter.Fill(this.simsDataSet.tblInventory);

            this.reportViewer1.RefreshReport();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
