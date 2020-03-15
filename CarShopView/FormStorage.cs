using CarShopBuisnessLogic.BindingModels;
using CarShopBuisnessLogic.Interfaces;
using CarShopBuisnessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;

namespace CarShopView
{
    public partial class FormStorage : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        public int Id { set { id = value; } }

        private readonly IStorageLogic storageLogic;

        private int? id;

        private Dictionary<int, (string, int)> storageComponents;

        public FormStorage(IStorageLogic storageLogic)
        {
            InitializeComponent();
            this.storageLogic = storageLogic;
        }

        private void FormCar_Load(object sender, EventArgs e)
        {
            dataGridView.Columns.Add("Id", "Id");
            dataGridView.Columns.Add("Компонент", "Компонент");
            dataGridView.Columns.Add("Количество", "Количество");
            dataGridView.Columns[0].Visible = false;
            dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            if (id.HasValue)
            {
                try
                {
                    StorageViewModel view = storageLogic.Read(new StorageBindingModel
                    {
                        Id = id.Value
                    })?[0];
                    if (view != null)
                    {
                        storageNameTextBox.Text = view.StorageName;
                        storageComponents = view.StorageComponents;
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                storageComponents = new Dictionary<int, (string, int)>();
            }
        }

        private void LoadData()
        {
            try
            {

                if (storageComponents != null)
                {
                    dataGridView.Rows.Clear();
                    foreach (var carComponent in storageComponents)
                    {
                        dataGridView.Rows.Add(new object[] { carComponent.Key, carComponent.Value.Item1, carComponent.Value.Item2 });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void addComponentButton_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormCarComponent>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (storageComponents.ContainsKey(form.Id))
                {
                    storageComponents[form.Id] = (form.ComponentName, form.Count);
                }
                else
                {
                    storageComponents.Add(form.Id, (form.ComponentName, form.Count));
                }
                LoadData();
            }
        }

        private void updateComponentButton_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormCarComponent>();
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                form.Id = id;
                form.Count = storageComponents[id].Item2;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    storageComponents[form.Id] = (form.ComponentName, form.Count);
                    LoadData();
                }
            }
        }

        private void deleteComponentButton_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo,
               MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        storageComponents.Remove(Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }

        private void refreshComponentsButton_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(storageNameTextBox.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (storageComponents == null || storageComponents.Count == 0)
            {
                MessageBox.Show("Заполните компоненты", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                storageLogic.CreateOrUpdate(new StorageBindingModel
                {
                    Id = id,
                    StorageName = storageNameTextBox.Text,
                    StorageComponents = storageComponents
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cancleButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}