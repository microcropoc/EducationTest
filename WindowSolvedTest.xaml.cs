using System;
using System.Windows;

namespace EducationTest
{
    /// <summary>
    /// Логика взаимодействия для WindowSolvedTest.xaml
    /// </summary>
    public partial class WindowSolvedTest : Window
    {
        public WindowSolvedTest()
        {
            InitializeComponent();

            #region re-count
            int countQuestion = Program.CurrentProject.CountQuestions;
            int countAnswers = 0;
            int countTrunessAnswers = 0;
            int countStudentAnswers = 0;
            int countTrunessStudentAnswers = 0;
            foreach (Question selectQ in Program.CurrentProject.Questions)
            {
                countAnswers += selectQ.CountAnswers;
                foreach (Answer selectA in selectQ.Answers)
                {
                    if (selectA.selectVarStudent)
                    {
                        ++countStudentAnswers;
                        if (selectA.Trueness)
                        {
                            ++countTrunessStudentAnswers;
                        }
                    }

                    if (selectA.Trueness)
                    {
                        ++countTrunessAnswers;
                    }
                }
            }
            #endregion

            StudentSolvedTest solvedTest = new StudentSolvedTest(Program.CurrentProject.NameProject, Program.CurrentProject.GuidProj)
            {
                TimeTest = DateTime.Now,
                CountQuestions = countQuestion,
                CountAnswers = countAnswers,
                CountStudentAnswers = countStudentAnswers,
                CountTrunessAnswers = countTrunessAnswers,
                CountTrunessStudentAnswers = countTrunessStudentAnswers
            };

            Program.CurrentAccount.SolvedTests.Add(solvedTest);

            Program.SaveAccount(Program.PathAccount);

            stestName.Header = Program.CurrentProject.NameProject;
            stestCountQuestions.Text = Convert.ToString(countQuestion);
            stestCountAnswers.Text = Convert.ToString(countAnswers);
            stestCountStudentAnswers.Text = Convert.ToString(countStudentAnswers);
            stestCountTrunessAnswers.Text = Convert.ToString(countTrunessAnswers);
            stestCountTrunessStudentAnswers.Text = Convert.ToString(countTrunessStudentAnswers);
            // отчистка выбранных студентом вариантов ответа
            Program.CurrentProject.clearStudentSelectVarAnswer();
        }

        private void stestCancelWindow_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
