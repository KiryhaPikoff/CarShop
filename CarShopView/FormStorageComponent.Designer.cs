namespace CarShopView
{
    partial class FormStorageComponent
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
            this.componentNameLabel = new System.Windows.Forms.Label();
            this.countComponentLabel = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancleButton = new System.Windows.Forms.Button();
            this.componentsComboBox = new System.Windows.Forms.ComboBox();
            this.countTextBox = new System.Windows.Forms.TextBox();
            this.storageLabel = new System.Windows.Forms.Label();
            this.storageComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // componentNameLabel
            // 
            this.componentNameLabel.AutoSize = true;
            this.componentNameLabel.Location = new System.Drawing.Point(12, 37);
            this.componentNameLabel.Name = "componentNameLabel";
            this.componentNameLabel.Size = new System.Drawing.Size(66, 13);
            this.componentNameLabel.TabIndex = 0;
            this.componentNameLabel.Text = "Компонент:";
            // 
            // countComponentLabel
            // 
            this.countComponentLabel.AutoSize = true;
            this.countComponentLabel.Location = new System.Drawing.Point(12, 65);
            this.countComponentLabel.Name = "countComponentLabel";
            this.countComponentLabel.Size = new System.Drawing.Size(69, 13);
            this.countComponentLabel.TabIndex = 1;
            this.countComponentLabel.Text = "Количество:";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(167, 91);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 4;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancleButton
            // 
            this.cancleButton.Location = new System.Drawing.Point(247, 91);
            this.cancleButton.Name = "cancleButton";
            this.cancleButton.Size = new System.Drawing.Size(75, 23);
            this.cancleButton.TabIndex = 5;
            this.cancleButton.Text = "Отмена";
            this.cancleButton.UseVisualStyleBackColor = true;
            this.cancleButton.Click += new System.EventHandler(this.cancleButton_Click);
            // 
            // componentsComboBox
            // 
            this.componentsComboBox.FormattingEnabled = true;
            this.componentsComboBox.Location = new System.Drawing.Point(81, 34);
            this.componentsComboBox.Name = "componentsComboBox";
            this.componentsComboBox.Size = new System.Drawing.Size(241, 21);
            this.componentsComboBox.TabIndex = 6;
            // 
            // countTextBox
            // 
            this.countTextBox.Location = new System.Drawing.Point(81, 62);
            this.countTextBox.Name = "countTextBox";
            this.countTextBox.Size = new System.Drawing.Size(241, 20);
            this.countTextBox.TabIndex = 7;
            // 
            // storageLabel
            // 
            this.storageLabel.AutoSize = true;
            this.storageLabel.Location = new System.Drawing.Point(12, 10);
            this.storageLabel.Name = "storageLabel";
            this.storageLabel.Size = new System.Drawing.Size(41, 13);
            this.storageLabel.TabIndex = 8;
            this.storageLabel.Text = "Склад:";
            // 
            // storageComboBox
            // 
            this.storageComboBox.FormattingEnabled = true;
            this.storageComboBox.Location = new System.Drawing.Point(81, 7);
            this.storageComboBox.Name = "storageComboBox";
            this.storageComboBox.Size = new System.Drawing.Size(241, 21);
            this.storageComboBox.TabIndex = 9;
            // 
            // FormStorageComponent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 116);
            this.Controls.Add(this.storageComboBox);
            this.Controls.Add(this.storageLabel);
            this.Controls.Add(this.countTextBox);
            this.Controls.Add(this.componentsComboBox);
            this.Controls.Add(this.cancleButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.countComponentLabel);
            this.Controls.Add(this.componentNameLabel);
            this.Name = "FormStorageComponent";
            this.Text = "Компонент склада";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label componentNameLabel;
        private System.Windows.Forms.Label countComponentLabel;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancleButton;
        private System.Windows.Forms.ComboBox componentsComboBox;
        private System.Windows.Forms.TextBox countTextBox;
        private System.Windows.Forms.Label storageLabel;
        private System.Windows.Forms.ComboBox storageComboBox;
    }
}