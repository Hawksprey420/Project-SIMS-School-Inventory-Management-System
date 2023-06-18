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
            this.tblInventoryBindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this.simsDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.simsDataSet = new NEW_PROJECT_SIMS.simsDataSet();
            this.tblInventoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tblInventoryTableAdapter = new NEW_PROJECT_SIMS.simsDataSetTableAdapters.tblInventoryTableAdapter();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tblInventoryBindingSource4 = new System.Windows.Forms.BindingSource(this.components);
            this.tblRecipientBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.tblRecipientBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.tblRecipientBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tblInventoryBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.tblRecipientTableAdapter = new NEW_PROJECT_SIMS.simsDataSetTableAdapters.tblRecipientTableAdapter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.tblInventoryBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.tblRecipientBindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this.tblRecipientBindingSource4 = new System.Windows.Forms.BindingSource(this.components);
            this.tblRecipientBindingSource5 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.tblInventoryBindingSource3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simsDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simsDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblInventoryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblInventoryBindingSource4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblRecipientBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblRecipientBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblRecipientBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblInventoryBindingSource1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblInventoryBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblRecipientBindingSource3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblRecipientBindingSource4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblRecipientBindingSource5)).BeginInit();
            this.SuspendLayout();
            // 
            // tblInventoryBindingSource3
            // 
            this.tblInventoryBindingSource3.DataMember = "tblInventory";
            this.tblInventoryBindingSource3.DataSource = this.simsDataSetBindingSource;
            // 
            // simsDataSetBindingSource
            // 
            this.simsDataSetBindingSource.DataSource = this.simsDataSet;
            this.simsDataSetBindingSource.Position = 0;
            // 
            // simsDataSet
            // 
            this.simsDataSet.DataSetName = "simsDataSet";
            this.simsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tblInventoryBindingSource
            // 
            this.tblInventoryBindingSource.DataMember = "tblInventory";
            this.tblInventoryBindingSource.DataSource = this.simsDataSetBindingSource;
            // 
            // reportViewer1
            // 
            this.reportViewer1.AutoSize = true;
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.tblInventoryBindingSource3;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "NEW_PROJECT_SIMS.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 51);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1014, 536);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // tblInventoryTableAdapter
            // 
            this.tblInventoryTableAdapter.ClearBeforeFill = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Variable Static Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select inventory recipient";
            // 
            // comboBox1
            // 
            this.comboBox1.DataSource = this.tblInventoryBindingSource4;
            this.comboBox1.DisplayMember = "recipient";
            this.comboBox1.Font = new System.Drawing.Font("Segoe UI Variable Static Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(203, 14);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(266, 29);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // tblInventoryBindingSource4
            // 
            this.tblInventoryBindingSource4.DataMember = "tblInventory";
            this.tblInventoryBindingSource4.DataSource = this.simsDataSetBindingSource;
            // 
            // tblRecipientBindingSource2
            // 
            this.tblRecipientBindingSource2.DataMember = "tblRecipient";
            this.tblRecipientBindingSource2.DataSource = this.simsDataSetBindingSource;
            // 
            // tblRecipientBindingSource1
            // 
            this.tblRecipientBindingSource1.DataMember = "tblRecipient";
            this.tblRecipientBindingSource1.DataSource = this.simsDataSetBindingSource;
            // 
            // tblRecipientBindingSource
            // 
            this.tblRecipientBindingSource.DataMember = "tblRecipient";
            this.tblRecipientBindingSource.DataSource = this.simsDataSetBindingSource;
            // 
            // tblInventoryBindingSource1
            // 
            this.tblInventoryBindingSource1.DataMember = "tblInventory";
            this.tblInventoryBindingSource1.DataSource = this.simsDataSetBindingSource;
            // 
            // tblRecipientTableAdapter
            // 
            this.tblRecipientTableAdapter.ClearBeforeFill = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1014, 51);
            this.panel1.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(475, 18);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Refresh report";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tblInventoryBindingSource2
            // 
            this.tblInventoryBindingSource2.DataMember = "tblInventory";
            this.tblInventoryBindingSource2.DataSource = this.simsDataSetBindingSource;
            // 
            // tblRecipientBindingSource3
            // 
            this.tblRecipientBindingSource3.DataMember = "tblRecipient";
            this.tblRecipientBindingSource3.DataSource = this.simsDataSetBindingSource;
            // 
            // tblRecipientBindingSource4
            // 
            this.tblRecipientBindingSource4.DataMember = "tblRecipient";
            this.tblRecipientBindingSource4.DataSource = this.simsDataSetBindingSource;
            // 
            // tblRecipientBindingSource5
            // 
            this.tblRecipientBindingSource5.DataMember = "tblRecipient";
            this.tblRecipientBindingSource5.DataSource = this.simsDataSetBindingSource;
            // 
            // frmInventory_PrintPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 587);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.panel1);
            this.Name = "frmInventory_PrintPreview";
            this.Text = "frmInventory_PrintPreview";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmInventory_PrintPreview_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tblInventoryBindingSource3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simsDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simsDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblInventoryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblInventoryBindingSource4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblRecipientBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblRecipientBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblRecipientBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblInventoryBindingSource1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblInventoryBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblRecipientBindingSource3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblRecipientBindingSource4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblRecipientBindingSource5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource simsDataSetBindingSource;
        private simsDataSet simsDataSet;
        private System.Windows.Forms.BindingSource tblInventoryBindingSource;
        private simsDataSetTableAdapters.tblInventoryTableAdapter tblInventoryTableAdapter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.BindingSource tblRecipientBindingSource1;
        private System.Windows.Forms.BindingSource tblRecipientBindingSource;
        private System.Windows.Forms.BindingSource tblInventoryBindingSource1;
        private System.Windows.Forms.BindingSource tblRecipientBindingSource2;
        private simsDataSetTableAdapters.tblRecipientTableAdapter tblRecipientTableAdapter;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.BindingSource tblInventoryBindingSource2;
        private System.Windows.Forms.BindingSource tblInventoryBindingSource3;
        private System.Windows.Forms.BindingSource tblRecipientBindingSource4;
        private System.Windows.Forms.BindingSource tblRecipientBindingSource3;
        private System.Windows.Forms.BindingSource tblRecipientBindingSource5;
        private System.Windows.Forms.BindingSource tblInventoryBindingSource4;
    }
}