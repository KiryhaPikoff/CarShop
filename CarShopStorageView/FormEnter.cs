using System;
using System.Configuration;
using System.Windows.Forms;

namespace CarShopStorageView
{
    public partial class FormEnter : Form
    {
        public FormEnter()
        {
            InitializeComponent();
        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxEmail.Text) && !string.IsNullOrEmpty(textBoxPassword.Text))
            {
                if (textBoxEmail.Text == ConfigurationManager.AppSettings["Login"] &&
                    textBoxPassword.Text == ConfigurationManager.AppSettings["Password"])
                {
                    Program.isLogged = true;
                    Close();
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Введите логин и пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
