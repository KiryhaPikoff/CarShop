﻿namespace CarShopView
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
            this.действияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.складыToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьКомпонентToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчётыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокКомпонентовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.компонентыПоМашинамToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокЗаказовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.складыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.createOrderButton = new System.Windows.Forms.Button();
            this.takeOrderInWotkButton = new System.Windows.Forms.Button();
            this.orderReadyButton = new System.Windows.Forms.Button();
            this.payOrderButton = new System.Windows.Forms.Button();
            this.updateListButton = new System.Windows.Forms.Button();
            this.клиентыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.складыToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.складыИКомпонентыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.компонентыНаСкладахToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справочникToolStripMenuItem,
            this.действияToolStripMenuItem,
            this.отчётыToolStripMenuItem});
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
            this.клиентыToolStripMenuItem});
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
            // действияToolStripMenuItem
            // 
            this.действияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.складыToolStripMenuItem1});
            this.действияToolStripMenuItem.Name = "действияToolStripMenuItem";
            this.действияToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.действияToolStripMenuItem.Text = "Действия";
            // 
            // складыToolStripMenuItem1
            // 
            this.складыToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьКомпонентToolStripMenuItem});
            this.складыToolStripMenuItem1.Name = "складыToolStripMenuItem1";
            this.складыToolStripMenuItem1.Size = new System.Drawing.Size(116, 22);
            this.складыToolStripMenuItem1.Text = "Склады";
            // 
            // добавитьКомпонентToolStripMenuItem
            // 
            this.добавитьКомпонентToolStripMenuItem.Name = "добавитьКомпонентToolStripMenuItem";
            this.добавитьКомпонентToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.добавитьКомпонентToolStripMenuItem.Text = "Добавить компонент";
            this.добавитьКомпонентToolStripMenuItem.Click += new System.EventHandler(this.добавитьКомпонентToolStripMenuItem_Click);
            // 
            // отчётыToolStripMenuItem
            // 
            this.отчётыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.списокКомпонентовToolStripMenuItem,
            this.компонентыПоМашинамToolStripMenuItem,
            this.списокЗаказовToolStripMenuItem,
            this.складыToolStripMenuItem2,
            this.складыИКомпонентыToolStripMenuItem,
            this.компонентыНаСкладахToolStripMenuItem});
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
            // складыToolStripMenuItem
            // 
            this.складыToolStripMenuItem.Name = "складыToolStripMenuItem";
            this.складыToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.складыToolStripMenuItem.Text = "Склады";
            this.складыToolStripMenuItem.Click += new System.EventHandler(this.складыToolStripMenuItem_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(3, 20);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(853, 313);
            this.dataGridView.TabIndex = 1;
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
            // takeOrderInWotkButton
            // 
            this.takeOrderInWotkButton.Location = new System.Drawing.Point(866, 50);
            this.takeOrderInWotkButton.Name = "takeOrderInWotkButton";
            this.takeOrderInWotkButton.Size = new System.Drawing.Size(133, 24);
            this.takeOrderInWotkButton.TabIndex = 3;
            this.takeOrderInWotkButton.Text = "Отдать на выполнение";
            this.takeOrderInWotkButton.UseVisualStyleBackColor = true;
            this.takeOrderInWotkButton.Click += new System.EventHandler(this.takeOrderInWotkButton_Click);
            // 
            // orderReadyButton
            // 
            this.orderReadyButton.Location = new System.Drawing.Point(866, 80);
            this.orderReadyButton.Name = "orderReadyButton";
            this.orderReadyButton.Size = new System.Drawing.Size(133, 23);
            this.orderReadyButton.TabIndex = 4;
            this.orderReadyButton.Text = "Заказ готов";
            this.orderReadyButton.UseVisualStyleBackColor = true;
            this.orderReadyButton.Click += new System.EventHandler(this.orderReadyButton_Click);
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
            // клиентыToolStripMenuItem
            // 
            this.клиентыToolStripMenuItem.Name = "клиентыToolStripMenuItem";
            this.клиентыToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.клиентыToolStripMenuItem.Text = "Клиенты";
            this.клиентыToolStripMenuItem.Click += new System.EventHandler(this.клиентыToolStripMenuItem_Click);
			//
            // складыToolStripMenuItem2
            // 
            this.складыToolStripMenuItem2.Name = "складыToolStripMenuItem2";
            this.складыToolStripMenuItem2.Size = new System.Drawing.Size(208, 22);
            this.складыToolStripMenuItem2.Text = "Склады";
            this.складыToolStripMenuItem2.Click += new System.EventHandler(this.складыToolStripMenuItem2_Click);
            // 
            // складыИКомпонентыToolStripMenuItem
            // 
            this.складыИКомпонентыToolStripMenuItem.Name = "складыИКомпонентыToolStripMenuItem";
            this.складыИКомпонентыToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.складыИКомпонентыToolStripMenuItem.Text = "Склады и компоненты";
            this.складыИКомпонентыToolStripMenuItem.Click += new System.EventHandler(this.складыИКомпонентыToolStripMenuItem_Click);
            // 
            // компонентыНаСкладахToolStripMenuItem
            // 
            this.компонентыНаСкладахToolStripMenuItem.Name = "компонентыНаСкладахToolStripMenuItem";
            this.компонентыНаСкладахToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.компонентыНаСкладахToolStripMenuItem.Text = "Компоненты на складах";
            this.компонентыНаСкладахToolStripMenuItem.Click += new System.EventHandler(this.компонентыНаСкладахToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 334);
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
        private System.Windows.Forms.ToolStripMenuItem складыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem действияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem складыToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem добавитьКомпонентToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отчётыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списокКомпонентовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem компонентыПоМашинамToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списокЗаказовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem клиентыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem складыToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem складыИКомпонентыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem компонентыНаСкладахToolStripMenuItem;
    }
}