using CarShopBuisnessLogic;
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

        private void toPdfButton_Click(object sender, EventArgs e)
        {

        }
    }
}
