namespace CarShopStorageView
{
    partial class FormStorages
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
            this.createStorageButton = new System.Windows.Forms.Button();
            this.updateStorageButton = new System.Windows.Forms.Button();
            this.deleteStorageButton = new System.Windows.Forms.Button();
            this.refreshStoragesButton = new System.Windows.Forms.Button();
            this.addComponentButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(0, 1);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(422, 404);
            this.dataGridView.TabIndex = 0;
            // 
            // createStorageButton
            // 
            this.createStorageButton.Location = new System.Drawing.Point(441, 24);
            this.createStorageButton.Name = "createStorageButton";
            this.createStorageButton.Size = new System.Drawing.Size(75, 23);
            this.createStorageButton.TabIndex = 1;
            this.createStorageButton.Text = "Добавить";
            this.createStorageButton.UseVisualStyleBackColor = true;
            this.createStorageButton.Click += new System.EventHandler(this.createStorageButton_Click);
            // 
            // updateStorageButton
            // 
            this.updateStorageButton.Location = new System.Drawing.Point(441, 64);
            this.updateStorageButton.Name = "updateStorageButton";
            this.updateStorageButton.Size = new System.Drawing.Size(75, 23);
            this.updateStorageButton.TabIndex = 2;
            this.updateStorageButton.Text = "Изменить";
            this.updateStorageButton.UseVisualStyleBackColor = true;
            this.updateStorageButton.Click += new System.EventHandler(this.updateStorageButton_Click);
            // 
            // deleteStorageButton
            // 
            this.deleteStorageButton.Location = new System.Drawing.Point(441, 109);
            this.deleteStorageButton.Name = "deleteStorageButton";
            this.deleteStorageButton.Size = new System.Drawing.Size(75, 23);
            this.deleteStorageButton.TabIndex = 3;
            this.deleteStorageButton.Text = "Удалить";
            this.deleteStorageButton.UseVisualStyleBackColor = true;
            this.deleteStorageButton.Click += new System.EventHandler(this.deleteStorageButton_Click);
            // 
            // addComponentButton
            // 
            this.addComponentButton.Location = new System.Drawing.Point(441, 150);
            this.addComponentButton.Name = "addComponentButton";
            this.addComponentButton.Size = new System.Drawing.Size(75, 46);
            this.addComponentButton.TabIndex = 4;
            this.addComponentButton.Text = "Пополнить склад";
            this.addComponentButton.UseVisualStyleBackColor = true;
            this.addComponentButton.Click += new System.EventHandler(this.addComponentButton_Click);
            // 
            // refreshStoragesButton
            // 
            this.refreshStoragesButton.Location = new System.Drawing.Point(441, 202);
            this.refreshStoragesButton.Name = "refreshStoragesButton";
            this.refreshStoragesButton.Size = new System.Drawing.Size(75, 46);
            this.refreshStoragesButton.TabIndex = 5;
            this.refreshStoragesButton.Text = "Обновить список";
            this.refreshStoragesButton.UseVisualStyleBackColor = true;
            this.refreshStoragesButton.Click += new System.EventHandler(this.refreshStoragesButton_Click);
            // 
            // FormStorages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 406);
            this.Controls.Add(this.refreshStoragesButton);
            this.Controls.Add(this.addComponentButton);
            this.Controls.Add(this.deleteStorageButton);
            this.Controls.Add(this.updateStorageButton);
            this.Controls.Add(this.createStorageButton);
            this.Controls.Add(this.dataGridView);
            this.Name = "FormStorages";
            this.Text = "Склады";
            this.Load += new System.EventHandler(this.FormStorages_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button createStorageButton;
        private System.Windows.Forms.Button updateStorageButton;
        private System.Windows.Forms.Button deleteStorageButton;
        private System.Windows.Forms.Button refreshStoragesButton;
        private System.Windows.Forms.Button addComponentButton;
    }
}