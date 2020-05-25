namespace CarShopView
{
    partial class FormReportStorageComponents
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.ReportStorageComponentViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toPdfButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ReportStorageComponentViewModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer
            // 
            reportDataSource2.Name = "DataSetStorageComponents";
            reportDataSource2.Value = this.ReportStorageComponentViewModelBindingSource;
            this.reportViewer.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer.LocalReport.ReportEmbeddedResource = "CarShopView.ReportStorageComponents.rdlc";
            this.reportViewer.Location = new System.Drawing.Point(0, 36);
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.ServerReport.BearerToken = null;
            this.reportViewer.Size = new System.Drawing.Size(704, 413);
            this.reportViewer.TabIndex = 0;
            // 
            // ReportStorageComponentViewModelBindingSource
            // 
            this.ReportStorageComponentViewModelBindingSource.DataSource = typeof(CarShopBuisnessLogic.ViewModels.ReportStorageComponentViewModel);
            // 
            // toPdfButton
            // 
            this.toPdfButton.Location = new System.Drawing.Point(592, 2);
            this.toPdfButton.Name = "toPdfButton";
            this.toPdfButton.Size = new System.Drawing.Size(112, 32);
            this.toPdfButton.TabIndex = 2;
            this.toPdfButton.Text = "В Pdf";
            this.toPdfButton.UseVisualStyleBackColor = true;
            this.toPdfButton.Click += new System.EventHandler(this.toPdfButton_Click);
            // 
            // FormReportStorageComponents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 450);
            this.Controls.Add(this.toPdfButton);
            this.Controls.Add(this.reportViewer);
            this.Name = "FormReportStorageComponents";
            this.Text = "Компоненты на складах";
            this.Load += new System.EventHandler(this.FormReportStorageComponents_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ReportStorageComponentViewModelBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
        private System.Windows.Forms.BindingSource ReportStorageComponentViewModelBindingSource;
        private System.Windows.Forms.Button toPdfButton;
    }
}