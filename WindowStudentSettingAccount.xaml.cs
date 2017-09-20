using System.Windows;

namespace EducationTest
{
    /// <summary>
    /// Логика взаимодействия для WindowStudentSettingAccount.xaml
    /// </summary>
    public partial class WindowStudentSettingAccount : Window
    {
        public WindowStudentSettingAccount()
        {
            InitializeComponent();
            if (Program.CurrentAccount != null)
            {
                setAccName.Text = Program.CurrentAccount.Name;
                setAccPassword.Text = Program.CurrentAccount.Password;
                setAccSolvedTestListDG.ItemsSource = Program.CurrentAccount.SolvedTests;
            }
        }

        private void settingCancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void settingOkButton_Click(object sender, RoutedEventArgs e)
        {
            Program.CurrentAccount.Name = setAccName.Text;
            Program.CurrentAccount.Password = setAccPassword.Text;
            Program.SaveAccount(Program.PathAccount);
            Close();
        }

        private void setAccPasswordEditButton_Click(object sender, RoutedEventArgs e)
        {
            WindowStudentSettingAccountEditPassword editPass = new WindowStudentSettingAccountEditPassword();
            editPass.ShowDialog();
            setAccPassword.Text = Program.CurrentAccount.Password;
        }
    }
}
