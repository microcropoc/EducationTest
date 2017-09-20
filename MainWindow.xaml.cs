using System;
using System.Linq;
using System.Windows;

namespace EducationTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        #region userMethod

        #region DisplayInMajorFormOutCurrentProject

        //открывет/закрывает редактируемость полей и чекбоксов на главной форме
        private void enabledMajorWindowElement(bool check)
        {
            if(check)
            {
                #region true
                decQuestNumber.IsEnabled = true;
                incQuestNumber.IsEnabled = true;
                questField.IsEnabled = true;
                answer1Bool.IsEnabled = true;
                answer1Text.IsEnabled = true;
                answer2Bool.IsEnabled = true;
                answer2Text.IsEnabled = true;
                answer3Bool.IsEnabled = true;
                answer3Text.IsEnabled = true;
                answer4Bool.IsEnabled = true;
                answer4Text.IsEnabled = true;
                answer5Bool.IsEnabled = true;
                answer5Text.IsEnabled = true;
                answer6Bool.IsEnabled = true;
                answer6Text.IsEnabled = true;
                answer7Bool.IsEnabled = true;
                answer7Text.IsEnabled = true;
                answer8Bool.IsEnabled = true;
                answer8Text.IsEnabled = true;
                answer9Bool.IsEnabled = true;
                answer9Text.IsEnabled = true;
                answer10Bool.IsEnabled = true;
                answer10Text.IsEnabled = true;
                ProjCurrentProjectMenu.IsEnabled = true;
                SaveAsProjMenu.IsEnabled = true;
                SaveProjMenu.IsEnabled = true;
                #endregion
            }
            else
            {
                #region false
                decQuestNumber.IsEnabled = false;
                incQuestNumber.IsEnabled = false;
                questField.IsEnabled = false;
                answer1Bool.IsEnabled = false;
                answer1Text.IsEnabled = false;
                answer2Bool.IsEnabled = false;
                answer2Text.IsEnabled = false;
                answer3Bool.IsEnabled = false;
                answer3Text.IsEnabled = false;
                answer4Bool.IsEnabled = false;
                answer4Text.IsEnabled = false;
                answer5Bool.IsEnabled = false;
                answer5Text.IsEnabled = false;
                answer6Bool.IsEnabled = false;
                answer6Text.IsEnabled = false;
                answer7Bool.IsEnabled = false;
                answer7Text.IsEnabled = false;
                answer8Bool.IsEnabled = false;
                answer8Text.IsEnabled = false;
                answer9Bool.IsEnabled = false;
                answer9Text.IsEnabled = false;
                answer10Bool.IsEnabled = false;
                answer10Text.IsEnabled = false;
                ProjCurrentProjectMenu.IsEnabled = false;
                SaveAsProjMenu.IsEnabled = false;
                SaveProjMenu.IsEnabled = false;
                #endregion
            }
        } 

        //очистка главной формы
        private void clearMajorWindow()
        {
            questField.Text = "";
            answer1Bool.IsChecked = false;
            answer1Text.Text = "";
            answer2Bool.IsChecked = false;
            answer2Text.Text = "";
            answer3Bool.IsChecked = false;
            answer3Text.Text = "";
            answer4Bool.IsChecked = false;
            answer4Text.Text = "";
            answer5Bool.IsChecked = false;
            answer5Text.Text = "";
            answer6Bool.IsChecked = false;
            answer6Text.Text = "";
            answer7Bool.IsChecked = false;
            answer7Text.Text = "";
            answer8Bool.IsChecked = false;
            answer8Text.Text = "";
            answer9Bool.IsChecked = false;
            answer9Text.Text = "";
            answer10Bool.IsChecked = false;
            answer10Text.Text = "";
        }

        //Загружает вопрос на главную форму для редактирования
        private bool viewProjectInMajorWindow(int idQuestion)
        {
            if (Program.CurrentProject != null)
            {
                questNumber.Text = Convert.ToString(currentNumQuest) + '/' + Convert.ToString(Program.CurrentProject.CountQuestions);
                if (idQuestion <= Program.CurrentProject.CountQuestions)
                {
                    Question viewQuestion = Program.CurrentProject.Questions.FirstOrDefault(j => j.id == idQuestion);
                    NameProjGB.Header = Program.CurrentProject.NameProject;
                    questField.Text = viewQuestion.Text;
//---------------------------------------------------------------------------------------
                    switch (viewQuestion.CountAnswers)
                    {
                        #region Case
                        case 1:
                            #region answer1MajorForm
                            answer1Bool.IsChecked = viewQuestion.Answers.FirstOrDefault(j => j.id == 1).Trueness;
                            answer1Text.Text = viewQuestion.Answers.FirstOrDefault(j => j.id == 1).Text;
                            #endregion

                            break;

                        case 2:
                            #region answer1MajorForm
                            answer1Bool.IsChecked = viewQuestion.Answers.FirstOrDefault(j => j.id == 1).Trueness;
                            answer1Text.Text = viewQuestion.Answers.FirstOrDefault(j => j.id == 1).Text;
                            #endregion

                            #region answer2MajorForm
                            answer2Bool.IsChecked = viewQuestion.Answers.FirstOrDefault(j => j.id == 2).Trueness;
                            answer2Text.Text = viewQuestion.Answers.FirstOrDefault(j => j.id == 2).Text;
                            #endregion
                            break;

                        case 3:
                            #region answer1MajorForm
                            answer1Bool.IsChecked = viewQuestion.Answers.FirstOrDefault(j => j.id == 1).Trueness;
                            answer1Text.Text = viewQuestion.Answers.FirstOrDefault(j => j.id == 1).Text;
                            #endregion

                            #region answer2MajorForm
                            answer2Bool.IsChecked = viewQuestion.Answers.FirstOrDefault(j => j.id == 2).Trueness;
                            answer2Text.Text = viewQuestion.Answers.FirstOrDefault(j => j.id == 2).Text;
                            #endregion

                            #region answer3MajorForm
                            answer3Bool.IsChecked = viewQuestion.Answers.FirstOrDefault(j => j.id == 3).Trueness;
                            answer3Text.Text = viewQuestion.Answers.FirstOrDefault(j => j.id == 3).Text;
                            #endregion
                            break;

                        case 4:
                            #region answer1MajorForm
                            answer1Bool.IsChecked = viewQuestion.Answers.FirstOrDefault(j => j.id == 1).Trueness;
                            answer1Text.Text = viewQuestion.Answers.FirstOrDefault(j => j.id == 1).Text;
                            #endregion

                            #region answer2MajorForm
                            answer2Bool.IsChecked = viewQuestion.Answers.FirstOrDefault(j => j.id == 2).Trueness;
                            answer2Text.Text = viewQuestion.Answers.FirstOrDefault(j => j.id == 2).Text;
                            #endregion

                            #region answer3MajorForm
                            answer3Bool.IsChecked = viewQuestion.Answers.FirstOrDefault(j => j.id == 3).Trueness;
                            answer3Text.Text = viewQuestion.Answers.FirstOrDefault(j => j.id == 3).Text;
                            #endregion

                            #region answer4MajorForm
                            answer4Bool.IsChecked = viewQuestion.Answers.FirstOrDefault(j => j.id == 4).Trueness;
                            answer4Text.Text = viewQuestion.Answers.FirstOrDefault(j => j.id == 4).Text;
                            #endregion
                            break;
                        case 5:
                            #region answer1MajorForm
                            answer1Bool.IsChecked = viewQuestion.Answers.FirstOrDefault(j => j.id == 1).Trueness;
                            answer1Text.Text = viewQuestion.Answers.FirstOrDefault(j => j.id == 1).Text;
                            #endregion

                            #region answer2MajorForm
                            answer2Bool.IsChecked = viewQuestion.Answers.FirstOrDefault(j => j.id == 2).Trueness;
                            answer2Text.Text = viewQuestion.Answers.FirstOrDefault(j => j.id == 2).Text;
                            #endregion

                            #region answer3MajorForm
                            answer3Bool.IsChecked = viewQuestion.Answers.FirstOrDefault(j => j.id == 3).Trueness;
                            answer3Text.Text = viewQuestion.Answers.FirstOrDefault(j => j.id == 3).Text;
                            #endregion

                            #region answer4MajorForm
                            answer4Bool.IsChecked = viewQuestion.Answers.FirstOrDefault(j => j.id == 4).Trueness;
                            answer4Text.Text = viewQuestion.Answers.FirstOrDefault(j => j.id == 4).Text;
                            #endregion

                            #region answer5MajorForm
                            answer5Bool.IsChecked = viewQuestion.Answers.FirstOrDefault(j => j.id == 5).Trueness;
                            answer5Text.Text = viewQuestion.Answers.FirstOrDefault(j => j.id == 5).Text;
                            #endregion
                            break;

                        case 6:
                            #region answer1MajorForm
                            answer1Bool.IsChecked = viewQuestion.Answers.FirstOrDefault(j => j.id == 1).Trueness;
                            answer1Text.Text = viewQuestion.Answers.FirstOrDefault(j => j.id == 1).Text;
                            #endregion

                            #region answer2MajorForm
                            answer2Bool.IsChecked = viewQuestion.Answers.FirstOrDefault(j => j.id == 2).Trueness;
                            answer2Text.Text = viewQuestion.Answers.FirstOrDefault(j => j.id == 2).Text;
                            #endregion

                            #region answer3MajorForm
                            answer3Bool.IsChecked = viewQuestion.Answers.FirstOrDefault(j => j.id == 3).Trueness;
                            answer3Text.Text = viewQuestion.Answers.FirstOrDefault(j => j.id == 3).Text;
                            #endregion

                            #region answer4MajorForm
                            answer4Bool.IsChecked = viewQuestion.Answers.FirstOrDefault(j => j.id == 4).Trueness;
                            answer4Text.Text = viewQuestion.Answers.FirstOrDefault(j => j.id == 4).Text;
                            #endregion

                            #region answer5MajorForm
                            answer5Bool.IsChecked = viewQuestion.Answers.FirstOrDefault(j => j.id == 5).Trueness;
                            answer5Text.Text = viewQuestion.Answers.FirstOrDefault(j => j.id == 5).Text;
                            #endregion

                            #region answer6MajorForm
                            answer6Bool.IsChecked = viewQuestion.Answers.FirstOrDefault(j => j.id == 6).Trueness;
                            answer6Text.Text = viewQuestion.Answers.FirstOrDefault(j => j.id == 6).Text;
                            #endregion
                            break;

                        case 7:
                            #region answer1MajorForm
                            answer1Bool.IsChecked = viewQuestion.Answers.FirstOrDefault(j => j.id == 1).Trueness;
                            answer1Text.Text = viewQuestion.Answers.FirstOrDefault(j => j.id == 1).Text;
                            #endregion

                            #region answer2MajorForm
                            answer2Bool.IsChecked = viewQuestion.Answers.FirstOrDefault(j => j.id == 2).Trueness;
                            answer2Text.Text = viewQuestion.Answers.FirstOrDefault(j => j.id == 2).Text;
                            #endregion

                            #region answer3MajorForm
                            answer3Bool.IsChecked = viewQuestion.Answers.FirstOrDefault(j => j.id == 3).Trueness;
                            answer3Text.Text = viewQuestion.Answers.FirstOrDefault(j => j.id == 3).Text;
                            #endregion

                            #region answer4MajorForm
                            answer4Bool.IsChecked = viewQuestion.Answers.FirstOrDefault(j => j.id == 4).Trueness;
                            answer4Text.Text = viewQuestion.Answers.FirstOrDefault(j => j.id == 4).Text;
                            #endregion

                            #region answer5MajorForm
                            answer5Bool.IsChecked = viewQuestion.Answers.FirstOrDefault(j => j.id == 5).Trueness;
                            answer5Text.Text = viewQuestion.Answers.FirstOrDefault(j => j.id == 5).Text;
                            #endregion

                            #region answer6MajorForm
                            answer6Bool.IsChecked = viewQuestion.Answers.FirstOrDefault(j => j.id == 6).Trueness;
                            answer6Text.Text = viewQuestion.Answers.FirstOrDefault(j => j.id == 6).Text;
                            #endregion

                            #region answer7MajorForm
                            answer7Bool.IsChecked = viewQuestion.Answers.FirstOrDefault(j => j.id == 7).Trueness;
                            answer7Text.Text = viewQuestion.Answers.FirstOrDefault(j => j.id == 7).Text;
                            #endregion
                            break;

                        case 8:
                            #region answer1MajorForm
                            answer1Bool.IsChecked = viewQuestion.Answers.FirstOrDefault(j => j.id == 1).Trueness;
                            answer1Text.Text = viewQuestion.Answers.FirstOrDefault(j => j.id == 1).Text;
                            #endregion

                            #region answer2MajorForm
                            answer2Bool.IsChecked = viewQuestion.Answers.FirstOrDefault(j => j.id == 2).Trueness;
                            answer2Text.Text = viewQuestion.Answers.FirstOrDefault(j => j.id == 2).Text;
                            #endregion

                            #region answer3MajorForm
                            answer3Bool.IsChecked = viewQuestion.Answers.FirstOrDefault(j => j.id == 3).Trueness;
                            answer3Text.Text = viewQuestion.Answers.FirstOrDefault(j => j.id == 3).Text;
                            #endregion

                            #region answer4MajorForm
                            answer4Bool.IsChecked = viewQuestion.Answers.FirstOrDefault(j => j.id == 4).Trueness;
                            answer4Text.Text = viewQuestion.Answers.FirstOrDefault(j => j.id == 4).Text;
                            #endregion

                            #region answer5MajorForm
                            answer5Bool.IsChecked = viewQuestion.Answers.FirstOrDefault(j => j.id == 5).Trueness;
                            answer5Text.Text = viewQuestion.Answers.FirstOrDefault(j => j.id == 5).Text;
                            #endregion

                            #region answer6MajorForm
                            answer6Bool.IsChecked = viewQuestion.Answers.FirstOrDefault(j => j.id == 6).Trueness;
                            answer6Text.Text = viewQuestion.Answers.FirstOrDefault(j => j.id == 6).Text;
                            #endregion

                            #region answer7MajorForm
                            answer7Bool.IsChecked = viewQuestion.Answers.FirstOrDefault(j => j.id == 7).Trueness;
                            answer7Text.Text = viewQuestion.Answers.FirstOrDefault(j => j.id == 7).Text;
                            #endregion

                            #region answer8MajorForm
                            answer8Bool.IsChecked = viewQuestion.Answers.FirstOrDefault(j => j.id == 8).Trueness;
                            answer8Text.Text = viewQuestion.Answers.FirstOrDefault(j => j.id == 8).Text;
                            #endregion
                            break;

                        case 9:
                            #region answer1MajorForm
                            answer1Bool.IsChecked = viewQuestion.Answers.FirstOrDefault(j => j.id == 1).Trueness;
                            answer1Text.Text = viewQuestion.Answers.FirstOrDefault(j => j.id == 1).Text;
                            #endregion

                            #region answer2MajorForm
                            answer2Bool.IsChecked = viewQuestion.Answers.FirstOrDefault(j => j.id == 2).Trueness;
                            answer2Text.Text = viewQuestion.Answers.FirstOrDefault(j => j.id == 2).Text;
                            #endregion

                            #region answer3MajorForm
                            answer3Bool.IsChecked = viewQuestion.Answers.FirstOrDefault(j => j.id == 3).Trueness;
                            answer3Text.Text = viewQuestion.Answers.FirstOrDefault(j => j.id == 3).Text;
                            #endregion

                            #region answer4MajorForm
                            answer4Bool.IsChecked = viewQuestion.Answers.FirstOrDefault(j => j.id == 4).Trueness;
                            answer4Text.Text = viewQuestion.Answers.FirstOrDefault(j => j.id == 4).Text;
                            #endregion

                            #region answer5MajorForm
                            answer5Bool.IsChecked = viewQuestion.Answers.FirstOrDefault(j => j.id == 5).Trueness;
                            answer5Text.Text = viewQuestion.Answers.FirstOrDefault(j => j.id == 5).Text;
                            #endregion

                            #region answer6MajorForm
                            answer6Bool.IsChecked = viewQuestion.Answers.FirstOrDefault(j => j.id == 6).Trueness;
                            answer6Text.Text = viewQuestion.Answers.FirstOrDefault(j => j.id == 6).Text;
                            #endregion

                            #region answer7MajorForm
                            answer7Bool.IsChecked = viewQuestion.Answers.FirstOrDefault(j => j.id == 7).Trueness;
                            answer7Text.Text = viewQuestion.Answers.FirstOrDefault(j => j.id == 7).Text;
                            #endregion

                            #region answer8MajorForm
                            answer8Bool.IsChecked = viewQuestion.Answers.FirstOrDefault(j => j.id == 8).Trueness;
                            answer8Text.Text = viewQuestion.Answers.FirstOrDefault(j => j.id == 8).Text;
                            #endregion

                            #region answer9MajorForm
                            answer9Bool.IsChecked = viewQuestion.Answers.FirstOrDefault(j => j.id == 9).Trueness;
                            answer9Text.Text = viewQuestion.Answers.FirstOrDefault(j => j.id == 9).Text;
                            #endregion
                            break;

                        case 10:
                            #region answer1MajorForm
                            answer1Bool.IsChecked = viewQuestion.Answers.FirstOrDefault(j => j.id == 1).Trueness;
                            answer1Text.Text = viewQuestion.Answers.FirstOrDefault(j => j.id == 1).Text;
                            #endregion

                            #region answer2MajorForm
                            answer2Bool.IsChecked = viewQuestion.Answers.FirstOrDefault(j => j.id == 2).Trueness;
                            answer2Text.Text = viewQuestion.Answers.FirstOrDefault(j => j.id == 2).Text;
                            #endregion

                            #region answer3MajorForm
                            answer3Bool.IsChecked = viewQuestion.Answers.FirstOrDefault(j => j.id == 3).Trueness;
                            answer3Text.Text = viewQuestion.Answers.FirstOrDefault(j => j.id == 3).Text;
                            #endregion

                            #region answer4MajorForm
                            answer4Bool.IsChecked = viewQuestion.Answers.FirstOrDefault(j => j.id == 4).Trueness;
                            answer4Text.Text = viewQuestion.Answers.FirstOrDefault(j => j.id == 4).Text;
                            #endregion

                            #region answer5MajorForm
                            answer5Bool.IsChecked = viewQuestion.Answers.FirstOrDefault(j => j.id == 5).Trueness;
                            answer5Text.Text = viewQuestion.Answers.FirstOrDefault(j => j.id == 5).Text;
                            #endregion

                            #region answer6MajorForm
                            answer6Bool.IsChecked = viewQuestion.Answers.FirstOrDefault(j => j.id == 6).Trueness;
                            answer6Text.Text = viewQuestion.Answers.FirstOrDefault(j => j.id == 6).Text;
                            #endregion

                            #region answer7MajorForm
                            answer7Bool.IsChecked = viewQuestion.Answers.FirstOrDefault(j => j.id == 7).Trueness;
                            answer7Text.Text = viewQuestion.Answers.FirstOrDefault(j => j.id == 7).Text;
                            #endregion

                            #region answer8MajorForm
                            answer8Bool.IsChecked = viewQuestion.Answers.FirstOrDefault(j => j.id == 8).Trueness;
                            answer8Text.Text = viewQuestion.Answers.FirstOrDefault(j => j.id == 8).Text;
                            #endregion

                            #region answer9MajorForm
                            answer9Bool.IsChecked = viewQuestion.Answers.FirstOrDefault(j => j.id == 9).Trueness;
                            answer9Text.Text = viewQuestion.Answers.FirstOrDefault(j => j.id == 9).Text;
                            #endregion

                            #region answer10MajorForm
                            answer10Bool.IsChecked = viewQuestion.Answers.FirstOrDefault(j => j.id == 10).Trueness;
                            answer10Text.Text = viewQuestion.Answers.FirstOrDefault(j => j.id == 10).Text;
                            #endregion
                            break;
                        #endregion
                    }
//---------------------------------------------------------------------------------------
                    
                    return true;
                }
                return false;
            }
            return false;
        }

        #endregion

        #region Insert/SaveInCurrentProject

        //Сохранение вопроса в объект проекта
        private bool insertQuestionInCurrentProject()
        {
            if (questField.Text != string.Empty)
            {
                Question newQuest = new Question() { id = currentNumQuest, Text = questField.Text };
                #region InsertAnswersToNewQuestion

                #region newAnswer1
                if (answer1Text.Text != string.Empty)
                {
                    Answer newAnswer = new Answer() { id = 1, Text = answer1Text.Text, Trueness = answer1Bool.IsChecked != null ? (bool)(answer1Bool.IsChecked) : false };
                    newQuest.Answers.Add(newAnswer);
                }
                #endregion

                #region newAnswer2
                if (answer2Text.Text != string.Empty)
                {
                    Answer newAnswer = new Answer() { id = 2, Text = answer2Text.Text, Trueness = answer2Bool.IsChecked != null ? (bool)(answer2Bool.IsChecked) : false };
                    newQuest.Answers.Add(newAnswer);
                }
                #endregion

                #region newAnswer3
                if (answer3Text.Text != string.Empty)
                {
                    Answer newAnswer = new Answer() { id = 3, Text = answer3Text.Text, Trueness = answer3Bool.IsChecked != null ? (bool)(answer3Bool.IsChecked) : false };
                    newQuest.Answers.Add(newAnswer);
                }
                #endregion

                #region newAnswer4
                if (answer4Text.Text != string.Empty)
                {
                    Answer newAnswer = new Answer() { id = 4, Text = answer4Text.Text, Trueness = answer4Bool.IsChecked != null ? (bool)(answer4Bool.IsChecked) : false };
                    newQuest.Answers.Add(newAnswer);
                }
                #endregion

                #region newAnswer5
                if (answer5Text.Text != string.Empty)
                {
                    Answer newAnswer = new Answer() { id = 5, Text = answer5Text.Text, Trueness = answer5Bool.IsChecked != null ? (bool)(answer5Bool.IsChecked) : false };
                    newQuest.Answers.Add(newAnswer);
                }
                #endregion

                #region newAnswer6
                if (answer6Text.Text != string.Empty)
                {
                    Answer newAnswer = new Answer() { id = 6, Text = answer6Text.Text, Trueness = answer6Bool.IsChecked != null ? (bool)(answer6Bool.IsChecked) : false };
                    newQuest.Answers.Add(newAnswer);
                }
                #endregion

                #region newAnswer7
                if (answer7Text.Text != string.Empty)
                {
                    Answer newAnswer = new Answer() { id = 7, Text = answer7Text.Text, Trueness = answer7Bool.IsChecked != null ? (bool)(answer7Bool.IsChecked) : false };
                    newQuest.Answers.Add(newAnswer);
                }
                #endregion

                #region newAnswer8
                if (answer8Text.Text != string.Empty)
                {
                    Answer newAnswer = new Answer() { id = 8, Text = answer8Text.Text, Trueness = answer8Bool.IsChecked != null ? (bool)(answer8Bool.IsChecked) : false };
                    newQuest.Answers.Add(newAnswer);
                }
                #endregion

                #region newAnswer9
                if (answer9Text.Text != string.Empty)
                {
                    Answer newAnswer = new Answer() { id = 9, Text = answer9Text.Text, Trueness = answer9Bool.IsChecked != null ? (bool)(answer9Bool.IsChecked) : false };
                    newQuest.Answers.Add(newAnswer);
                }
                #endregion

                #region newAnswer10
                if (answer10Text.Text != string.Empty)
                {
                    Answer newAnswer = new Answer() { id = 10, Text = answer10Text.Text, Trueness = answer10Bool.IsChecked != null ? (bool)(answer10Bool.IsChecked) : false };
                    newQuest.Answers.Add(newAnswer);
                }
                #endregion

                #endregion
                if (newQuest.Answers.Count > 1)
                {
                    //хотя бы один ответ правельный
                    #region isOneTrue
                    bool isOneTruness = false;
                    foreach (Answer c in newQuest.Answers)
                    {
                        if (c.Trueness == true)
                        {
                            isOneTruness = true;
                            break;
                        }
                    }
                    #endregion
                    if (isOneTruness)
                    {
                        newQuest.AnswersIdSort();
                        Program.CurrentProject.Questions.Add(newQuest);
                        return true;
                    }
                    return false;
                }
                return false;
            }
            return false;
        }

        //Сохранение изменённого вопроса в объект проекта
        private bool saveEditQuestionInCurrentProject(int idQuestion)
        {
            if(questField.Text!=string.Empty){
            Question refCurrentQuection = Program.CurrentProject.Questions.FirstOrDefault(i=>i.id==idQuestion);

            Question editedQuestion = new Question();
            editedQuestion.Text = questField.Text;
            editedQuestion.Answers.Clear();

            #region InsertAnswersToRefCurrentQuestion

            #region newAnswer1
            if (answer1Text.Text != string.Empty)
            {
                Answer newAnswer = new Answer() { id = 1, Text = answer1Text.Text, Trueness = answer1Bool.IsChecked != null ? (bool)(answer1Bool.IsChecked) : false };
                editedQuestion.Answers.Add(newAnswer);
            }
            #endregion

            #region newAnswer2
            if (answer2Text.Text != string.Empty)
            {
                Answer newAnswer = new Answer() { id = 2, Text = answer2Text.Text, Trueness = answer2Bool.IsChecked != null ? (bool)(answer2Bool.IsChecked) : false };
                editedQuestion.Answers.Add(newAnswer);
            }
            #endregion

            #region newAnswer3
            if (answer3Text.Text != string.Empty)
            {
                Answer newAnswer = new Answer() { id = 3, Text = answer3Text.Text, Trueness = answer3Bool.IsChecked != null ? (bool)(answer3Bool.IsChecked) : false };
                editedQuestion.Answers.Add(newAnswer);
            }
            #endregion

            #region newAnswer4
            if (answer4Text.Text != string.Empty)
            {
                Answer newAnswer = new Answer() { id = 4, Text = answer4Text.Text, Trueness = answer4Bool.IsChecked != null ? (bool)(answer4Bool.IsChecked) : false };
                editedQuestion.Answers.Add(newAnswer);
            }
            #endregion

            #region newAnswer5
            if (answer5Text.Text != string.Empty)
            {
                Answer newAnswer = new Answer() { id = 5, Text = answer5Text.Text, Trueness = answer5Bool.IsChecked != null ? (bool)(answer5Bool.IsChecked) : false };
                editedQuestion.Answers.Add(newAnswer);
            }
            #endregion

            #region newAnswer6
            if (answer6Text.Text != string.Empty)
            {
                Answer newAnswer = new Answer() { id = 6, Text = answer6Text.Text, Trueness = answer6Bool.IsChecked != null ? (bool)(answer6Bool.IsChecked) : false };
                editedQuestion.Answers.Add(newAnswer);
            }
            #endregion

            #region newAnswer7
            if (answer7Text.Text != string.Empty)
            {
                Answer newAnswer = new Answer() { id = 7, Text = answer7Text.Text, Trueness = answer7Bool.IsChecked != null ? (bool)(answer7Bool.IsChecked) : false };
                editedQuestion.Answers.Add(newAnswer);
            }
            #endregion

            #region newAnswer8
            if (answer8Text.Text != string.Empty)
            {
                Answer newAnswer = new Answer() { id = 8, Text = answer8Text.Text, Trueness = answer8Bool.IsChecked != null ? (bool)(answer8Bool.IsChecked) : false };
                editedQuestion.Answers.Add(newAnswer);
            }
            #endregion

            #region newAnswer9
            if (answer9Text.Text != string.Empty)
            {
                Answer newAnswer = new Answer() { id = 9, Text = answer9Text.Text, Trueness = answer9Bool.IsChecked != null ? (bool)(answer9Bool.IsChecked) : false };
                editedQuestion.Answers.Add(newAnswer);
            }
            #endregion

            #region newAnswer10
            if (answer10Text.Text != string.Empty)
            {
                Answer newAnswer = new Answer() { id = 10, Text = answer10Text.Text, Trueness = answer10Bool.IsChecked != null ? (bool)(answer10Bool.IsChecked) : false };
                editedQuestion.Answers.Add(newAnswer);
            }
            #endregion

            #endregion

            if (editedQuestion.Answers.Count > 1)
            {
                //хотя бы один ответ правельный
                #region isOneTrue
                bool isOneTruness=false;
                foreach (Answer c in editedQuestion.Answers)
                {
                    if(c.Trueness==true)
                    {
                        isOneTruness = true;
                        break;
                    }
                }
                #endregion
                if (isOneTruness)
                {
                    editedQuestion.AnswersIdSort();
                    refCurrentQuection.Answers.Clear();
                    refCurrentQuection.Text = editedQuestion.Text;
                    foreach (Answer answer in editedQuestion.Answers)
                    {
                        refCurrentQuection.Answers.Add(answer);
                    }

                    return true;

                }
            }
            return false;
            }
            return false;
        }

        #endregion

        #endregion

        int currentNumQuest = 1;

        public MainWindow()
        {
            
            InitializeComponent();
            enabledMajorWindowElement(false);
          
        }

        private void incQuestNumber_Click(object sender, RoutedEventArgs e)
        {
            //перемещение по вопросам теста
            //инкремент
            if (currentNumQuest > Program.CurrentProject.CountQuestions)
            {
                if(insertQuestionInCurrentProject())
                {
                    questNumber.Text = Convert.ToString(++currentNumQuest) + '/' + Program.CurrentProject.CountQuestions;
                    clearMajorWindow();
                }
                else
                { 
                    return;
                }
                
            }
            else
                if (currentNumQuest <= Program.CurrentProject.CountQuestions)
                {
                    saveEditQuestionInCurrentProject(currentNumQuest);
                    if(currentNumQuest==Program.CurrentProject.CountQuestions)
                    {
                        incQuestNumber.Content = "Добавить";
                    }
                    else
                    {
                        incQuestNumber.Content = "Далее";
                    }
                    clearMajorWindow();
                    viewProjectInMajorWindow(++currentNumQuest);

                }
                   
        }

        private void decQuestNumber_Click(object sender, RoutedEventArgs e)
        {
            //перемещение по вопросам теста
            //декримент
            saveEditQuestionInCurrentProject(currentNumQuest);
            if (currentNumQuest == 1)
            {
                clearMajorWindow();
                viewProjectInMajorWindow(currentNumQuest);
            }
            else
            {
                incQuestNumber.Content = "Далее";
                clearMajorWindow();
                viewProjectInMajorWindow(--currentNumQuest);
            }
            
        }


        #region Menu
        //вызов из меню функции создания нового проекта
        private void CreateNewProjMenu_Click(object sender, RoutedEventArgs e)
        {   
            WindowNewProject Create = new WindowNewProject(this);
            Create.ShowDialog();
            
            #region initCurrentProjectOnMajorWindowForEdit
            //если проект создан, то загружаем его в главную форму для заполнения
            if (Program.CurrentProject!=null)
            {
                currentNumQuest = 1;
                clearMajorWindow();
                enabledMajorWindowElement(viewProjectInMajorWindow(1));
                NameProjGB.Header = Program.CurrentProject.NameProject;
            }
            #endregion
        }

        private void OpenProjMenu_Click(object sender, RoutedEventArgs e)
        {
            clearMajorWindow();
            Program.OpenProject();
            currentNumQuest = 1;
            enabledMajorWindowElement(viewProjectInMajorWindow(1));
        }

        private void SaveProjMenu_Click(object sender, RoutedEventArgs e)
        {
            saveEditQuestionInCurrentProject(currentNumQuest);
            Program.SaveOrSaveAsProject(Program.CurrentProject.PathProject);
        }

        private void ProjSettingMenu_Click(object sender, RoutedEventArgs e)
        {
            WindowProjSetting Setting = new WindowProjSetting();
            Setting.ShowDialog();
            NameProjGB.Header = Program.CurrentProject.NameProject;
        }

        private void SaveAsProjMenu_Click(object sender, RoutedEventArgs e)
        {
            saveEditQuestionInCurrentProject(currentNumQuest);
            Program.SaveOrSaveAsProject();
        }


        private void ProjPreviewMenu_Click(object sender, RoutedEventArgs e)
        {
            WindowPreviewProject preview = new WindowPreviewProject();
            preview.ShowDialog();
        }

        private void ExitMenu_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ProjTestingMenu_Click(object sender, RoutedEventArgs e)
        {
            WindowStudentTesting testing = new WindowStudentTesting();
            testing.ShowDialog();
            if (Program.CurrentProject != null)
            {
                currentNumQuest = 1;
               enabledMajorWindowElement(viewProjectInMajorWindow(currentNumQuest));
            }
        }

        #endregion

        private void ProjExitMenu_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

      

       

      

    }
}
