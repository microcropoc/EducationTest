using System.Windows;

namespace EducationTest
{
    /// <summary>
    /// Логика взаимодействия для WindowStudentAuthorizationAccount.xaml
    /// </summary>
    public partial class WindowStudentAuthorizationAccount : Window
    {
        private StudentAccount tempAccount;
        public WindowStudentAuthorizationAccount()
        {
            InitializeComponent();
            UserNameText.Text = Program.CurrentAccount.Name;
            tempAccount = Program.CurrentAccount;
            Program.CurrentAccount = null;
        }

        private void okAccountCreateButton_Click(object sender, RoutedEventArgs e)
        {
            if (tempAccount.Password != PasswordText.Text)
            {
                WindowMsgError errorPass = new WindowMsgError("Ошибка авторизации", "Пароль не верный");
                errorPass.ShowDialog();
                Close();
            }
            else
            {
                Program.CurrentAccount = tempAccount;
                Close();
            }
        }

        private void authAccountCancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
