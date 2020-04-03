using CarShopBuisnessLogic;
using CarShopBuisnessLogic.BindingModels;
using Microsoft.Reporting.WinForms;
using System;
using System.Windows.Forms;
using Unity;

namespace CarShopView
{
    public partial class FormReportCarComponents : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly ReportLogic reportLogic;

        public FormReportCarComponents(ReportLogic logic)
        {
            InitializeComponent();
            this.reportLogic = logic;
        }


        private void FormReportCarComponents_Load(object sender, System.EventArgs e)
        {
            try
            {
                var dataSource = reportLogic.GetCarComponentsWithCar();
                ReportDataSource source = new ReportDataSource("DataSetCarComp", dataSource);
                reportViewer.LocalReport.DataSources.Clear();
                reportViewer.LocalReport.DataSources.Add(source);
                reportViewer.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        [Obsolete]
        private void toPdfButton_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog { Filter = "pdf|*.pdf" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        reportLogic.SaveCarsWithComponentsToPdfFile(new ReportBindingModel
                        {
                            FileName = dialog.FileName,
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
    }
}
