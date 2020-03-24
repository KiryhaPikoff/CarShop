using CarShopBuisnessLogic.BindingModels;
using CarShopBuisnessLogic.Interfaces;
using CarShopBuisnessLogic.ViewModels;
using CarShopListImplement.Implements;
using System;
using System.Windows.Forms;
using Unity;

namespace CarShopView
{
    public partial class FormCreateOrder : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly ICarLogic carLogic;

        private readonly MainLogic mainLogic;

        public FormCreateOrder(ICarLogic carLogic, MainLogic mainLogic)
        {
            InitializeComponent();
            this.carLogic = carLogic;
            this.mainLogic = mainLogic;
        }

        private void FormCreateOrder_Load(object sender, EventArgs e)
        {
            try
            {
                var carList = carLogic.Read(null);
                if (carList != null)
                {
                    carComboBox.DisplayMember = "CarName";
                    carComboBox.ValueMember = "Id";
                    carComboBox.DataSource = carList;
                    carComboBox.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalcSum()
        {
            if (carComboBox.SelectedValue != null && !string.IsNullOrEmpty(countTextBox.Text))
            {
                try
                {
                    int id = Convert.ToInt32(carComboBox.SelectedValue);
                    CarViewModel product = carLogic.Read(new CarBindingModel
                    {
                        Id = id
                    })?[0];
                    int count = Convert.ToInt32(countTextBox.Text);
                    sumTextBox.Text = (count * product?.Price ?? 0).ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void countTextBox_TextChanged(object sender, EventArgs e)
        {
            CalcSum();
        }

        private void carComboBox_TextChanged(object sender, EventArgs e)
        {
            CalcSum();
        }

        private void saveOrderButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(countTextBox.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (carComboBox.SelectedValue == null)
            {
                MessageBox.Show("Выберите изделие", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                mainLogic.CreateOrder(new CreateOrderBindingModel
                {
                    CarId = Convert.ToInt32(carComboBox.SelectedValue),
                    Count = Convert.ToInt32(countTextBox.Text),
                    Sum = Convert.ToDecimal(sumTextBox.Text)
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

        private void cancelOrderButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}