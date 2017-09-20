using System.Windows;

namespace EducationTest
{
    /// <summary>
    /// Логика взаимодействия для WindowMsgError.xaml
    /// </summary>
    public partial class WindowMsgError : Window
    {
        public WindowMsgError(string header,string text)
        {
            InitializeComponent();
            msgHeader.Header = header;
            msgText.Content = text; 
        }

        private void ExitMsg_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
