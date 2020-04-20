namespace CarShopView
{
    partial class FormImplementers
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
            this.refreshButton = new System.Windows.Forms.Button();
            this.deleteImplementerButton = new System.Windows.Forms.Button();
            this.updateImplementerButton = new System.Windows.Forms.Button();
            this.createImplementerButton = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(419, 162);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(75, 38);
            this.refreshButton.TabIndex = 9;
            this.refreshButton.Text = "Обновить список";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // deleteImplementerButton
            // 
            this.deleteImplementerButton.Location = new System.Drawing.Point(419, 96);
            this.deleteImplementerButton.Name = "deleteImplementerButton";
            this.deleteImplementerButton.Size = new System.Drawing.Size(75, 23);
            this.deleteImplementerButton.TabIndex = 8;
            this.deleteImplementerButton.Text = "Удалить";
            this.deleteImplementerButton.UseVisualStyleBackColor = true;
            this.deleteImplementerButton.Click += new System.EventHandler(this.deleteImplementerButton_Click);
            // 
            // updateImplementerButton
            // 
            this.updateImplementerButton.Location = new System.Drawing.Point(419, 56);
            this.updateImplementerButton.Name = "updateImplementerButton";
            this.updateImplementerButton.Size = new System.Drawing.Size(75, 23);
            this.updateImplementerButton.TabIndex = 7;
            this.updateImplementerButton.Text = "Изменить";
            this.updateImplementerButton.UseVisualStyleBackColor = true;
            this.updateImplementerButton.Click += new System.EventHandler(this.updateImplementerButton_Click);
            // 
            // createImplementerButton
            // 
            this.createImplementerButton.Location = new System.Drawing.Point(420, 18);
            this.createImplementerButton.Name = "createImplementerButton";
            this.createImplementerButton.Size = new System.Drawing.Size(75, 23);
            this.createImplementerButton.TabIndex = 6;
            this.createImplementerButton.Text = "Добавить";
            this.createImplementerButton.UseVisualStyleBackColor = true;
            this.createImplementerButton.Click += new System.EventHandler(this.createImplementerButton_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(1, 0);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(406, 399);
            this.dataGridView.TabIndex = 5;
            // 
            // FormImplementerts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 400);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.deleteImplementerButton);
            this.Controls.Add(this.updateImplementerButton);
            this.Controls.Add(this.createImplementerButton);
            this.Controls.Add(this.dataGridView);
            this.Name = "FormImplementerts";
            this.Text = "Исполнители";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.Button deleteImplementerButton;
        private System.Windows.Forms.Button updateImplementerButton;
        private System.Windows.Forms.Button createImplementerButton;
        private System.Windows.Forms.DataGridView dataGridView;
    }
}