using CarShopBuisnessLogic.BindingModels;
using CarShopBuisnessLogic.Interfaces;
using System;
using System.Windows.Forms;
using Unity;

namespace CarShopView
{
    public partial class FormComponent : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id { set { id = value; } }

        private int? id;

        private readonly IComponentLogic componentLogic;

        public FormComponent(IComponentLogic componentLogic)
        {
            InitializeComponent();
            this.componentLogic = componentLogic;
        }

        private void FormComponent_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    var view = componentLogic.Read(new ComponentBindingModel { Id = id })?[0];
                    if (view != null)
                    {
                        nameComponentTextBox.Text = view.ComponentName;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
        }

        private void SaveComponentButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(nameComponentTextBox.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                componentLogic.CreateOrUpdate(new ComponentBindingModel
                {
                    Id = id,
                    ComponentName = nameComponentTextBox.Text
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

        private void CancelComponentButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}