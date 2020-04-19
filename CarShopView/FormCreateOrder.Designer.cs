namespace CarShopView
{
    partial class FormCreateOrder
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
            this.carLabel = new System.Windows.Forms.Label();
            this.countLabel = new System.Windows.Forms.Label();
            this.sumLabel = new System.Windows.Forms.Label();
            this.carComboBox = new System.Windows.Forms.ComboBox();
            this.countTextBox = new System.Windows.Forms.TextBox();
            this.sumTextBox = new System.Windows.Forms.TextBox();
            this.saveOrderButton = new System.Windows.Forms.Button();
            this.cancelOrderButton = new System.Windows.Forms.Button();
            this.clientLabel = new System.Windows.Forms.Label();
            this.clientComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // carLabel
            // 
            this.carLabel.AutoSize = true;
            this.carLabel.Location = new System.Drawing.Point(13, 41);
            this.carLabel.Name = "carLabel";
            this.carLabel.Size = new System.Drawing.Size(51, 13);
            this.carLabel.TabIndex = 0;
            this.carLabel.Text = "Машина:";
            // 
            // countLabel
            // 
            this.countLabel.AutoSize = true;
            this.countLabel.Location = new System.Drawing.Point(13, 74);
            this.countLabel.Name = "countLabel";
            this.countLabel.Size = new System.Drawing.Size(72, 13);
            this.countLabel.TabIndex = 1;
            this.countLabel.Text = "Количество: ";
            // 
            // sumLabel
            // 
            this.sumLabel.AutoSize = true;
            this.sumLabel.Location = new System.Drawing.Point(13, 106);
            this.sumLabel.Name = "sumLabel";
            this.sumLabel.Size = new System.Drawing.Size(47, 13);
            this.sumLabel.TabIndex = 2;
            this.sumLabel.Text = "Сумма: ";
            // 
            // carComboBox
            // 
            this.carComboBox.FormattingEnabled = true;
            this.carComboBox.Location = new System.Drawing.Point(94, 41);
            this.carComboBox.Name = "carComboBox";
            this.carComboBox.Size = new System.Drawing.Size(235, 21);
            this.carComboBox.TabIndex = 3;
            this.carComboBox.TextChanged += new System.EventHandler(this.carComboBox_TextChanged);
            // 
            // countTextBox
            // 
            this.countTextBox.Location = new System.Drawing.Point(94, 71);
            this.countTextBox.Name = "countTextBox";
            this.countTextBox.Size = new System.Drawing.Size(235, 20);
            this.countTextBox.TabIndex = 4;
            this.countTextBox.TextChanged += new System.EventHandler(this.countTextBox_TextChanged);
            // 
            // sumTextBox
            // 
            this.sumTextBox.Location = new System.Drawing.Point(94, 103);
            this.sumTextBox.Name = "sumTextBox";
            this.sumTextBox.ReadOnly = true;
            this.sumTextBox.Size = new System.Drawing.Size(235, 20);
            this.sumTextBox.TabIndex = 5;
            // 
            // saveOrderButton
            // 
            this.saveOrderButton.Location = new System.Drawing.Point(173, 138);
            this.saveOrderButton.Name = "saveOrderButton";
            this.saveOrderButton.Size = new System.Drawing.Size(75, 23);
            this.saveOrderButton.TabIndex = 6;
            this.saveOrderButton.Text = "Сохранить";
            this.saveOrderButton.UseVisualStyleBackColor = true;
            this.saveOrderButton.Click += new System.EventHandler(this.saveOrderButton_Click);
            // 
            // cancelOrderButton
            // 
            this.cancelOrderButton.Location = new System.Drawing.Point(254, 138);
            this.cancelOrderButton.Name = "cancelOrderButton";
            this.cancelOrderButton.Size = new System.Drawing.Size(75, 23);
            this.cancelOrderButton.TabIndex = 7;
            this.cancelOrderButton.Text = "Отмена";
            this.cancelOrderButton.UseVisualStyleBackColor = true;
            this.cancelOrderButton.Click += new System.EventHandler(this.cancelOrderButton_Click);
            // 
            // clientLabel
            // 
            this.clientLabel.AutoSize = true;
            this.clientLabel.Location = new System.Drawing.Point(13, 9);
            this.clientLabel.Name = "clientLabel";
            this.clientLabel.Size = new System.Drawing.Size(46, 13);
            this.clientLabel.TabIndex = 8;
            this.clientLabel.Text = "Клиент:";
            // 
            // clientComboBox
            // 
            this.clientComboBox.FormattingEnabled = true;
            this.clientComboBox.Location = new System.Drawing.Point(94, 9);
            this.clientComboBox.Name = "clientComboBox";
            this.clientComboBox.Size = new System.Drawing.Size(235, 21);
            this.clientComboBox.TabIndex = 9;
            // 
            // FormCreateOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 173);
            this.Controls.Add(this.clientComboBox);
            this.Controls.Add(this.clientLabel);
            this.Controls.Add(this.cancelOrderButton);
            this.Controls.Add(this.saveOrderButton);
            this.Controls.Add(this.sumTextBox);
            this.Controls.Add(this.countTextBox);
            this.Controls.Add(this.carComboBox);
            this.Controls.Add(this.sumLabel);
            this.Controls.Add(this.countLabel);
            this.Controls.Add(this.carLabel);
            this.Name = "FormCreateOrder";
            this.Text = "Заказ";
            this.Load += new System.EventHandler(this.FormCreateOrder_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label carLabel;
        private System.Windows.Forms.Label countLabel;
        private System.Windows.Forms.Label sumLabel;
        private System.Windows.Forms.ComboBox carComboBox;
        private System.Windows.Forms.TextBox countTextBox;
        private System.Windows.Forms.TextBox sumTextBox;
        private System.Windows.Forms.Button saveOrderButton;
        private System.Windows.Forms.Button cancelOrderButton;
        private System.Windows.Forms.Label clientLabel;
        private System.Windows.Forms.ComboBox clientComboBox;
    }
}