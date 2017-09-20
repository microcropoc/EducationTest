using System;
using System.Windows;

namespace EducationTest
{
    /// <summary>
    /// Логика взаимодействия для WindowProjSetting.xaml
    /// </summary>
    public partial class WindowProjSetting : Window
    {
        public WindowProjSetting()
        {
            InitializeComponent();
            this.DataContext = Program.CurrentProject;
           // settingProjNameText.Text = Program.CurrentProject.NameProject;
            settingProjPathText.Text = Program.CurrentProject.PathProject;
            settingProjGUIDText.Text = Program.CurrentProject.GuidProj.ToString();
            settingProjKeyCriptText.Text = Program.CurrentProject.KeyCript;
        }

        private void settingProjGUIDButton_Click(object sender, RoutedEventArgs e)
        {
            settingProjGUIDText.Text = Guid.NewGuid().ToString();
        }

        private void settingCancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void settingOkButton_Click(object sender, RoutedEventArgs e)
        {
            Program.CurrentProject.GuidProj = Guid.Parse(settingProjGUIDText.Text);
            Program.CurrentProject.NameProject = settingProjNameText.Text;
            Program.SaveOrSaveAsProject(Program.PathProject);
            Close();
        }

    }
}
