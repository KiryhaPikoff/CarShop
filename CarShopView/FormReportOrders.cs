using CarShopBuisnessLogic;
using CarShopBuisnessLogic.BindingModels;
using System;
using System.Linq;
using System.Windows.Forms;
using Unity;

namespace CarShopView
{
    public partial class FormReportOrders : Form
    {
        [Dependency]
        public new IUnityContainer container { get; set; }

        private readonly ReportLogic logic;

        public FormReportOrders(ReportLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private void saveToExcelButton_Click(object sender, EventArgs e)
        {
            if (dateTimePickerFrom.Value.Date >= dateTimePickerTo.Value.Date)
            {
                MessageBox.Show("Дата начала должна быть меньше даты окончания", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            using (var dialog = new SaveFileDialog { Filter = "xlsx|*.xlsx" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        logic.SaveOrdersToExcelFile(new ReportBindingModel
                        {
                            FileName = dialog.FileName,
                            DateFrom = dateTimePickerFrom.Value,
                            DateTo = dateTimePickerTo.Value
                        });
                        MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void buttonForm_Click(object sender, EventArgs e)
        {
            if (dateTimePickerFrom.Value.Date >= dateTimePickerTo.Value.Date)
            {
                MessageBox.Show("Дата начала должна быть меньше даты окончания", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                var orders = logic.GetOrders(new ReportBindingModel
                {
                    DateFrom = dateTimePickerFrom.Value,
                    DateTo = dateTimePickerTo.Value
                });
                if (orders != null)
                {
                    dataGridView.Rows.Clear();
                    foreach (var group in orders)
                    {
                        dataGridView.Rows.Add(new object[] { group.Key.ToString(), "", "", "", "" });
                        foreach (var order in group)
                        {
                            dataGridView.Rows.Add(new object[] { "", order.CarName, order.Count, order.Sum, order.Status });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }
    }
}