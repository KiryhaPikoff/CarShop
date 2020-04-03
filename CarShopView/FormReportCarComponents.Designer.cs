namespace CarShopView
{
    partial class FormReportCarComponents
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
            this.ReportCarComponentViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.toPdfButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ReportCarComponentViewModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ReportCarComponentViewModelBindingSource
            // 
            this.ReportCarComponentViewModelBindingSource.DataSource = typeof(CarShopBuisnessLogic.ViewModels.ReportCarComponentViewModel);
            // 
            // reportViewer
            // 
            reportDataSource1.Name = "DataSetCarComp";
            reportDataSource1.Value = this.ReportCarComponentViewModelBindingSource;
            this.reportViewer.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer.LocalReport.ReportEmbeddedResource = "CarShopView.ReportCarComponents.rdlc";
            this.reportViewer.Location = new System.Drawing.Point(2, 42);
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.ServerReport.BearerToken = null;
            this.reportViewer.Size = new System.Drawing.Size(636, 407);
            this.reportViewer.TabIndex = 0;
            // 
            // toPdfButton
            // 
            this.toPdfButton.Location = new System.Drawing.Point(514, 4);
            this.toPdfButton.Name = "toPdfButton";
            this.toPdfButton.Size = new System.Drawing.Size(112, 32);
            this.toPdfButton.TabIndex = 1;
            this.toPdfButton.Text = "В Pdf";
            this.toPdfButton.UseVisualStyleBackColor = true;
            this.toPdfButton.Click += new System.EventHandler(this.toPdfButton_Click);
            // 
            // FormReportCarComponents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 450);
            this.Controls.Add(this.toPdfButton);
            this.Controls.Add(this.reportViewer);
            this.Name = "FormReportCarComponents";
            this.Text = "Машины и компоненты";
            this.Load += new System.EventHandler(this.FormReportCarComponents_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ReportCarComponentViewModelBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
        private System.Windows.Forms.BindingSource ReportCarComponentViewModelBindingSource;
        private System.Windows.Forms.Button toPdfButton;
    }
}