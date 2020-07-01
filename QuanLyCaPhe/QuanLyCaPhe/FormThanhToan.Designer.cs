namespace QuanLyCaPhe
{
    partial class FormThanhToan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormThanhToan));
            this.ChiTietHoaDon_ReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.QuanLyCaPheDataSet = new QuanLyCaPhe.QuanLyCaPheDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.ChiTietHoaDon_ReportTableAdapter = new QuanLyCaPhe.QuanLyCaPheDataSetTableAdapters.ChiTietHoaDon_ReportTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.ChiTietHoaDon_ReportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuanLyCaPheDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // ChiTietHoaDon_ReportBindingSource
            // 
            this.ChiTietHoaDon_ReportBindingSource.DataMember = "ChiTietHoaDon_Report";
            this.ChiTietHoaDon_ReportBindingSource.DataSource = this.QuanLyCaPheDataSet;
            // 
            // QuanLyCaPheDataSet
            // 
            this.QuanLyCaPheDataSet.DataSetName = "QuanLyCaPheDataSet";
            this.QuanLyCaPheDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.ChiTietHoaDon_ReportBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QuanLyCaPhe.Report2.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(600, 499);
            this.reportViewer1.TabIndex = 0;
            // 
            // ChiTietHoaDon_ReportTableAdapter
            // 
            this.ChiTietHoaDon_ReportTableAdapter.ClearBeforeFill = true;
            // 
            // FormThanhToan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 499);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormThanhToan";
            this.Text = "In Thông Tin Hóa Đơn";
            this.Load += new System.EventHandler(this.FormThanhToan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ChiTietHoaDon_ReportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuanLyCaPheDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource ChiTietHoaDon_ReportBindingSource;
        private QuanLyCaPheDataSet QuanLyCaPheDataSet;
        private QuanLyCaPheDataSetTableAdapters.ChiTietHoaDon_ReportTableAdapter ChiTietHoaDon_ReportTableAdapter;
    }
}