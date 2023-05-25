namespace NEW_PROJECT_SIMS
{
    partial class frmInventory_PrintPreview
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.simsDataSet = new NEW_PROJECT_SIMS.simsDataSet();
            this.simsDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.simsDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simsDataSetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.simsDataSetBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "NEW_PROJECT_SIMS.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1014, 587);
            this.reportViewer1.TabIndex = 0;
            // 
            // simsDataSet
            // 
            this.simsDataSet.DataSetName = "simsDataSet";
            this.simsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // simsDataSetBindingSource
            // 
            this.simsDataSetBindingSource.DataSource = this.simsDataSet;
            this.simsDataSetBindingSource.Position = 0;
            // 
            // frmInventory_PrintPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 587);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmInventory_PrintPreview";
            this.Text = "frmInventory_PrintPreview";
            this.Load += new System.EventHandler(this.frmInventory_PrintPreview_Load);
            ((System.ComponentModel.ISupportInitialize)(this.simsDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simsDataSetBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource simsDataSetBindingSource;
        private simsDataSet simsDataSet;
    }
}