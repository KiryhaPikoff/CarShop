namespace CarShopView
{
    partial class FormReportCars
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
            this.Component = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Car = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Component,
            this.Car,
            this.Count});
            this.dataGridView.Location = new System.Drawing.Point(1, 45);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(379, 612);
            this.dataGridView.TabIndex = 0;
            // 
            // saveToExcelButton
            // 
            this.saveToExcelButton.Location = new System.Drawing.Point(9, 11);
            this.saveToExcelButton.Name = "saveToExcelButton";
            this.saveToExcelButton.Size = new System.Drawing.Size(232, 25);
            this.saveToExcelButton.TabIndex = 1;
            this.saveToExcelButton.Text = "Сохранить в Excel";
            this.saveToExcelButton.UseVisualStyleBackColor = true;
            this.saveToExcelButton.Click += new System.EventHandler(this.saveToExcelButton_Click);
            // 
            // Component
            // 
            this.Component.HeaderText = "Компонент";
            this.Component.Name = "Component";
            this.Component.ReadOnly = true;
            // 
            // Car
            // 
            this.Car.HeaderText = "Машина";
            this.Car.Name = "Car";
            this.Car.ReadOnly = true;
            // 
            // Count
            // 
            this.Count.HeaderText = "Количество";
            this.Count.Name = "Count";
            this.Count.ReadOnly = true;
            // 
            // FormReportCarComponents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 659);
            this.Controls.Add(this.saveToExcelButton);
            this.Controls.Add(this.dataGridView);
            this.Name = "FormReportCarComponents";
            this.Text = "Компоненты по машинам";
            this.Load += new System.EventHandler(this.FormReportCarComponents_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button saveToExcelButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn Component;
        private System.Windows.Forms.DataGridViewTextBoxColumn Car;
        private System.Windows.Forms.DataGridViewTextBoxColumn Count;
    }
}