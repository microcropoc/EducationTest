using System.Windows;
using System.Windows.Controls;

namespace EducationTest
{
    /// <summary>
    /// Логика взаимодействия для WindowStudentCreateAccount.xaml
    /// </summary>
    public partial class WindowStudentCreateAccount : Window
    {

        public WindowStudentCreateAccount()
        {
            InitializeComponent();
            createAccountCreateButton.IsEnabled = false;
        }

        private void createAccountCreateButton_Click(object sender, RoutedEventArgs e)
        {
            Program.CreateAccount(UserNameText.Text, PasswordText.Text);
            Close();
        }

        private void createAccountCancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void UserNameText_TextChanged(object sender, TextChangedEventArgs e)
        {
            if((UserNameText.Text!=string.Empty)&& (PasswordText.Text!=string.Empty) &&(AddPasswordText.Text!=string.Empty))
                if (PasswordText.Text.Equals(AddPasswordText.Text))
                {
                    createAccountCreateButton.IsEnabled = true;
                }

        }

        private void PasswordText_TextChanged(object sender, TextChangedEventArgs e)
        {
            if ((UserNameText.Text != string.Empty) && (PasswordText.Text != string.Empty) && (AddPasswordText.Text != string.Empty))
                if (PasswordText.Text.Equals(AddPasswordText.Text))
                {
                    createAccountCreateButton.IsEnabled = true;
                    return;
                }
            createAccountCreateButton.IsEnabled = false;
        }

        private void AddPasswordText_TextChanged(object sender, TextChangedEventArgs e)
        {
            if ((UserNameText.Text != string.Empty) && (PasswordText.Text != string.Empty) && (AddPasswordText.Text != string.Empty))
                if (PasswordText.Text.Equals(AddPasswordText.Text))
                {
                    createAccountCreateButton.IsEnabled = true;
                    return;
                }
            createAccountCreateButton.IsEnabled = false;


        }
    }
}
