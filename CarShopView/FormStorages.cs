using CarShopBuisnessLogic.BindingModels;
using CarShopBuisnessLogic.Interfaces;
using System;
using System.Windows.Forms;
using Unity;

namespace CarShopView
{
    public partial class FormStorages : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly IStorageLogic storageLogic;

        public FormStorages(IStorageLogic storageLogic)
        {
            InitializeComponent();
            this.storageLogic = storageLogic;
        }

        private void FormStorages_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var storageList = storageLogic.Read(null);
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
            var form = Container.Resolve<FormStorage>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void updateStorageButton_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormStorage>();
                form.Id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
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
                        storageLogic.Delete(new StorageBindingModel { Id = id });
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