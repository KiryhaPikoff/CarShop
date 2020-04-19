using CarShopBuisnessLogic.ViewModels;
using System;
using System.Windows.Forms;

namespace CarShopClientView
{
    public partial class FormEnter : Form
    {
        public FormEnter()
        {
            InitializeComponent();
            Program.Client = null;
        }
        private void ButtonRegister_Click(object sender, EventArgs e)
        {
            FormRegister form = new FormRegister();
            form.ShowDialog();
        }
        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxEmail.Text) &&
           !string.IsNullOrEmpty(textBoxPassword.Text))
            {
                try
                {
                    Program.Client = APIClient.GetRequest<ClientViewModel>($"api/client/login?login={textBoxEmail.Text}&password={ textBoxPassword.Text}");
                    if (Program.Client == null)
                    {
                        throw new Exception("Неверный логин или пароль");
                    }
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Введите логин и пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
