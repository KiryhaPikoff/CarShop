using CarShopBuisnessLogic.BindingModels;
using CarShopBuisnessLogic.Interfaces;
using System;
using System.Windows.Forms;
using Unity;

namespace CarShopView
{
    public partial class FormImplementer : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly IImplementerLogic implementerLogic;

        public int Id { set { id = value; } }

        private int? id;

        public FormImplementer(IImplementerLogic implementerLogic)
        {
            InitializeComponent();
            this.implementerLogic = implementerLogic;

        }

        private void FormImplementer_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    var view = implementerLogic.Read(new ImplementerBindingModel { Id = id })?[0];
                    if (view != null)
                    {
                        fioTextBox.Text = view.ImplementerFIO;
                        workingTimeTextBox.Text = view.WorkingTime.ToString();
                        pauseTimeTextBox.Text = view.PauseTime.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(fioTextBox.Text))
            {
                MessageBox.Show("Заполните ФИО", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(workingTimeTextBox.Text))
            {
                MessageBox.Show("Заполните время на выполнения", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(pauseTimeTextBox.Text))
            {
                MessageBox.Show("Заполните время на отдых", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                implementerLogic.CreateOrUpdate(new ImplementerBindingModel
                { 
                    Id = id,
                    ImplementerFIO = fioTextBox.Text,
                    WorkingTime = Convert.ToInt32(workingTimeTextBox.Text),
                    PauseTime = Convert.ToInt32(pauseTimeTextBox.Text)
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

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
