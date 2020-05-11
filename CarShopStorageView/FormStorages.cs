using CarShopBuisnessLogic.BindingModels;
using CarShopBuisnessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;

namespace CarShopStorageView
{
    public partial class FormStorages : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        public FormStorages()
        {
            InitializeComponent();
        }

        private void FormStorages_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var storageList = APIClient.GetRequest<List<StorageViewModel>>("api/storage/getstorages");
                if (storageList != null)
                {
                    dataGridView.DataSource = storageList;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView.Columns[2].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void createStorageButton_Click(object sender, EventArgs e)
        {
            var form = new FormStorage();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void updateStorageButton_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = new FormStorage();
                form.Id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void addComponentButton_Click(object sender, EventArgs e)
        {
            var form = new FormStorageComponent();
            if (form.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    APIClient.PostRequest<AddComponentBindingModel>("api/storage/addcomponentonstorage", new AddComponentBindingModel
                    {
                        StorageId = form.StorageId,
                        ComponentId = form.ComponentId,
                        Count = form.Count
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void deleteStorageButton_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                    try
                    {
                        APIClient.PostRequest<StorageBindingModel>("api/storage/deletestorage", new StorageBindingModel { Id = id });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }

        private void refreshStoragesButton_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}