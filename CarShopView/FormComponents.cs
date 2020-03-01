using CarShopBuisnessLogic.BindingModels;
using CarShopBuisnessLogic.Interfaces;
using System;
using System.Windows.Forms;
using Unity;

namespace CarShopView
{
    public partial class FormComponents : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly IComponentLogic componentLogic;

        public FormComponents(IComponentLogic componentLogic)
        {
            InitializeComponent();
            this.componentLogic = componentLogic;
        }
        private void FormComponents_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            try 
            { 
                var componentList = componentLogic.Read(null);
                if (componentList != null)
                {
                    dataGridView.DataSource = componentList;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void createComponent_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormComponent>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void updateComponent_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormComponent>();
                form.Id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void deleteComponent_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                    try
                    {
                        componentLogic.Delete(new ComponentBindingModel { Id = id });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }

        private void updateList_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}