namespace CarShopView
{
    partial class FormStorage
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
            this.storageNameLabel = new System.Windows.Forms.Label();
            this.storageNameTextBox = new System.Windows.Forms.TextBox();
            this.componentsGroupBox = new System.Windows.Forms.GroupBox();
            this.refreshComponentsButton = new System.Windows.Forms.Button();
            this.deleteComponentButton = new System.Windows.Forms.Button();
            this.updateComponentButton = new System.Windows.Forms.Button();
            this.addComponentButton = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancleButton = new System.Windows.Forms.Button();
            this.componentsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // storageNameLabel
            // 
            this.storageNameLabel.AutoSize = true;
            this.storageNameLabel.Location = new System.Drawing.Point(21, 9);
            this.storageNameLabel.Name = "storageNameLabel";
            this.storageNameLabel.Size = new System.Drawing.Size(60, 13);
            this.storageNameLabel.TabIndex = 0;
            this.storageNameLabel.Text = "Название:";
            // 
            // storageNameTextBox
            // 
            this.storageNameTextBox.Location = new System.Drawing.Point(87, 6);
            this.storageNameTextBox.Name = "storageNameTextBox";
            this.storageNameTextBox.Size = new System.Drawing.Size(234, 20);
            this.storageNameTextBox.TabIndex = 1;
            // 
            // componentsGroupBox
            // 
            this.componentsGroupBox.Controls.Add(this.refreshComponentsButton);
            this.componentsGroupBox.Controls.Add(this.deleteComponentButton);
            this.componentsGroupBox.Controls.Add(this.updateComponentButton);
            this.componentsGroupBox.Controls.Add(this.addComponentButton);
            this.componentsGroupBox.Controls.Add(this.dataGridView);
            this.componentsGroupBox.Location = new System.Drawing.Point(11, 43);
            this.componentsGroupBox.Name = "componentsGroupBox";
            this.componentsGroupBox.Size = new System.Drawing.Size(541, 362);
            this.componentsGroupBox.TabIndex = 2;
            this.componentsGroupBox.TabStop = false;
            this.componentsGroupBox.Text = "Компоненты";
            // 
            // refreshComponentsButton
            // 
            this.refreshComponentsButton.Location = new System.Drawing.Point(437, 214);
            this.refreshComponentsButton.Name = "refreshComponentsButton";
            this.refreshComponentsButton.Size = new System.Drawing.Size(75, 23);
            this.refreshComponentsButton.TabIndex = 4;
            this.refreshComponentsButton.Text = "Обновить";
            this.refreshComponentsButton.UseVisualStyleBackColor = true;
            this.refreshComponentsButton.Click += new System.EventHandler(this.refreshComponentsButton_Click);
            // 
            // deleteComponentButton
            // 
            this.deleteComponentButton.Location = new System.Drawing.Point(437, 120);
            this.deleteComponentButton.Name = "deleteComponentButton";
            this.deleteComponentButton.Size = new System.Drawing.Size(75, 23);
            this.deleteComponentButton.TabIndex = 3;
            this.deleteComponentButton.Text = "Удалить";
            this.deleteComponentButton.UseVisualStyleBackColor = true;
            this.deleteComponentButton.Click += new System.EventHandler(this.deleteComponentButton_Click);
            // 
            // updateComponentButton
            // 
            this.updateComponentButton.Location = new System.Drawing.Point(437, 70);
            this.updateComponentButton.Name = "updateComponentButton";
            this.updateComponentButton.Size = new System.Drawing.Size(75, 23);
            this.updateComponentButton.TabIndex = 2;
            this.updateComponentButton.Text = "Изменить";
            this.updateComponentButton.UseVisualStyleBackColor = true;
            this.updateComponentButton.Click += new System.EventHandler(this.updateComponentButton_Click);
            // 
            // addComponentButton
            // 
            this.addComponentButton.Location = new System.Drawing.Point(437, 19);
            this.addComponentButton.Name = "addComponentButton";
            this.addComponentButton.Size = new System.Drawing.Size(75, 23);
            this.addComponentButton.TabIndex = 1;
            this.addComponentButton.Text = "Создать";
            this.addComponentButton.UseVisualStyleBackColor = true;
            this.addComponentButton.Click += new System.EventHandler(this.addComponentButton_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(0, 19);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(403, 342);
            this.dataGridView.TabIndex = 0;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(396, 411);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 3;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancleButton
            // 
            this.cancleButton.Location = new System.Drawing.Point(477, 411);
            this.cancleButton.Name = "cancleButton";
            this.cancleButton.Size = new System.Drawing.Size(75, 23);
            this.cancleButton.TabIndex = 4;
            this.cancleButton.Text = "Отмена";
            this.cancleButton.UseVisualStyleBackColor = true;
            this.cancleButton.Click += new System.EventHandler(this.cancleButton_Click);
            // 
            // FormStorage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 443);
            this.Controls.Add(this.cancleButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.componentsGroupBox);
            this.Controls.Add(this.storageNameTextBox);
            this.Controls.Add(this.storageNameLabel);
            this.Name = "FormStorage";
            this.Text = "Склад";
            this.Load += new System.EventHandler(this.FormCar_Load);
            this.componentsGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label storageNameLabel;
        private System.Windows.Forms.TextBox storageNameTextBox;
        private System.Windows.Forms.GroupBox componentsGroupBox;
        private System.Windows.Forms.Button refreshComponentsButton;
        private System.Windows.Forms.Button deleteComponentButton;
        private System.Windows.Forms.Button updateComponentButton;
        private System.Windows.Forms.Button addComponentButton;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancleButton;
    }
}