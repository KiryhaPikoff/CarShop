using CarShopBuisnessLogic.Interfaces;
using CarShopBuisnessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;

namespace CarShopView
{
    public partial class FormStorageComponent : Form
    {
        public FormStorageComponent(IStorageLogic storageLogic, IComponentLogic componentLogic)
        {
            InitializeComponent();
            List<StorageViewModel> storageList = storageLogic.Read(null);
            if (storageList != null)
            {
                componentsComboBox.DisplayMember = "StorageName";
                componentsComboBox.ValueMember = "Id";
                componentsComboBox.DataSource = storageList;
                componentsComboBox.SelectedItem = null;
            }
            List<ComponentViewModel> componentList = componentLogic.Read(null);
            if (componentList != null)
            {
                componentsComboBox.DisplayMember = "ComponentName";
                componentsComboBox.ValueMember = "Id";
                componentsComboBox.DataSource = componentList;
                componentsComboBox.SelectedItem = null;
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(countTextBox.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (componentsComboBox.SelectedValue == null)
            {
                MessageBox.Show("Выберите компонент", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (storageComboBox.SelectedValue == null)
            {
                MessageBox.Show("Выберите склад", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        private void cancleButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
