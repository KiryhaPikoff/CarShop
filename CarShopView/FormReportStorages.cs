using CarShopBuisnessLogic;
using CarShopBuisnessLogic.BindingModels;
using System;
using System.Windows.Forms;
using Unity;

namespace CarShopView
{
    public partial class FormReportStorages : Form
    {
        [Dependency]
        public new IUnityContainer container { get; set; }

        private readonly ReportLogic logic;

        public FormReportStorages(ReportLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        public FormReportStorages()
        {
            InitializeComponent();
        }

        private void saveToExcelButton_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog { Filter = "xlsx|*.xlsx" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        logic.SaveStoragesToExcelFile(new ReportBindingModel
                        {
                            FileName = dialog.FileName
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

        private void FormReportStorages_Load(object sender, EventArgs e)
        {
            var storages = logic.GetStorageWithComponents();
            if (storages != null)
            {
                dataGridView.Rows.Clear();
                foreach (var storage in storages)
                {
                    dataGridView.Rows.Add(new object[] { storage.StorageName, "", "" });
                    foreach (var component in storage.Components)
                    {
                        dataGridView.Rows.Add(new object[] { "", component.Item1, component.Item2 });
                    }
                    dataGridView.Rows.Add(new object[] { "---", "---", storage.TotalCount });
                }
            }
        }
    }
}
