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
            this.клиентыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.исполнителиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчётыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокКомпонентовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.компонентыПоМашинамToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокЗаказовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.запускРаботToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сообщенияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.payOrderButton = new System.Windows.Forms.Button();
            this.updateListButton = new System.Windows.Forms.Button();
            this.createOrderButton = new System.Windows.Forms.Button();
            this.backUpButton = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справочникToolStripMenuItem,
            this.отчётыToolStripMenuItem,
            this.запускРаботToolStripMenuItem,
            this.сообщенияToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1011, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // справочникToolStripMenuItem
            // 
            this.справочникToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.компонентыToolStripMenuItem,
            this.машиныToolStripMenuItem,
            this.клиентыToolStripMenuItem,
            this.исполнителиToolStripMenuItem});
            this.справочникToolStripMenuItem.Name = "справочникToolStripMenuItem";
            this.справочникToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.справочникToolStripMenuItem.Text = "Справочник";
            // 
            // компонентыToolStripMenuItem
            // 
            this.компонентыToolStripMenuItem.Name = "компонентыToolStripMenuItem";
            this.компонентыToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.компонентыToolStripMenuItem.Text = "Компоненты";
            this.компонентыToolStripMenuItem.Click += new System.EventHandler(this.компонентыToolStripMenuItem_Click);
            // 
            // машиныToolStripMenuItem
            // 
            this.машиныToolStripMenuItem.Name = "машиныToolStripMenuItem";
            this.машиныToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.машиныToolStripMenuItem.Text = "Машины";
            this.машиныToolStripMenuItem.Click += new System.EventHandler(this.машиныToolStripMenuItem_Click);
            // 
            // клиентыToolStripMenuItem
            // 
            this.клиентыToolStripMenuItem.Name = "клиентыToolStripMenuItem";
            this.клиентыToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.клиентыToolStripMenuItem.Text = "Клиенты";
            this.клиентыToolStripMenuItem.Click += new System.EventHandler(this.клиентыToolStripMenuItem_Click);
            // 
            // исполнителиToolStripMenuItem
            // 
            this.исполнителиToolStripMenuItem.Name = "исполнителиToolStripMenuItem";
            this.исполнителиToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.исполнителиToolStripMenuItem.Text = "Исполнители";
            this.исполнителиToolStripMenuItem.Click += new System.EventHandler(this.исполнителиToolStripMenuItem_Click);
            // 
            // отчётыToolStripMenuItem
            // 
            this.отчётыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.списокКомпонентовToolStripMenuItem,
            this.компонентыПоМашинамToolStripMenuItem,
            this.списокЗаказовToolStripMenuItem});
            this.отчётыToolStripMenuItem.Name = "отчётыToolStripMenuItem";
            this.отчётыToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.отчётыToolStripMenuItem.Text = "Отчёты";
            // 
            // списокКомпонентовToolStripMenuItem
            // 
            this.списокКомпонентовToolStripMenuItem.Name = "списокКомпонентовToolStripMenuItem";
            this.списокКомпонентовToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.списокКомпонентовToolStripMenuItem.Text = "Машины";
            this.списокКомпонентовToolStripMenuItem.Click += new System.EventHandler(this.списокКомпонентовToolStripMenuItem_Click);
            // 
            // компонентыПоМашинамToolStripMenuItem
            // 
            this.компонентыПоМашинамToolStripMenuItem.Name = "компонентыПоМашинамToolStripMenuItem";
            this.компонентыПоМашинамToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.компонентыПоМашинамToolStripMenuItem.Text = "Заказы";
            this.компонентыПоМашинамToolStripMenuItem.Click += new System.EventHandler(this.ordersToolStripMenuItem_Click);
            // 
            // списокЗаказовToolStripMenuItem
            // 
            this.списокЗаказовToolStripMenuItem.Name = "списокЗаказовToolStripMenuItem";
            this.списокЗаказовToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.списокЗаказовToolStripMenuItem.Text = "Машины и компоненты";
            this.списокЗаказовToolStripMenuItem.Click += new System.EventHandler(this.carsToolStripMenuItem_Click);
            // 
            // запускРаботToolStripMenuItem
            // 
            this.запускРаботToolStripMenuItem.Name = "запускРаботToolStripMenuItem";
            this.запускРаботToolStripMenuItem.Size = new System.Drawing.Size(92, 20);
            this.запускРаботToolStripMenuItem.Text = "Запуск работ";
            this.запускРаботToolStripMenuItem.Click += new System.EventHandler(this.запускРаботToolStripMenuItem_Click);
            // 
            // сообщенияToolStripMenuItem
            // 
            this.сообщенияToolStripMenuItem.Name = "сообщенияToolStripMenuItem";
            this.сообщенияToolStripMenuItem.Size = new System.Drawing.Size(85, 20);
            this.сообщенияToolStripMenuItem.Text = "Сообщения";
            this.сообщенияToolStripMenuItem.Click += new System.EventHandler(this.сообщенияToolStripMenuItem_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(3, 20);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(853, 313);
            this.dataGridView.TabIndex = 1;
            // 
            // payOrderButton
            // 
            this.payOrderButton.Location = new System.Drawing.Point(866, 109);
            this.payOrderButton.Name = "payOrderButton";
            this.payOrderButton.Size = new System.Drawing.Size(133, 23);
            this.payOrderButton.TabIndex = 5;
            this.payOrderButton.Text = "Заказ оплачен";
            this.payOrderButton.UseVisualStyleBackColor = true;
            this.payOrderButton.Click += new System.EventHandler(this.payOrderButton_Click);
            // 
            // updateListButton
            // 
            this.updateListButton.Location = new System.Drawing.Point(862, 299);
            this.updateListButton.Name = "updateListButton";
            this.updateListButton.Size = new System.Drawing.Size(137, 23);
            this.updateListButton.TabIndex = 6;
            this.updateListButton.Text = "Обновить список";
            this.updateListButton.UseVisualStyleBackColor = true;
            this.updateListButton.Click += new System.EventHandler(this.updateListButton_Click);
            // 
            // createOrderButton
            // 
            this.createOrderButton.Location = new System.Drawing.Point(866, 20);
            this.createOrderButton.Name = "createOrderButton";
            this.createOrderButton.Size = new System.Drawing.Size(133, 24);
            this.createOrderButton.TabIndex = 2;
            this.createOrderButton.Text = "Создать заказ";
            this.createOrderButton.UseVisualStyleBackColor = true;
            this.createOrderButton.Click += new System.EventHandler(this.createOrderButton_Click);
            // 
            // backUpButton
            // 
            this.backUpButton.Location = new System.Drawing.Point(866, 230);
            this.backUpButton.Name = "backUpButton";
            this.backUpButton.Size = new System.Drawing.Size(133, 24);
            this.backUpButton.TabIndex = 7;
            this.backUpButton.Text = "Сделать бэкап";
            this.backUpButton.UseVisualStyleBackColor = true;
            this.backUpButton.Click += new System.EventHandler(this.backUpButton_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 334);
            this.Controls.Add(this.backUpButton);
            this.Controls.Add(this.updateListButton);
            this.Controls.Add(this.payOrderButton);
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
        private System.Windows.Forms.Button payOrderButton;
        private System.Windows.Forms.Button updateListButton;
        private System.Windows.Forms.ToolStripMenuItem отчётыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списокКомпонентовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem компонентыПоМашинамToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списокЗаказовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem клиентыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem запускРаботToolStripMenuItem;
        private System.Windows.Forms.Button createOrderButton;
        private System.Windows.Forms.ToolStripMenuItem исполнителиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сообщенияToolStripMenuItem;
        private System.Windows.Forms.Button backUpButton;
    }
}