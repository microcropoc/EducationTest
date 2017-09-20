using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace EducationTest
{
    /// <summary>
    /// Логика взаимодействия для WindowStudentTesting.xaml
    /// </summary>
    public partial class WindowStudentTesting : Window
    {

        public int currentNumQuest = 1;

        #region InstantinateFormElement

        #region Answer
        class structAnswer
        {
            public string textAnswer { get { return testAnswer1TextBlock.Text; } set { testAnswer1TextBlock.Text = value; } }
            public GroupBox blockAnswerGB { get { return testAnswer1Group; }  }
            GroupBox testAnswer1Group;
            TextBlock testAnswer1TextBlock;
            Separator testAnswer1Separator;
            int NumQuest;
            int NumAnswer;
            public structAnswer(string textAnswer,int numQuest,int numAnswer)
            {
                NumQuest = numQuest;
                NumAnswer = numAnswer;
                if (!Program.CurrentProject.Questions.FirstOrDefault(p => p.id == NumQuest).Answers.FirstOrDefault(p => p.id == NumAnswer).selectVarStudent)
                    testAnswer1Group = new GroupBox() { Header = "Ответ №" + NumAnswer, Background = Brushes.LightGoldenrodYellow, Margin = new Thickness(2) };
                else
                    testAnswer1Group = new GroupBox() { Header = "Ответ №" + NumAnswer, Background = Brushes.Gold, Margin = new Thickness(2) };
                    

                testAnswer1TextBlock = new TextBlock() { Margin = new Thickness(5), TextWrapping = TextWrapping.Wrap, TextAlignment = TextAlignment.Center };
                testAnswer1TextBlock.Text = textAnswer;
                testAnswer1Group.MouseDown += new MouseButtonEventHandler(textAnswer1TextBlock_MouseDown);
                testAnswer1Separator = new Separator();
                testAnswer1Group.Content = testAnswer1TextBlock;
            }

     

            private void textAnswer1TextBlock_MouseDown(object sender, MouseEventArgs e)
            {
               if (Program.CurrentProject.Questions.FirstOrDefault(p=>p.id == NumQuest).Answers.FirstOrDefault(p=>p.id==NumAnswer).selectVarStudent)
               {
                   Program.CurrentProject.Questions.FirstOrDefault(p => p.id == NumQuest).Answers.FirstOrDefault(p => p.id == NumAnswer).selectVarStudent = false;
                   testAnswer1Group.Background = Brushes.LightGoldenrodYellow;
               }
               else
               {
                   Program.CurrentProject.Questions.FirstOrDefault(p => p.id == NumQuest).Answers.FirstOrDefault(p => p.id == NumAnswer).selectVarStudent = true;
                   testAnswer1Group.Background = Brushes.Gold;
               }
            }
            public void clear()
            {
                testAnswer1TextBlock.Text="";
            }
        }

        #endregion

        #endregion

        #region userMethod

        private void enabledStudentTestingWindowButton(bool check)
        {
            if (check)
            {
                testBackButton.IsEnabled = true;
                testNextButton.IsEnabled = true;
                testPassTheTestButton.IsEnabled = true;
            }
            else
            {
                testBackButton.IsEnabled = false;
                testNextButton.IsEnabled = false;
                testPassTheTestButton.IsEnabled = false;
            }
        }

        private void enabledStudentTestingWindowMenu(bool check)
        {
            if (check)
            {
                TestMenu.IsEnabled = true;
                ViewAccountMenu.IsEnabled = true;
            }
            else
            {
                TestMenu.IsEnabled = false;
                ViewAccountMenu.IsEnabled = false;
            }
        }

        private void clearStudentTestingWindow()
        {
            testQuestionText.Text = "";
            testAnswerList.Children.Clear();
        }

        private bool viewTestInStudentTestingWindow(int idQuestion)
        {
            if (Program.CurrentProject != null)
            {
                if (idQuestion <= Program.CurrentProject.CountQuestions)
                {
                    Question viewQuestion = Program.CurrentProject.Questions.FirstOrDefault(j => j.id == idQuestion);
                    testNameGB.Header = Program.CurrentProject.NameProject;
                    testQuestionText.Text = viewQuestion.Text;
                    testAnswerList.Children.Clear();
                        switch(viewQuestion.CountAnswers)
                        {
                            #region Answers

                            #region colAnswer1

                            case 1:
                                structAnswer Answer1 = new structAnswer(viewQuestion.Answers.FirstOrDefault(j => j.id == 1).Text,currentNumQuest,1);
                                testAnswerList.Children.Add(Answer1.blockAnswerGB);
                            break;

                            #endregion

                            #region colAnswer2

                            case 2:
                            structAnswer Answer2_1 = new structAnswer(viewQuestion.Answers.FirstOrDefault(j => j.id == 1).Text, currentNumQuest, 1);
                            structAnswer Answer2_2 = new structAnswer(viewQuestion.Answers.FirstOrDefault(j => j.id == 2).Text, currentNumQuest, 2);
                            testAnswerList.Children.Add(Answer2_1.blockAnswerGB);
                            testAnswerList.Children.Add(Answer2_2.blockAnswerGB);
                            break;

                            #endregion

                            #region colAnswer3

                            case 3:
                            structAnswer Answer3_1 = new structAnswer(viewQuestion.Answers.FirstOrDefault(j => j.id == 1).Text, currentNumQuest, 1);
                            structAnswer Answer3_2 = new structAnswer(viewQuestion.Answers.FirstOrDefault(j => j.id == 2).Text, currentNumQuest, 2);
                            structAnswer Answer3_3 = new structAnswer(viewQuestion.Answers.FirstOrDefault(j => j.id == 3).Text, currentNumQuest, 3);
                            testAnswerList.Children.Add(Answer3_1.blockAnswerGB);
                            testAnswerList.Children.Add(Answer3_2.blockAnswerGB);
                            testAnswerList.Children.Add(Answer3_3.blockAnswerGB);
                            break;

                            #endregion

                            #region colAnswer4

                            case 4:
                            structAnswer Answer4_1 = new structAnswer(viewQuestion.Answers.FirstOrDefault(j => j.id == 1).Text, currentNumQuest, 1);
                            structAnswer Answer4_2 = new structAnswer(viewQuestion.Answers.FirstOrDefault(j => j.id == 2).Text, currentNumQuest, 2);
                            structAnswer Answer4_3 = new structAnswer(viewQuestion.Answers.FirstOrDefault(j => j.id == 3).Text, currentNumQuest, 3);
                            structAnswer Answer4_4 = new structAnswer(viewQuestion.Answers.FirstOrDefault(j => j.id == 4).Text, currentNumQuest, 4);
                            testAnswerList.Children.Add(Answer4_1.blockAnswerGB);
                            testAnswerList.Children.Add(Answer4_2.blockAnswerGB);
                            testAnswerList.Children.Add(Answer4_3.blockAnswerGB);
                            testAnswerList.Children.Add(Answer4_4.blockAnswerGB);
                            break;

                            #endregion

                            #region colAnswer5

                            case 5:
                            structAnswer Answer5_1 = new structAnswer(viewQuestion.Answers.FirstOrDefault(j => j.id == 1).Text, currentNumQuest, 1);
                            structAnswer Answer5_2 = new structAnswer(viewQuestion.Answers.FirstOrDefault(j => j.id == 2).Text, currentNumQuest, 2);
                            structAnswer Answer5_3 = new structAnswer(viewQuestion.Answers.FirstOrDefault(j => j.id == 3).Text, currentNumQuest, 3);
                            structAnswer Answer5_4 = new structAnswer(viewQuestion.Answers.FirstOrDefault(j => j.id == 4).Text, currentNumQuest, 4);
                            structAnswer Answer5_5 = new structAnswer(viewQuestion.Answers.FirstOrDefault(j => j.id == 5).Text, currentNumQuest, 5);
                            testAnswerList.Children.Add(Answer5_1.blockAnswerGB);
                            testAnswerList.Children.Add(Answer5_2.blockAnswerGB);
                            testAnswerList.Children.Add(Answer5_3.blockAnswerGB);
                            testAnswerList.Children.Add(Answer5_4.blockAnswerGB);
                            testAnswerList.Children.Add(Answer5_5.blockAnswerGB);
                            break;

                            #endregion

                            #region colAnswer6

                            case 6:
                            structAnswer Answer6_1 = new structAnswer(viewQuestion.Answers.FirstOrDefault(j => j.id == 1).Text, currentNumQuest, 1);
                            structAnswer Answer6_2 = new structAnswer(viewQuestion.Answers.FirstOrDefault(j => j.id == 2).Text, currentNumQuest, 2);
                            structAnswer Answer6_3 = new structAnswer(viewQuestion.Answers.FirstOrDefault(j => j.id == 3).Text, currentNumQuest, 3);
                            structAnswer Answer6_4 = new structAnswer(viewQuestion.Answers.FirstOrDefault(j => j.id == 4).Text, currentNumQuest, 4);
                            structAnswer Answer6_5 = new structAnswer(viewQuestion.Answers.FirstOrDefault(j => j.id == 5).Text, currentNumQuest, 5);
                            structAnswer Answer6_6 = new structAnswer(viewQuestion.Answers.FirstOrDefault(j => j.id == 6).Text, currentNumQuest, 6);
                            testAnswerList.Children.Add(Answer6_1.blockAnswerGB);
                            testAnswerList.Children.Add(Answer6_2.blockAnswerGB);
                            testAnswerList.Children.Add(Answer6_3.blockAnswerGB);
                            testAnswerList.Children.Add(Answer6_4.blockAnswerGB);
                            testAnswerList.Children.Add(Answer6_5.blockAnswerGB);
                            testAnswerList.Children.Add(Answer6_6.blockAnswerGB);
                            break;

                            #endregion

                            #region colAnswer7

                            case 7:
                            structAnswer Answer7_1 = new structAnswer(viewQuestion.Answers.FirstOrDefault(j => j.id == 1).Text, currentNumQuest, 1);
                            structAnswer Answer7_2 = new structAnswer(viewQuestion.Answers.FirstOrDefault(j => j.id == 2).Text, currentNumQuest, 2);
                            structAnswer Answer7_3 = new structAnswer(viewQuestion.Answers.FirstOrDefault(j => j.id == 3).Text, currentNumQuest, 3);
                            structAnswer Answer7_4 = new structAnswer(viewQuestion.Answers.FirstOrDefault(j => j.id == 4).Text, currentNumQuest, 4);
                            structAnswer Answer7_5 = new structAnswer(viewQuestion.Answers.FirstOrDefault(j => j.id == 5).Text, currentNumQuest, 5);
                            structAnswer Answer7_6 = new structAnswer(viewQuestion.Answers.FirstOrDefault(j => j.id == 6).Text, currentNumQuest, 6);
                            structAnswer Answer7_7 = new structAnswer(viewQuestion.Answers.FirstOrDefault(j => j.id == 7).Text, currentNumQuest, 7);
                            testAnswerList.Children.Add(Answer7_1.blockAnswerGB);
                            testAnswerList.Children.Add(Answer7_2.blockAnswerGB);
                            testAnswerList.Children.Add(Answer7_3.blockAnswerGB);
                            testAnswerList.Children.Add(Answer7_4.blockAnswerGB);
                            testAnswerList.Children.Add(Answer7_5.blockAnswerGB);
                            testAnswerList.Children.Add(Answer7_6.blockAnswerGB);
                            testAnswerList.Children.Add(Answer7_7.blockAnswerGB);
                            break;

                            #endregion

                            #region colAnswer8

                            case 8:
                            structAnswer Answer8_1 = new structAnswer(viewQuestion.Answers.FirstOrDefault(j => j.id == 1).Text, currentNumQuest, 1);
                            structAnswer Answer8_2 = new structAnswer(viewQuestion.Answers.FirstOrDefault(j => j.id == 2).Text, currentNumQuest, 2);
                            structAnswer Answer8_3 = new structAnswer(viewQuestion.Answers.FirstOrDefault(j => j.id == 3).Text, currentNumQuest, 3);
                            structAnswer Answer8_4 = new structAnswer(viewQuestion.Answers.FirstOrDefault(j => j.id == 4).Text, currentNumQuest, 4);
                            structAnswer Answer8_5 = new structAnswer(viewQuestion.Answers.FirstOrDefault(j => j.id == 5).Text, currentNumQuest, 5);
                            structAnswer Answer8_6 = new structAnswer(viewQuestion.Answers.FirstOrDefault(j => j.id == 6).Text, currentNumQuest, 6);
                            structAnswer Answer8_7 = new structAnswer(viewQuestion.Answers.FirstOrDefault(j => j.id == 7).Text, currentNumQuest, 7);
                            structAnswer Answer8_8 = new structAnswer(viewQuestion.Answers.FirstOrDefault(j => j.id == 8).Text, currentNumQuest, 8);
                            testAnswerList.Children.Add(Answer8_1.blockAnswerGB);
                            testAnswerList.Children.Add(Answer8_2.blockAnswerGB);
                            testAnswerList.Children.Add(Answer8_3.blockAnswerGB);
                            testAnswerList.Children.Add(Answer8_4.blockAnswerGB);
                            testAnswerList.Children.Add(Answer8_5.blockAnswerGB);
                            testAnswerList.Children.Add(Answer8_6.blockAnswerGB);
                            testAnswerList.Children.Add(Answer8_7.blockAnswerGB);
                            testAnswerList.Children.Add(Answer8_8.blockAnswerGB);
                            break;

                            #endregion

                            #region colAnswer9

                            case 9:
                            structAnswer Answer9_1 = new structAnswer(viewQuestion.Answers.FirstOrDefault(j => j.id == 1).Text, currentNumQuest, 1);
                            structAnswer Answer9_2 = new structAnswer(viewQuestion.Answers.FirstOrDefault(j => j.id == 2).Text, currentNumQuest, 2);
                            structAnswer Answer9_3 = new structAnswer(viewQuestion.Answers.FirstOrDefault(j => j.id == 3).Text, currentNumQuest, 3);
                            structAnswer Answer9_4 = new structAnswer(viewQuestion.Answers.FirstOrDefault(j => j.id == 4).Text, currentNumQuest, 4);
                            structAnswer Answer9_5 = new structAnswer(viewQuestion.Answers.FirstOrDefault(j => j.id == 5).Text, currentNumQuest, 5);
                            structAnswer Answer9_6 = new structAnswer(viewQuestion.Answers.FirstOrDefault(j => j.id == 6).Text, currentNumQuest, 6);
                            structAnswer Answer9_7 = new structAnswer(viewQuestion.Answers.FirstOrDefault(j => j.id == 7).Text, currentNumQuest, 7);
                            structAnswer Answer9_8 = new structAnswer(viewQuestion.Answers.FirstOrDefault(j => j.id == 8).Text, currentNumQuest, 8);
                            structAnswer Answer9_9 = new structAnswer(viewQuestion.Answers.FirstOrDefault(j => j.id == 9).Text, currentNumQuest, 9);
                            testAnswerList.Children.Add(Answer9_1.blockAnswerGB);
                            testAnswerList.Children.Add(Answer9_2.blockAnswerGB);
                            testAnswerList.Children.Add(Answer9_3.blockAnswerGB);
                            testAnswerList.Children.Add(Answer9_4.blockAnswerGB);
                            testAnswerList.Children.Add(Answer9_5.blockAnswerGB);
                            testAnswerList.Children.Add(Answer9_6.blockAnswerGB);
                            testAnswerList.Children.Add(Answer9_7.blockAnswerGB);
                            testAnswerList.Children.Add(Answer9_8.blockAnswerGB);
                            testAnswerList.Children.Add(Answer9_9.blockAnswerGB);
                            break;

                            #endregion

                            #region colAnswer10

                            case 10:
                            structAnswer Answer10_1 = new structAnswer(viewQuestion.Answers.FirstOrDefault(j => j.id == 1).Text, currentNumQuest, 1);
                            structAnswer Answer10_2 = new structAnswer(viewQuestion.Answers.FirstOrDefault(j => j.id == 2).Text, currentNumQuest, 2);
                            structAnswer Answer10_3 = new structAnswer(viewQuestion.Answers.FirstOrDefault(j => j.id == 3).Text, currentNumQuest, 3);
                            structAnswer Answer10_4 = new structAnswer(viewQuestion.Answers.FirstOrDefault(j => j.id == 4).Text, currentNumQuest, 4);
                            structAnswer Answer10_5 = new structAnswer(viewQuestion.Answers.FirstOrDefault(j => j.id == 5).Text, currentNumQuest, 5);
                            structAnswer Answer10_6 = new structAnswer(viewQuestion.Answers.FirstOrDefault(j => j.id == 6).Text, currentNumQuest, 6);
                            structAnswer Answer10_7 = new structAnswer(viewQuestion.Answers.FirstOrDefault(j => j.id == 7).Text, currentNumQuest, 7);
                            structAnswer Answer10_8 = new structAnswer(viewQuestion.Answers.FirstOrDefault(j => j.id == 8).Text, currentNumQuest, 8);
                            structAnswer Answer10_9 = new structAnswer(viewQuestion.Answers.FirstOrDefault(j => j.id == 9).Text, currentNumQuest, 9);
                            structAnswer Answer10_10 = new structAnswer(viewQuestion.Answers.FirstOrDefault(j => j.id == 10).Text, currentNumQuest, 10);
                            testAnswerList.Children.Add(Answer10_1.blockAnswerGB);
                            testAnswerList.Children.Add(Answer10_2.blockAnswerGB);
                            testAnswerList.Children.Add(Answer10_3.blockAnswerGB);
                            testAnswerList.Children.Add(Answer10_4.blockAnswerGB);
                            testAnswerList.Children.Add(Answer10_5.blockAnswerGB);
                            testAnswerList.Children.Add(Answer10_6.blockAnswerGB);
                            testAnswerList.Children.Add(Answer10_7.blockAnswerGB);
                            testAnswerList.Children.Add(Answer10_8.blockAnswerGB);
                            testAnswerList.Children.Add(Answer10_9.blockAnswerGB);
                            testAnswerList.Children.Add(Answer10_10.blockAnswerGB);
                            break;

                            #endregion

                            #endregion
                        }
                        testNumQuestion.Text = Convert.ToString(currentNumQuest) + '/' + Convert.ToString(Program.CurrentProject.CountQuestions);
                        return true;
                    }
                    return false;
                }
                return false;
        }

        #endregion

        public WindowStudentTesting()
        {
            InitializeComponent();

            #region null/!null Account/Project
            if (Program.CurrentAccount != null)
            {
                enabledStudentTestingWindowMenu(true);
                testAccountNameGB.Header = Program.CurrentAccount.Name;
                if (Program.CurrentProject != null)
                {
                    enabledStudentTestingWindowButton(true);
                    currentNumQuest = 1;
                    viewTestInStudentTestingWindow(currentNumQuest);
                }
                else
                {
                    enabledStudentTestingWindowButton(false);
                    clearStudentTestingWindow();
                }
            }
            else
            {
                enabledStudentTestingWindowMenu(false);
                testAccountNameGB.Header = "";
                enabledStudentTestingWindowButton(false);
                clearStudentTestingWindow();
            }
            #endregion
        }

        #region Menu

        private void TestExit_Click(object sender, RoutedEventArgs e)
        {
            if (Program.CurrentProject != null)
            {
                Program.CurrentProject.clearStudentSelectVarAnswer();
            }

            Close();
        }

        private void CreateAccountMenu_Click(object sender, RoutedEventArgs e)
        {
            if (Program.CurrentProject != null)
            {
                Program.CurrentProject.clearStudentSelectVarAnswer();
            }

            WindowStudentCreateAccount createAccount = new WindowStudentCreateAccount();
            createAccount.ShowDialog();

            #region null/!null Account/Project
            if (Program.CurrentAccount != null)
            {
                enabledStudentTestingWindowMenu(true);
                testAccountNameGB.Header = Program.CurrentAccount.Name;
                if (Program.CurrentProject != null)
                {
                    enabledStudentTestingWindowButton(true);
                    currentNumQuest = 1;
                    viewTestInStudentTestingWindow(currentNumQuest);
                }
                else
                {
                    enabledStudentTestingWindowButton(false);
                    clearStudentTestingWindow();
                }
            }
            else
            {
                enabledStudentTestingWindowMenu(false);
                testAccountNameGB.Header = "";
                enabledStudentTestingWindowButton(false);
                clearStudentTestingWindow();
            }
            #endregion

        }

        private void OpenAccountMenu_Click(object sender, RoutedEventArgs e)
        {
            if (Program.ReadAccount())
            {
                if(Program.CurrentProject!=null)
                {
                    Program.CurrentProject.clearStudentSelectVarAnswer();
                }

                WindowStudentAuthorizationAccount auth = new WindowStudentAuthorizationAccount();
                auth.ShowDialog();

                #region null/!null Account/Project
                if (Program.CurrentAccount!=null)
                {
                    enabledStudentTestingWindowMenu(true);
                    testAccountNameGB.Header = Program.CurrentAccount.Name;
                    if (Program.CurrentProject != null)
                    {
                        enabledStudentTestingWindowButton(true);
                        currentNumQuest = 1;
                        viewTestInStudentTestingWindow(currentNumQuest);
                    }
                    else
                    {
                        enabledStudentTestingWindowButton(false);
                        clearStudentTestingWindow();
                    }
                }
                else
                {
                    enabledStudentTestingWindowMenu(false);
                    testAccountNameGB.Header = "";
                    enabledStudentTestingWindowButton(false);
                    clearStudentTestingWindow();
                }
                #endregion

            }
        }

        private void ViewAccountMenu_Click(object sender, RoutedEventArgs e)
        {
            WindowStudentSettingAccount settingAccount = new WindowStudentSettingAccount();
            settingAccount.ShowDialog();
            testAccountNameGB.Header = Program.CurrentAccount.Name;
        }

        #endregion

        #region eventButtons

        private void OpenTestMenu_Click(object sender, RoutedEventArgs e)
        {
            if(!Program.OpenProject())
            {
                clearStudentTestingWindow();
                enabledStudentTestingWindowButton(false);
                Program.CurrentProject = null;
                return;
            }
            currentNumQuest = 1;
            viewTestInStudentTestingWindow(currentNumQuest);
            enabledStudentTestingWindowButton(true);
        }

        private void testNextButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentNumQuest < Program.CurrentProject.CountQuestions)
            {
                ++currentNumQuest;
                clearStudentTestingWindow();
                viewTestInStudentTestingWindow(currentNumQuest);
            }
        }

        private void testBackButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentNumQuest == 1)
            {
                return;
            }
            else
            {
                --currentNumQuest;
                clearStudentTestingWindow();
                viewTestInStudentTestingWindow(currentNumQuest);
            }
        }

        private void testPassTheTestButton_Click(object sender, RoutedEventArgs e)
        {
            if (Program.CurrentAccount.SolvedTests.FirstOrDefault(p => p.GuidTest == Program.CurrentProject.GuidProj) != null)
            {
                WindowMsgError testInAccountException = new WindowMsgError("Ошибка", "Тест уже пройден");
                testInAccountException.ShowDialog();
                return;
            }
            WindowSolvedTest solved = new WindowSolvedTest();
            solved.ShowDialog();
         //   clearStudentTestingWindow();
            currentNumQuest = 1;
            viewTestInStudentTestingWindow(currentNumQuest);
        }

        #endregion

    }
}
