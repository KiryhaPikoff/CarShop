namespace CarShopView
{
    partial class FormImplementer
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
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.pauseTimeTextBox = new System.Windows.Forms.TextBox();
            this.pauseTimeLabel = new System.Windows.Forms.Label();
            this.workingTimeLabel = new System.Windows.Forms.Label();
            this.fioLabel = new System.Windows.Forms.Label();
            this.fioTextBox = new System.Windows.Forms.TextBox();
            this.workingTimeTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(317, 93);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 11;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(236, 93);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 10;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // pauseTimeTextBox
            // 
            this.pauseTimeTextBox.Location = new System.Drawing.Point(151, 67);
            this.pauseTimeTextBox.Name = "pauseTimeTextBox";
            this.pauseTimeTextBox.Size = new System.Drawing.Size(241, 20);
            this.pauseTimeTextBox.TabIndex = 9;
            // 
            // pauseTimeLabel
            // 
            this.pauseTimeLabel.AutoSize = true;
            this.pauseTimeLabel.Location = new System.Drawing.Point(12, 67);
            this.pauseTimeLabel.Name = "pauseTimeLabel";
            this.pauseTimeLabel.Size = new System.Drawing.Size(91, 13);
            this.pauseTimeLabel.TabIndex = 7;
            this.pauseTimeLabel.Text = "Время на отдых:";
            // 
            // workingTimeLabel
            // 
            this.workingTimeLabel.AutoSize = true;
            this.workingTimeLabel.Location = new System.Drawing.Point(12, 40);
            this.workingTimeLabel.Name = "workingTimeLabel";
            this.workingTimeLabel.Size = new System.Drawing.Size(123, 13);
            this.workingTimeLabel.TabIndex = 6;
            this.workingTimeLabel.Text = "Время на выполнения:";
            // 
            // fioLabel
            // 
            this.fioLabel.AutoSize = true;
            this.fioLabel.Location = new System.Drawing.Point(12, 16);
            this.fioLabel.Name = "fioLabel";
            this.fioLabel.Size = new System.Drawing.Size(37, 13);
            this.fioLabel.TabIndex = 12;
            this.fioLabel.Text = "ФИО:";
            // 
            // fioTextBox
            // 
            this.fioTextBox.Location = new System.Drawing.Point(151, 9);
            this.fioTextBox.Name = "fioTextBox";
            this.fioTextBox.Size = new System.Drawing.Size(241, 20);
            this.fioTextBox.TabIndex = 13;
            // 
            // workingTimeTextBox
            // 
            this.workingTimeTextBox.Location = new System.Drawing.Point(151, 37);
            this.workingTimeTextBox.Name = "workingTimeTextBox";
            this.workingTimeTextBox.Size = new System.Drawing.Size(241, 20);
            this.workingTimeTextBox.TabIndex = 14;
            // 
            // FormImplementer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 125);
            this.Controls.Add(this.workingTimeTextBox);
            this.Controls.Add(this.fioTextBox);
            this.Controls.Add(this.fioLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.pauseTimeTextBox);
            this.Controls.Add(this.pauseTimeLabel);
            this.Controls.Add(this.workingTimeLabel);
            this.Name = "FormImplementer";
            this.Text = "Исполнитель";
            this.Load += new System.EventHandler(this.FormImplementer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.TextBox pauseTimeTextBox;
        private System.Windows.Forms.Label pauseTimeLabel;
        private System.Windows.Forms.Label workingTimeLabel;
        private System.Windows.Forms.Label fioLabel;
        private System.Windows.Forms.TextBox fioTextBox;
        private System.Windows.Forms.TextBox workingTimeTextBox;
    }
}