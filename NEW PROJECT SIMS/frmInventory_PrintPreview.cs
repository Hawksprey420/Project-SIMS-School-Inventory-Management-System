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
            // TODO: This line of code loads data into the 'simsDataSet.tblInventory' table. You can move, or remove it, as needed.
            this.tblInventoryTableAdapter.Fill(this.simsDataSet.tblInventory);

            this.reportViewer1.RefreshReport();
        }
    }
}
