namespace CarShopView
{
    partial class FormMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.справочникToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.компонентыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.машиныToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.createOrderButton = new System.Windows.Forms.Button();
            this.takeOrderInWotkButton = new System.Windows.Forms.Button();
            this.orderReadyButton = new System.Windows.Forms.Button();
            this.payOrderButton = new System.Windows.Forms.Button();
            this.updateListButton = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справочникToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(718, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // справочникToolStripMenuItem
            // 
            this.справочникToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.компонентыToolStripMenuItem,
            this.машиныToolStripMenuItem});
            this.справочникToolStripMenuItem.Name = "справочникToolStripMenuItem";
            this.справочникToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.справочникToolStripMenuItem.Text = "Справочник";
            // 
            // компонентыToolStripMenuItem
            // 
            this.компонентыToolStripMenuItem.Name = "компонентыToolStripMenuItem";
            this.компонентыToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.компонентыToolStripMenuItem.Text = "Компоненты";
            this.компонентыToolStripMenuItem.Click += new System.EventHandler(this.компонентыToolStripMenuItem_Click);
            // 
            // машиныToolStripMenuItem
            // 
            this.машиныToolStripMenuItem.Name = "машиныToolStripMenuItem";
            this.машиныToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.машиныToolStripMenuItem.Text = "Машины";
            this.машиныToolStripMenuItem.Click += new System.EventHandler(this.машиныToolStripMenuItem_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(3, 20);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(571, 313);
            this.dataGridView.TabIndex = 1;
            // 
            // createOrderButton
            // 
            this.createOrderButton.Location = new System.Drawing.Point(580, 20);
            this.createOrderButton.Name = "createOrderButton";
            this.createOrderButton.Size = new System.Drawing.Size(133, 24);
            this.createOrderButton.TabIndex = 2;
            this.createOrderButton.Text = "Создать заказ";
            this.createOrderButton.UseVisualStyleBackColor = true;
            this.createOrderButton.Click += new System.EventHandler(this.createOrderButton_Click);
            // 
            // takeOrderInWotkButton
            // 
            this.takeOrderInWotkButton.Location = new System.Drawing.Point(580, 64);
            this.takeOrderInWotkButton.Name = "takeOrderInWotkButton";
            this.takeOrderInWotkButton.Size = new System.Drawing.Size(133, 24);
            this.takeOrderInWotkButton.TabIndex = 3;
            this.takeOrderInWotkButton.Text = "Отдать на выполнение";
            this.takeOrderInWotkButton.UseVisualStyleBackColor = true;
            this.takeOrderInWotkButton.Click += new System.EventHandler(this.takeOrderInWotkButton_Click);
            // 
            // orderReadyButton
            // 
            this.orderReadyButton.Location = new System.Drawing.Point(580, 109);
            this.orderReadyButton.Name = "orderReadyButton";
            this.orderReadyButton.Size = new System.Drawing.Size(133, 23);
            this.orderReadyButton.TabIndex = 4;
            this.orderReadyButton.Text = "Заказ готов";
            this.orderReadyButton.UseVisualStyleBackColor = true;
            this.orderReadyButton.Click += new System.EventHandler(this.orderReadyButton_Click);
            // 
            // payOrderButton
            // 
            this.payOrderButton.Location = new System.Drawing.Point(580, 157);
            this.payOrderButton.Name = "payOrderButton";
            this.payOrderButton.Size = new System.Drawing.Size(133, 23);
            this.payOrderButton.TabIndex = 5;
            this.payOrderButton.Text = "Заказ оплачен";
            this.payOrderButton.UseVisualStyleBackColor = true;
            this.payOrderButton.Click += new System.EventHandler(this.payOrderButton_Click);
            // 
            // updateListButton
            // 
            this.updateListButton.Location = new System.Drawing.Point(576, 299);
            this.updateListButton.Name = "updateListButton";
            this.updateListButton.Size = new System.Drawing.Size(137, 23);
            this.updateListButton.TabIndex = 6;
            this.updateListButton.Text = "Обновить список";
            this.updateListButton.UseVisualStyleBackColor = true;
            this.updateListButton.Click += new System.EventHandler(this.updateListButton_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 334);
            this.Controls.Add(this.updateListButton);
            this.Controls.Add(this.payOrderButton);
            this.Controls.Add(this.orderReadyButton);
            this.Controls.Add(this.takeOrderInWotkButton);
            this.Controls.Add(this.createOrderButton);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "Автосалон";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem справочникToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem компонентыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem машиныToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button createOrderButton;
        private System.Windows.Forms.Button takeOrderInWotkButton;
        private System.Windows.Forms.Button orderReadyButton;
        private System.Windows.Forms.Button payOrderButton;
        private System.Windows.Forms.Button updateListButton;
    }
}