namespace CarShopView
{
    partial class FormReportStorages
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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.saveToExcelButton = new System.Windows.Forms.Button();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.car = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.date,
            this.car,
            this.count});
            this.dataGridView.Location = new System.Drawing.Point(0, 39);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(345, 610);
            this.dataGridView.TabIndex = 4;
            // 
            // saveToExcelButton
            // 
            this.saveToExcelButton.Location = new System.Drawing.Point(12, 8);
            this.saveToExcelButton.Name = "saveToExcelButton";
            this.saveToExcelButton.Size = new System.Drawing.Size(123, 25);
            this.saveToExcelButton.TabIndex = 3;
            this.saveToExcelButton.Text = "Сохранить в Excel";
            this.saveToExcelButton.UseVisualStyleBackColor = true;
            this.saveToExcelButton.Click += new System.EventHandler(this.saveToExcelButton_Click);
            // 
            // date
            // 
            this.date.HeaderText = "Склад";
            this.date.Name = "date";
            // 
            // car
            // 
            this.car.HeaderText = "Компонент";
            this.car.Name = "car";
            // 
            // count
            // 
            this.count.HeaderText = "Количество";
            this.count.Name = "count";
            // 
            // FormReportStorages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 658);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.saveToExcelButton);
            this.Name = "FormReportStorages";
            this.Text = "Склады и компоненты";
            this.Load += new System.EventHandler(this.FormReportStorages_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button saveToExcelButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.DataGridViewTextBoxColumn car;
        private System.Windows.Forms.DataGridViewTextBoxColumn count;
    }
}