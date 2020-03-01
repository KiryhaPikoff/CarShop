namespace CarShopView
{
    partial class FormCar
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
            this.nameLabel = new System.Windows.Forms.Label();
            this.priceLabel = new System.Windows.Forms.Label();
            this.nameCarTextBox = new System.Windows.Forms.TextBox();
            this.priceCarTextBox = new System.Windows.Forms.TextBox();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.createCarButton = new System.Windows.Forms.Button();
            this.updateCatButton = new System.Windows.Forms.Button();
            this.deleteCarButton = new System.Windows.Forms.Button();
            this.updateListButton = new System.Windows.Forms.Button();
            this.groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(17, 10);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(63, 13);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Название: ";
            // 
            // priceLabel
            // 
            this.priceLabel.AutoSize = true;
            this.priceLabel.Location = new System.Drawing.Point(17, 41);
            this.priceLabel.Name = "priceLabel";
            this.priceLabel.Size = new System.Drawing.Size(39, 13);
            this.priceLabel.TabIndex = 1;
            this.priceLabel.Text = "Цена: ";
            // 
            // nameCarTextBox
            // 
            this.nameCarTextBox.Location = new System.Drawing.Point(86, 7);
            this.nameCarTextBox.Name = "nameCarTextBox";
            this.nameCarTextBox.Size = new System.Drawing.Size(218, 20);
            this.nameCarTextBox.TabIndex = 2;
            // 
            // priceCarTextBox
            // 
            this.priceCarTextBox.Location = new System.Drawing.Point(86, 38);
            this.priceCarTextBox.Name = "priceCarTextBox";
            this.priceCarTextBox.Size = new System.Drawing.Size(77, 20);
            this.priceCarTextBox.TabIndex = 3;
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.updateListButton);
            this.groupBox.Controls.Add(this.deleteCarButton);
            this.groupBox.Controls.Add(this.updateCatButton);
            this.groupBox.Controls.Add(this.createCarButton);
            this.groupBox.Controls.Add(this.dataGridView);
            this.groupBox.Location = new System.Drawing.Point(12, 73);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(480, 345);
            this.groupBox.TabIndex = 4;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Компоненты";
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(9, 19);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(349, 320);
            this.dataGridView.TabIndex = 0;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(335, 424);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 5;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(416, 424);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 6;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // createCarButton
            // 
            this.createCarButton.Location = new System.Drawing.Point(386, 19);
            this.createCarButton.Name = "createCarButton";
            this.createCarButton.Size = new System.Drawing.Size(75, 23);
            this.createCarButton.TabIndex = 1;
            this.createCarButton.Text = "Создать";
            this.createCarButton.UseVisualStyleBackColor = true;
            this.createCarButton.Click += new System.EventHandler(this.CreateCarButton_Click);
            // 
            // updateCatButton
            // 
            this.updateCatButton.Location = new System.Drawing.Point(386, 61);
            this.updateCatButton.Name = "updateCatButton";
            this.updateCatButton.Size = new System.Drawing.Size(75, 23);
            this.updateCatButton.TabIndex = 2;
            this.updateCatButton.Text = "Изменить";
            this.updateCatButton.UseVisualStyleBackColor = true;
            this.updateCatButton.Click += new System.EventHandler(this.UpdateCatButton_Click);
            // 
            // deleteCarButton
            // 
            this.deleteCarButton.Location = new System.Drawing.Point(386, 104);
            this.deleteCarButton.Name = "deleteCarButton";
            this.deleteCarButton.Size = new System.Drawing.Size(75, 23);
            this.deleteCarButton.TabIndex = 3;
            this.deleteCarButton.Text = "Удалить";
            this.deleteCarButton.UseVisualStyleBackColor = true;
            this.deleteCarButton.Click += new System.EventHandler(this.DeleteCarButton_Click);
            // 
            // updateListButton
            // 
            this.updateListButton.Location = new System.Drawing.Point(386, 193);
            this.updateListButton.Name = "updateListButton";
            this.updateListButton.Size = new System.Drawing.Size(75, 23);
            this.updateListButton.TabIndex = 4;
            this.updateListButton.Text = "Обновить";
            this.updateListButton.UseVisualStyleBackColor = true;
            this.updateListButton.Click += new System.EventHandler(this.UpdateListButton_Click);
            // 
            // FormCar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 454);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.priceCarTextBox);
            this.Controls.Add(this.nameCarTextBox);
            this.Controls.Add(this.priceLabel);
            this.Controls.Add(this.nameLabel);
            this.Name = "FormCar";
            this.Text = "Машина";
            this.Load += new System.EventHandler(this.FormCar_Load);
            this.groupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label priceLabel;
        private System.Windows.Forms.TextBox nameCarTextBox;
        private System.Windows.Forms.TextBox priceCarTextBox;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Button updateListButton;
        private System.Windows.Forms.Button deleteCarButton;
        private System.Windows.Forms.Button updateCatButton;
        private System.Windows.Forms.Button createCarButton;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
    }
}