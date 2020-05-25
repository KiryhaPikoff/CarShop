using CarShopBuisnessLogic.BindingModels;
using CarShopBuisnessLogic.Interfaces;
using CarShopBuisnessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;

namespace CarShopView
{
    public partial class FormCar : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        public int Id { set { id = value; } }

        private readonly ICarLogic carLogic;

        private int? id;

        private Dictionary<int, (string, int)> carComponents;

        public FormCar(ICarLogic carLogic)
        {
            InitializeComponent();
            this.carLogic = carLogic;
        }
        private void FormCar_Load(object sender, EventArgs e)
        {
            dataGridView.Columns.Add("Id", "Id");
            dataGridView.Columns.Add("Компонент", "Компонент");
            dataGridView.Columns.Add("Количество", "Количество");
            if (id.HasValue)
            {
                try
                {
                    CarViewModel view = carLogic.Read(new CarBindingModel
                    {
                        Id = id.Value
                    })?[0];
                    if (view != null)
                    {
                        nameCarTextBox.Text = view.CarName;
                        priceCarTextBox.Text = view.Price.ToString();
                        carComponents = view.CarComponents;
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
                carComponents = new Dictionary<int, (string, int)>();
            }

        }

        private void LoadData()
        {
            try
            {

                if (carComponents != null)
                {
                    dataGridView.Rows.Clear();
                    foreach (var carComponent in carComponents)
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

     /*   private void LoadData()
        {
            try
            {
                Program.ConfigGrid(logic.Read(null), dataGridView);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }*/

        private void CreateCarButton_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormCarComponent>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (carComponents.ContainsKey(form.Id))
                {
                    carComponents[form.Id] = (form.ComponentName, form.Count);
                }
                else
                {
                    carComponents.Add(form.Id, (form.ComponentName, form.Count));
                }
                LoadData();
            }
        }

        private void UpdateCatButton_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormCarComponent>();
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                form.Id = id;
                form.Count = carComponents[id].Item2;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    carComponents[form.Id] = (form.ComponentName, form.Count);
                    LoadData();
                }
            }
        }

        private void DeleteCarButton_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo,
               MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        carComponents.Remove(Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value));
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

        private void UpdateListButton_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(nameCarTextBox.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(priceCarTextBox.Text))
            {
                MessageBox.Show("Заполните цену", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (carComponents == null || carComponents.Count == 0)
            {
                MessageBox.Show("Заполните компоненты", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                carLogic.CreateOrUpdate(new CarBindingModel
                {
                    Id = id,
                    CarName = nameCarTextBox.Text,
                    Price = Convert.ToDecimal(priceCarTextBox.Text),
                    CarComponents = carComponents
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

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
