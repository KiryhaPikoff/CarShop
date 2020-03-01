namespace CarShopView
{
    partial class FormComponent
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.nameComponentLael = new System.Windows.Forms.Label();
            this.nameComponentTextBox = new System.Windows.Forms.TextBox();
            this.saveComponentButton = new System.Windows.Forms.Button();
            this.cancelComponentButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // nameComponentLael
            // 
            this.nameComponentLael.AutoSize = true;
            this.nameComponentLael.Location = new System.Drawing.Point(12, 9);
            this.nameComponentLael.Name = "nameComponentLael";
            this.nameComponentLael.Size = new System.Drawing.Size(63, 13);
            this.nameComponentLael.TabIndex = 0;
            this.nameComponentLael.Text = "Название: ";
            // 
            // nameComponentTextBox
            // 
            this.nameComponentTextBox.Location = new System.Drawing.Point(81, 6);
            this.nameComponentTextBox.Name = "nameComponentTextBox";
            this.nameComponentTextBox.Size = new System.Drawing.Size(184, 20);
            this.nameComponentTextBox.TabIndex = 1;
            // 
            // saveComponentButton
            // 
            this.saveComponentButton.Location = new System.Drawing.Point(107, 32);
            this.saveComponentButton.Name = "saveComponentButton";
            this.saveComponentButton.Size = new System.Drawing.Size(77, 23);
            this.saveComponentButton.TabIndex = 2;
            this.saveComponentButton.Text = "Сохранить";
            this.saveComponentButton.UseVisualStyleBackColor = true;
            this.saveComponentButton.Click += new System.EventHandler(this.SaveComponentButton_Click);
            // 
            // cancelComponentButton
            // 
            this.cancelComponentButton.Location = new System.Drawing.Point(190, 32);
            this.cancelComponentButton.Name = "cancelComponentButton";
            this.cancelComponentButton.Size = new System.Drawing.Size(75, 23);
            this.cancelComponentButton.TabIndex = 3;
            this.cancelComponentButton.Text = "Отмена";
            this.cancelComponentButton.UseVisualStyleBackColor = true;
            this.cancelComponentButton.Click += new System.EventHandler(this.CancelComponentButton_Click);
            // 
            // FormComponent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 65);
            this.Controls.Add(this.cancelComponentButton);
            this.Controls.Add(this.saveComponentButton);
            this.Controls.Add(this.nameComponentTextBox);
            this.Controls.Add(this.nameComponentLael);
            this.Name = "FormComponent";
            this.Text = "Компонент";
            this.Load += new System.EventHandler(this.FormComponent_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nameComponentLael;
        private System.Windows.Forms.TextBox nameComponentTextBox;
        private System.Windows.Forms.Button saveComponentButton;
        private System.Windows.Forms.Button cancelComponentButton;
    }
}

