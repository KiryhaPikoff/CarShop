namespace CarShopView
{
    partial class FormCars
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
            this.createCarButton = new System.Windows.Forms.Button();
            this.updateCarButton = new System.Windows.Forms.Button();
            this.deleteCarButton = new System.Windows.Forms.Button();
            this.refreshButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(0, 0);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(406, 399);
            this.dataGridView.TabIndex = 0;
            // 
            // createCarButton
            // 
            this.createCarButton.Location = new System.Drawing.Point(419, 18);
            this.createCarButton.Name = "createCarButton";
            this.createCarButton.Size = new System.Drawing.Size(75, 23);
            this.createCarButton.TabIndex = 1;
            this.createCarButton.Text = "Добавить";
            this.createCarButton.UseVisualStyleBackColor = true;
            this.createCarButton.Click += new System.EventHandler(this.createCarButton_Click);
            // 
            // updateCarButton
            // 
            this.updateCarButton.Location = new System.Drawing.Point(418, 56);
            this.updateCarButton.Name = "updateCarButton";
            this.updateCarButton.Size = new System.Drawing.Size(75, 23);
            this.updateCarButton.TabIndex = 2;
            this.updateCarButton.Text = "Изменить";
            this.updateCarButton.UseVisualStyleBackColor = true;
            this.updateCarButton.Click += new System.EventHandler(this.updateCarButton_Click);
            // 
            // deleteCarButton
            // 
            this.deleteCarButton.Location = new System.Drawing.Point(418, 96);
            this.deleteCarButton.Name = "deleteCarButton";
            this.deleteCarButton.Size = new System.Drawing.Size(75, 23);
            this.deleteCarButton.TabIndex = 3;
            this.deleteCarButton.Text = "Удалить";
            this.deleteCarButton.UseVisualStyleBackColor = true;
            this.deleteCarButton.Click += new System.EventHandler(this.deleteCarButton_Click);
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(418, 162);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(75, 38);
            this.refreshButton.TabIndex = 4;
            this.refreshButton.Text = "Обновить список";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // FormCars
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 399);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.deleteCarButton);
            this.Controls.Add(this.updateCarButton);
            this.Controls.Add(this.createCarButton);
            this.Controls.Add(this.dataGridView);
            this.Name = "FormCars";
            this.Text = "Машины";
            this.Load += new System.EventHandler(this.FormCars_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button createCarButton;
        private System.Windows.Forms.Button updateCarButton;
        private System.Windows.Forms.Button deleteCarButton;
        private System.Windows.Forms.Button refreshButton;
    }
}