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
        [Dependency]
        public new IUnityContainer Container { get; set; }

        public int Id
        {
            get { return Convert.ToInt32(componentsComboBox.SelectedValue); }
            set { componentsComboBox.SelectedValue = value; }
        }
        public string ComponentName
        {
            get { return componentsComboBox.Text; }
        }
        public int Count
        {
            get { return Convert.ToInt32(countTextBox.Text); }
            set { countTextBox.Text = value.ToString(); }
        }

        public FormStorageComponent(IComponentLogic componentLogic)
        {
            InitializeComponent();
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
