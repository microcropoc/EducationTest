using System.Windows;
using System.Windows.Controls;

namespace EducationTest
{
    /// <summary>
    /// Логика взаимодействия для WindowStudentSettingAccountEditPassword.xaml
    /// </summary>
    public partial class WindowStudentSettingAccountEditPassword : Window
    {
        public WindowStudentSettingAccountEditPassword()
        {
            InitializeComponent();
        }

        private void editAccNewPass_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (editAccNewPass.Text != string.Empty)
            {
                if (editAccNewPass.Text == editAccAddNewPass.Text)
                {
                    editAccPassOk.IsEnabled = true;
                }
                else
                {
                    editAccPassOk.IsEnabled = false;
                }
            }
            else
                editAccPassOk.IsEnabled = false;
        }

        private void editAccAddNewPass_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (editAccNewPass.Text != string.Empty)
            {
                if (editAccNewPass.Text == editAccAddNewPass.Text)
                {
                    editAccPassOk.IsEnabled = true;
                }
                else
                {
                    editAccPassOk.IsEnabled = false;
                }
            }
            else
                editAccPassOk.IsEnabled = false;
        }

        private void editAccPassOk_Click(object sender, RoutedEventArgs e)
        {
            Program.CurrentAccount.Password = editAccNewPass.Text;
            Close();
        }

        private void editAccPassCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
