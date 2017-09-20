using System;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace EducationTest
{
    /// <summary>
    /// Логика взаимодействия для WindowPreviewProject.xaml
    /// </summary>
    public partial class WindowPreviewProject : Window
    {
        private bool loadTextInCurrentProject(){
            FlowDocument docProject = new FlowDocument();
            try
            {
                Paragraph parHead = new Paragraph();
                parHead.Inlines.Add(new Bold(new Run("Тест (" + Program.CurrentProject.NameProject + ")" + Environment.NewLine) { Background = Brushes.Azure, FontSize=FontSize+2 }));
                parHead.Inlines.Add(new Run("----------------------------------------------------------------"));
                docProject.Blocks.Add(parHead);
                foreach (Question selectQuest in Program.CurrentProject.Questions)
                {
                    Paragraph parQuestion = new Paragraph();
                    parQuestion.Background = Brushes.WhiteSmoke;
                    parQuestion.Inlines.Add(new Bold(new Run("Вопрос № " + selectQuest.id + Environment.NewLine)));
                    parQuestion.Inlines.Add(new Run("----------------------------------------------------------------------" + Environment.NewLine));
                    parQuestion.Inlines.Add(new Run(selectQuest.Text + Environment.NewLine));
                    parQuestion.Inlines.Add(new Run("----------------------------------------------------------------------" + Environment.NewLine));
                    parQuestion.Inlines.Add(new Run(Environment.NewLine));
                    docProject.Blocks.Add(parQuestion);

                    foreach (Answer selectAnsw in selectQuest.Answers)
                    {
                       // Paragraph parAnswer= new Paragraph();
                        
                        if (selectAnsw.Trueness)
                        {
                            parQuestion.Inlines.Add(new Italic(new Run("Ответ № " + selectAnsw.id + Environment.NewLine) { Background = Brushes.GreenYellow, FontSize=FontSize+1}));
                            parQuestion.Inlines.Add(new Run("--------------------------------" + Environment.NewLine) { Background = Brushes.GreenYellow, FontSize = FontSize + 1 });
                            parQuestion.Inlines.Add(new Run(selectAnsw.Text + Environment.NewLine) { Background = Brushes.GreenYellow, FontSize = FontSize + 1 });
                            parQuestion.Inlines.Add(new Run("--------------------------------" + Environment.NewLine) { Background = Brushes.GreenYellow, FontSize = FontSize + 1 });
                            parQuestion.Inlines.Add(new Run(Environment.NewLine));
                        }
                        else
                        {
                            parQuestion.Inlines.Add(new Italic(new Run("Ответ № " + selectAnsw.id + Environment.NewLine) { Background = Brushes.Gray, FontSize = FontSize + 1 }));
                            parQuestion.Inlines.Add(new Run("--------------------------------" + Environment.NewLine) { Background = Brushes.Gray, FontSize = FontSize + 1 });
                            parQuestion.Inlines.Add(new Run(selectAnsw.Text + Environment.NewLine) { Background = Brushes.Gray, FontSize = FontSize + 1 });
                            parQuestion.Inlines.Add(new Run("--------------------------------" + Environment.NewLine) { Background = Brushes.Gray, FontSize = FontSize + 1 });
                            parQuestion.Inlines.Add(new Run(Environment.NewLine));
                        }
                        
                        docProject.Blocks.Add(parQuestion);
                    }

                }

                PreviewTextBlock.Document = docProject;
            }
            catch (Exception)
            {
                PreviewTextBlock.Document = new FlowDocument();
                return false;
            }

            return true;
        }
        public WindowPreviewProject()
        {
            InitializeComponent();

            if(!loadTextInCurrentProject()){
                
            }
        }

        private void previewCancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
