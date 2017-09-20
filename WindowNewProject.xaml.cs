using System.Windows;

namespace EducationTest
{
    /// <summary>
    /// Логика взаимодействия для WindowNewProject.xaml
    /// </summary>
    public partial class WindowNewProject : Window
    {

        private MainWindow MajorWindow;
        private string NameProject;

        public WindowNewProject(MainWindow wind)
        {
            MajorWindow = wind;
            InitializeComponent();
        }
        public WindowNewProject()
        {
            
            InitializeComponent();
        }

        private void createNewProjBtn_Click(object sender, RoutedEventArgs e)
        {
            NameProject = createNewProjText.Text;
            if (NameProject == string.Empty)
            {
                WindowMsgError errorStrEmpty = new WindowMsgError("Ошибка", "Имя не введено");
                errorStrEmpty.ShowDialog();
            }
            else
            {
                //инициализация текущего проекта
                #region initCurrentProject

                if (Program.NewProject(NameProject))
                {
                    MajorWindow.NameProjGB.Header = NameProject;
                    Close();
                }

                #endregion
            }
           // Close();   
      
        }

        private void cancelNewProjBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
