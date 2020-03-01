namespace CarShopView
{
    partial class FormComponents
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
            this.createComponent = new System.Windows.Forms.Button();
            this.updateComponent = new System.Windows.Forms.Button();
            this.deleteComponent = new System.Windows.Forms.Button();
            this.updateList = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(0, 0);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(398, 450);
            this.dataGridView.TabIndex = 0;
            // 
            // createComponent
            // 
            this.createComponent.Location = new System.Drawing.Point(418, 12);
            this.createComponent.Name = "createComponent";
            this.createComponent.Size = new System.Drawing.Size(75, 23);
            this.createComponent.TabIndex = 1;
            this.createComponent.Text = "Создать";
            this.createComponent.UseVisualStyleBackColor = true;
            this.createComponent.Click += new System.EventHandler(this.createComponent_Click);
            // 
            // updateComponent
            // 
            this.updateComponent.Location = new System.Drawing.Point(418, 53);
            this.updateComponent.Name = "updateComponent";
            this.updateComponent.Size = new System.Drawing.Size(75, 23);
            this.updateComponent.TabIndex = 2;
            this.updateComponent.Text = "Изменить";
            this.updateComponent.UseVisualStyleBackColor = true;
            this.updateComponent.Click += new System.EventHandler(this.updateComponent_Click);
            // 
            // deleteComponent
            // 
            this.deleteComponent.Location = new System.Drawing.Point(418, 97);
            this.deleteComponent.Name = "deleteComponent";
            this.deleteComponent.Size = new System.Drawing.Size(75, 23);
            this.deleteComponent.TabIndex = 3;
            this.deleteComponent.Text = "Удалить";
            this.deleteComponent.UseVisualStyleBackColor = true;
            this.deleteComponent.Click += new System.EventHandler(this.deleteComponent_Click);
            // 
            // updateList
            // 
            this.updateList.Location = new System.Drawing.Point(418, 173);
            this.updateList.Name = "updateList";
            this.updateList.Size = new System.Drawing.Size(75, 23);
            this.updateList.TabIndex = 4;
            this.updateList.Text = "Обновить";
            this.updateList.UseVisualStyleBackColor = true;
            this.updateList.Click += new System.EventHandler(this.updateList_Click);
            // 
            // FormComponents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 450);
            this.Controls.Add(this.updateList);
            this.Controls.Add(this.deleteComponent);
            this.Controls.Add(this.updateComponent);
            this.Controls.Add(this.createComponent);
            this.Controls.Add(this.dataGridView);
            this.Name = "FormComponents";
            this.Text = "Компоненты";
            this.Load += new System.EventHandler(this.FormComponents_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button createComponent;
        private System.Windows.Forms.Button updateComponent;
        private System.Windows.Forms.Button deleteComponent;
        private System.Windows.Forms.Button updateList;
    }
}