namespace EducationTest
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Security.Cryptography;

    public static class Program
    {
        public static string PathFolder { get; set; }
        public static string PathProject { get; set; }
        public static string PathAccount { get; set; }

        public static byte[] KeyCript = {10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25};
        public static byte[] IvCript = {10,11,12,13,14,15,16,19,18,19,20,21,22,23,24,25};

        public static Project CurrentProject = null;
        public static StudentAccount CurrentAccount = null;

        static Program()
        {
            PathFolder = AppDomain.CurrentDomain.BaseDirectory;
        }

        #region ProjectMethod

        #region OldNewProject
        /*
        public static bool NewProject(string Name)
        {
            if (Name != "")
            {
                //настройка и вызов SaveDialog
                Microsoft.Win32.SaveFileDialog createDlg = new Microsoft.Win32.SaveFileDialog();
                createDlg.InitialDirectory = PathFolder;
                createDlg.FileName = Name;
                createDlg.Title = "Создание нового файла";
                createDlg.DefaultExt = ".tcf";
                createDlg.Filter = "Test File Cript (.tfc)|*.tfc";
                Guid guidProj=Guid.NewGuid();
                
                if ((bool)createDlg.ShowDialog())
                {
                    //создание файла на диске
                    #region CreateFileOnDisk
                    try
                    {
                        using (FileStream createFile = new FileStream(createDlg.FileName, FileMode.Create))
                        {
                            StreamWriter writeFile = new StreamWriter(createFile);

                      

                            
                            #region TestWrite
                          
                            writeFile.WriteLine("<proj(" + Name + ";" + guidProj + ")>");
                            //вопрос qu(номер вопроса)
                            writeFile.WriteLine("<qu(1)>");
                            //текст вопроса
                            writeFile.WriteLine("<qtx>");
                            writeFile.WriteLine("Вопрос");
                            writeFile.WriteLine("</qtx>");
                            //закрыть текст вопроса
                            //ответы an(номер ответа,правильность) 
                            writeFile.WriteLine("<an(1;t)>");
                            writeFile.WriteLine("Ответ1");
                            writeFile.WriteLine("</an>");
                            //закрыть ответ
                            //ответы an(номер ответа,правильность) 
                            writeFile.WriteLine("<an(2;f)>");
                            writeFile.WriteLine("Ответ2");
                            writeFile.WriteLine("</an>");
                            //закрыть ответ
                            //ответы an(номер ответа,правильность) 
                            writeFile.WriteLine("<an(3;f)>");
                            writeFile.WriteLine("Ответ3");
                            writeFile.WriteLine("</an>");
                            //закрыть ответ
                            writeFile.WriteLine("</qu>");
                            //закрыть вопрос
                            writeFile.WriteLine("</proj>");
                            //закрыть проект
                            writeFile.Close();
                            createFile.Close();

                            #endregion
                        }
                    }
                    catch(Exception)
                    {
                        WindowMsgError errorFileNotExist = new WindowMsgError("Ошибка", "Тест не создан");
                        errorFileNotExist.ShowDialog();
                    }

                    #endregion

                    return OpenProject(createDlg.FileName);
                }
                return false;
            }
            return false;
        }
        */
        #endregion

        public static bool NewProject(string Name)
        {
            if (Name != "")
            {
                //настройка и вызов SaveDialog
                Microsoft.Win32.SaveFileDialog createDlg = new Microsoft.Win32.SaveFileDialog();
                createDlg.InitialDirectory = PathFolder;
                createDlg.FileName = Name;
                createDlg.Title = "Создание нового файла";
                createDlg.DefaultExt = ".tcf";
                createDlg.Filter = "Test File Cript (.tfc)|*.tfc";
                Guid guidProj = Guid.NewGuid();

                if ((bool)createDlg.ShowDialog())
                {
                    //создание файла на диске
                    #region CreateFileOnDisk
                    try
                    {
                        using (FileStream createFile = new FileStream(createDlg.FileName, FileMode.Create))
                        {

                            byte[] data;

                            #region textCriptInWrite

                            string[] textInCript=new string[16];
                            string temp=string.Empty;

                            #region text
                            textInCript[0]="<proj(" + Name + ";" + guidProj + ")>";
                            textInCript[1]="<qu(1)>";

                            textInCript[2]="<qtx>";
                            textInCript[3]="Вопрос";
                            textInCript[4]="</qtx>";

                            textInCript[5]="<an(1;t)>";
                            textInCript[6]="Ответ1";
                            textInCript[7]="</an>";

                            textInCript[8]="<an(2;f)>";
                            textInCript[9]="Ответ2";
                            textInCript[10]="</an>";

                            textInCript[11]="<an(3;f)>";
                            textInCript[12]="Ответ3";
                            textInCript[13]="</an>";

                            textInCript[14]="</qu>";
                            textInCript[15]="</proj>";

                            #endregion

                            foreach(string selectS in textInCript)
                            {
                                temp+=selectS+'\n';
                            }

                            data=System.Text.Encoding.UTF8.GetBytes(temp);



                            #endregion

                            using (SymmetricAlgorithm algorithm = Aes.Create())
                            using (ICryptoTransform encriptor = algorithm.CreateEncryptor(KeyCript, IvCript))
                            using (Stream cryptFile = new CryptoStream(createFile, encriptor, CryptoStreamMode.Write))
                                cryptFile.Write(data, 0, data.Length);
                            
                
                        }
                    }
                    catch (Exception)
                    {
                        WindowMsgError errorFileNotExist = new WindowMsgError("Ошибка", "Тест не создан");
                        errorFileNotExist.ShowDialog();
                    }

                    #endregion

                    return OpenProject(createDlg.FileName);
                }
                return false;
            }
            return false;
        }


        public static bool OpenProject(string path="")
        {
            if (path == "")
            {
                Microsoft.Win32.OpenFileDialog openDlg = new Microsoft.Win32.OpenFileDialog();
                openDlg.InitialDirectory = PathFolder;
                openDlg.Title = "Загрузка файла";
                openDlg.FileName = "";
                openDlg.DefaultExt = ".tcf";
                openDlg.Filter = "Test File Cript (.tfc)|*.tfc";
                Nullable<bool> result = openDlg.ShowDialog();

                if (result != true)
                {
                   // WindowMsgError errorFileNotFound = new WindowMsgError("Ошибка","Тест не найден");
                   // errorFileNotFound.ShowDialog();
                    return false;
                }
                PathProject = openDlg.FileName;
            }
            else
            {
                if (File.Exists(path))
                    PathProject = path;
                else
                {
                    WindowMsgError errorFileNotFound = new WindowMsgError("Ошибка", "Неверный путь к тесту");
                    errorFileNotFound.ShowDialog();
                    return false;
                }
            }

            try
            {
                #region deCrypt
                string temp = string.Empty;
                using (SymmetricAlgorithm algorithm = Aes.Create())
                using (ICryptoTransform decriptor = algorithm.CreateDecryptor(KeyCript, IvCript))
                using (Stream fileOpenRead = File.OpenRead(PathProject))
                using (Stream cryptFile = new CryptoStream(fileOpenRead, decriptor, CryptoStreamMode.Read))
                using (StreamReader fileReader = new StreamReader(cryptFile))
                    temp = fileReader.ReadToEnd();

                string[] file = temp.Split('\n');
                #endregion

                return ParserProject(file, PathProject);
            }
            catch (Exception)
            {
                WindowMsgError error = new WindowMsgError("Ошибка", "Ошибка шифра");
                error.ShowDialog();
                return false;
            }
        }


        public static bool SaveOrSaveAsProject(string path="")
        {
            if (path == "")
            {
                if (CurrentProject != null)
                {
                    //настройка и вызов SaveDialog
                    Microsoft.Win32.SaveFileDialog createDlg = new Microsoft.Win32.SaveFileDialog();
                    createDlg.InitialDirectory = PathFolder;
                    createDlg.FileName = CurrentProject.NameProject;
                    createDlg.Title = "Сохранение файла";
                    createDlg.DefaultExt = ".tcf";
                    createDlg.Filter = "Test File Cript (.tfc)|*.tfc";
                    Nullable<bool> result = createDlg.ShowDialog();

                    if (result != true)
                    {
                   //     WindowMsgError errorFileNotExist = new WindowMsgError("Ошибка", "Тест не найден");
                     //   errorFileNotExist.ShowDialog();
                        return false;
                    }
                    PathProject = createDlg.FileName;
                }


            }
            else
            {
                if (File.Exists(path))
                    PathProject = path;
                else
                {
                    WindowMsgError errorFileNotExist = new WindowMsgError("Ошибка", "Неверный путь к тесту");
                    errorFileNotExist.ShowDialog();
                    return false;
                }
            }
                    
                        //создание файла на диске
                        #region CreateFileOnDisk
            try
            {

              


                using (FileStream createFile = new FileStream(PathProject, FileMode.Create))
                {

                    #region CriptWrite

                    List<string> fileList= new List<string>();

                    #region WriteProjInList<String>

                    fileList.Add("<proj(" + CurrentProject.NameProject + ";" + CurrentProject.GuidProj + ")>");

                    foreach (Question quest in CurrentProject.Questions)
                    {
                        fileList.Add("<qu(" + quest.id + ")>");
                        fileList.Add("<qtx>");
                        fileList.Add(quest.Text);
                        fileList.Add("</qtx>");

                        foreach (Answer answer in quest.Answers)
                        {
                            char Triness = answer.Trueness ? 't' : 'f';
                            fileList.Add("<an(" + answer.id + ";" + Triness + ")>");
                            fileList.Add(answer.Text);
                            fileList.Add("</an>");

                        }

                        fileList.Add("</qu>");
                    }

                    fileList.Add("</proj>");

                    #endregion

                    string data=string.Empty;
                    foreach (string temp in fileList)
                    {
                        data += temp + '\n';
                    }

                    using (SymmetricAlgorithm algorithm = Aes.Create())
                    using (ICryptoTransform encriptor = algorithm.CreateEncryptor(KeyCript, IvCript))
                    using (Stream cryptFile = new CryptoStream(createFile, encriptor, CryptoStreamMode.Write))
                    using (StreamWriter writeFile = new StreamWriter(cryptFile))
                    {

                        writeFile.Write(data);

                    }

                }

                    #endregion


            }
            catch(Exception)
            {
                WindowMsgError errorFileNotExist = new WindowMsgError("Ошибка", "Ошибка сохранения теста");
                errorFileNotExist.ShowDialog();
                return false;
            }
                        #endregion
            return true;
                   
        }

        static bool ParserProject(string[] readinFile, string pathProject)
        {   //вхождение в блок проекта
            bool inProj = false;
            string nameProject = "";
            Guid guidProj = Guid.Empty;
            //вхождение в блок вопроса
            bool inQuestion = false;
            Question currentQuestion = null;
            //вхождение в блок текста вопроса
            bool inQuText = false;
            string questionText = "";
            //входжение в блок ответа
            bool inAnwer = false;
            string anwerText = "";
            Answer currentAnwer = null;
            string line="";

            try
            {

                foreach (string searchCommand in readinFile)
                {
                    line += searchCommand;
                    if (line.Contains("<"))
                    {
                        if (line.Contains(">"))
                        {
                            //вырезаем команду из строки line
                            #region delete substring
                            string subStrCommand = line.Substring(line.IndexOf('<'), line.IndexOf('>'));
                            line = line.Remove(line.IndexOf('<'), line.IndexOf('>'));
                            #endregion

                            #region Command
                            string readLine = subStrCommand.Split('<')[1];
                            string command = readLine.Split('>')[0];
                            switch (command[0])
                            {
                                #region command first 'p'
                                case 'p':
                                    if (command.Substring(0, 4).CompareTo("proj") == 0)
                                    {
                                        string valStr = command.Split('(')[1];
                                        string nameProjectAndGuid = valStr.Split(')')[0];
                                        nameProject = nameProjectAndGuid.Split(';')[0];
                                        guidProj = Guid.Parse(nameProjectAndGuid.Split(';')[1]);
                                        CurrentProject = new Project(nameProject, pathProject, guidProj, Convert.ToBase64String (KeyCript));
                                        inProj = true;
                                    }
                                    break;
                                #endregion
                                #region command first 'q'
                                case 'q':
                                    if ((inProj) && (command[1] == 'u'))
                                    {
                                        string valStr = command.Split('(')[1];
                                        string idQuestion = valStr.Split(')')[0];
                                        currentQuestion = new Question();
                                        currentQuestion.id = Convert.ToInt32(idQuestion);
                                        inQuestion = true;
                                    }
                                    else
                                        if ((inQuestion) && (command[1] == 't'))
                                        {
                                            inQuText = true;
                                        }
                                    break;
                                #endregion
                                #region command first 'a'
                                case 'a':
                                    if ((inQuestion) && (inProj) && (command[1] == 'n'))
                                    {
                                        string valStr = command.Split('(')[1];
                                        string numAndTrueness = valStr.Split(')')[0];
                                        string num = numAndTrueness.Split(';')[0];
                                        string Trueness = numAndTrueness.Split(';')[1];
                                        currentAnwer = new Answer();
                                        currentAnwer.id = Convert.ToInt32(num);
                                        if (Trueness[0] == 't')
                                            currentAnwer.Trueness = true;
                                        if (Trueness[0] == 'f')
                                            currentAnwer.Trueness = false;
                                        inAnwer = true;
                                    }
                                    break;
                                #endregion
                                #region command first '/'
                                case '/':
                                    if (command[1] == 'a')
                                    {
                                        inAnwer = false;
                                        currentAnwer.Text = anwerText;
                                        currentQuestion.Answers.Add(currentAnwer);
                                    }
                                    else
                                        if (command[1] == 'q')
                                        {
                                            if (command[2] == 't')
                                            {
                                                inQuText = false;
                                                currentQuestion.Text = questionText;
                                            }
                                            else
                                                if (command[2] == 'u')
                                                {
                                                    inQuestion = false;
                                                    CurrentProject.Questions.Add(currentQuestion);
                                                }
                                        }
                                        else
                                            if (command[1] == 'p')
                                            {
                                                inProj = false;
                                                return true;
                                            }
                                    break;
                                #endregion
                            }


                            #endregion
                        }
                        else
                        {
                            //добавляем новую строку в line для поиска конца команды '>'
                            continue;
                        }
                    }
                    #region writeText
                    if ((inProj) && (inQuestion))
                    {
                        if (inQuText)
                        {
                            questionText = line;
                        }
                        if (inAnwer)
                        {
                            anwerText = line;
                        }
                    }
                    #endregion
                    line = "";

                }
            }
            catch (Exception)
            {
                WindowMsgError errorFileNotExist = new WindowMsgError("Ошибка", "Ошибка при чтении теста");
                errorFileNotExist.ShowDialog();
                return false;
            }
            WindowMsgError errorFileNotExist2 = new WindowMsgError("Ошибка", "Ошибка при чтении теста");
            errorFileNotExist2.ShowDialog();
            return false;
        }

        #endregion

        #region StudentAccount

        public static bool CreateAccount(string name,string password)
        {
            if (name != "")
            {
                //настройка и вызов SaveDialog
                Microsoft.Win32.SaveFileDialog createDlg = new Microsoft.Win32.SaveFileDialog();
                createDlg.InitialDirectory = PathFolder;
                createDlg.FileName = name;
                createDlg.Title = "Создание новой учётной записи";
                createDlg.DefaultExt = ".taf";
                createDlg.Filter = "Test Account File (.taf)|*.taf";
                Guid guidAccount = Guid.NewGuid();
                DateTime registerData = DateTime.Now;

                if ((bool)createDlg.ShowDialog())
                {
                    //создание файла на диске
                    #region CreateFileOnDisk
                    try
                    {
                        using (FileStream createFile = new FileStream(createDlg.FileName, FileMode.Create))
                        {

                            #region writeCriptAcciunt

                            List<string> fileList = new List<string>();

                            #region writeAccountInFileList

                            fileList.Add("<account(" + name + ";" + password + ";" + guidAccount + ")>");
                            fileList.Add("<reg(" + registerData.ToString() + ")>");
                            fileList.Add("<test(name;" + Guid.NewGuid().ToString() + ")");
                            fileList.Add("<time(" + DateTime.Now + ")>");
                            fileList.Add("<cqu(5)>");
                            fileList.Add("<can(20)>");
                            fileList.Add("<cans(4)>");
                            fileList.Add("<cant(5)>");
                            fileList.Add("<canst(4)>");
                            fileList.Add("</test>");
                            fileList.Add("</account>");

                            #endregion

                            string data = string.Empty;

                            foreach (string temp in fileList)
                            {
                                data += temp + '\n';
                            }

                            using (SymmetricAlgorithm algorithm = Aes.Create())
                            using (ICryptoTransform encriptor = algorithm.CreateEncryptor(KeyCript, IvCript))
                            using (Stream cryptFile = new CryptoStream(createFile, encriptor, CryptoStreamMode.Write))
                            using (StreamWriter writeFile = new StreamWriter(cryptFile))
                            {
                                writeFile.Write(data);
                            }

                            #endregion

                        }
                    }
                    catch(Exception)
                    {
                        WindowMsgError errorFileNotExist0 = new WindowMsgError("Ошибка", "Ошибка записи аккаунта");
                        errorFileNotExist0.ShowDialog();
                        return false;
                    }
                    #endregion

                    return ReadAccount(createDlg.FileName);
                }
                WindowMsgError errorFileNotExist = new WindowMsgError("Ошибка", "Аккаунт не создан");
                errorFileNotExist.ShowDialog();
                return false;
            }
            WindowMsgError errorFileNotExist2 = new WindowMsgError("Ошибка", "Неверное имя для аккаунта");
            errorFileNotExist2.ShowDialog();
            return false;
        }

        public static bool SaveAccount(string path = "")
        {
            if (path == "")
            {
                if (CurrentProject != null)
                {
                    //настройка и вызов SaveDialog
                    Microsoft.Win32.SaveFileDialog createDlg = new Microsoft.Win32.SaveFileDialog();
                    createDlg.InitialDirectory = PathFolder;
                    createDlg.FileName = CurrentProject.NameProject;
                    createDlg.Title = "Сохранение аккаунта";
                    createDlg.DefaultExt = ".taf";
                    createDlg.Filter = "Test Account File (.taf)|*.taf";
                    Nullable<bool> result = createDlg.ShowDialog();

                    if (result != true)
                    {
                     //   WindowMsgError errorFileNotExist = new WindowMsgError("Ошибка", "Аккаунт не найден");
                       // errorFileNotExist.ShowDialog();
                        return false;
                    }
                    PathAccount = createDlg.FileName;
                }


            }
            else
            {
                if (File.Exists(path))
                    PathAccount = path;
                else
                {
                    WindowMsgError errorFileNotExist = new WindowMsgError("Ошибка", "Неверный путь к аккаунту");
                    errorFileNotExist.ShowDialog();
                    return false;
                }
            }

            //создание файла на диске
            #region CreateFileOnDisk
            try
            {
                using (FileStream createFile = new FileStream(PathAccount, FileMode.Create))
                {

                    List<string> fileList = new List<string>();

                    #region writeAccountInFileList

                    fileList.Add("<account(" + CurrentAccount.Name + ";" + CurrentAccount.Password + ";" + CurrentAccount.GuidAccount + ")>");
                    fileList.Add("<reg(" + CurrentAccount.RegistredData + ")>");

                    foreach (StudentSolvedTest test in CurrentAccount.SolvedTests)
                    {
                        fileList.Add("<test(" + test.NameTest + ";" + test.GuidTest + ")>");
                        fileList.Add("<time(" + test.TimeTest + ")>");
                        fileList.Add("<cqu(" + test.CountQuestions + ")>");
                        fileList.Add("<can(" + test.CountAnswers + ")>");
                        fileList.Add("<cans(" + test.CountStudentAnswers + ")>");
                        fileList.Add("<cant(" + test.CountTrunessAnswers + ")>");
                        fileList.Add("<canst(" + test.CountTrunessStudentAnswers + ")>");
                        fileList.Add("</test>");
                    }

                    fileList.Add("</account>");

                    #endregion

                    string data = string.Empty;

                    foreach (string temp in fileList)
                    {
                        data += temp + '\n';
                    }

                    using (SymmetricAlgorithm algorithm = Aes.Create())
                    using (ICryptoTransform encriptor = algorithm.CreateEncryptor(KeyCript, IvCript))
                    using (Stream cryptFile = new CryptoStream(createFile, encriptor, CryptoStreamMode.Write))
                    using (StreamWriter writeFile = new StreamWriter(cryptFile))
                    {
                        writeFile.Write(data);
                    }
                   
                }
            }
            catch(Exception)
            {
                WindowMsgError errorFileNotExist = new WindowMsgError("Ошибка", "Аккаунт не сохранён");
                errorFileNotExist.ShowDialog();
                return false;
            }

            #endregion

            return true;
        }

        public static bool ReadAccount(string path="")
        {
            
            if(path=="")
            {
                Microsoft.Win32.OpenFileDialog openDlg = new Microsoft.Win32.OpenFileDialog();
                openDlg.InitialDirectory = PathFolder;
                openDlg.Title = "Загрузка aккаунта";
                openDlg.FileName = "";
                openDlg.DefaultExt = ".taf";
                openDlg.Filter = "Test Account File (.taf)|*.taf";
                Nullable<bool> result = openDlg.ShowDialog();

                if (result != true)
                {
                  //  WindowMsgError errorFileNotExist = new WindowMsgError("Ошибка", "Аккаунт не найден");
                    //errorFileNotExist.ShowDialog();
                    return false;
                }
                PathAccount = openDlg.FileName;
            }
            else
            {
                if (File.Exists(path))
                    PathAccount = path;
                else
                {
                    WindowMsgError errorFileNotExist = new WindowMsgError("Ошибка","Неверный путь к аккаунту");
                    errorFileNotExist.ShowDialog();
                    return false;
                }
            }
              //  string[] file = File.ReadAllLines(PathAccount);

            try
            {
                #region deCrypt
                string temp = string.Empty;
                using (SymmetricAlgorithm algorithm = Aes.Create())
                using (ICryptoTransform decriptor = algorithm.CreateDecryptor(KeyCript, IvCript))
                using (Stream fileOpenRead = File.OpenRead(PathAccount))
                using (Stream cryptFile = new CryptoStream(fileOpenRead, decriptor, CryptoStreamMode.Read))
                using (StreamReader fileReader = new StreamReader(cryptFile))
                    temp = fileReader.ReadToEnd();

                string[] file = temp.Split('\n');
                #endregion

                return ParserAccount(file);
            }
            catch (Exception)
            {
                WindowMsgError error = new WindowMsgError("Ошибка","Ошибка шифра");
                error.ShowDialog();
                return false;
            }
               
        }

        static bool ParserAccount(string[] readinFile)
        {

            //вхождение в блок аккаутна
            bool inAccount = false;
            bool inReg = false;
            string nameAccount = "";
            string passwordAccount = "";
            Guid guidAccount = Guid.Empty;
            DateTime dataReg = new DateTime();
            //вхождение в блок теста
            bool inTest = false;
            StudentSolvedTest currentTest = null;

            string line = "";

            try
            {

                foreach (string searchCommand in readinFile)
                {
                    line += searchCommand;
                    if (line.Contains("<"))
                    {
                        if (line.Contains(">"))
                        {
                            //вырезаем команду из строки line
                            #region delete substring
                            string subStrCommand = line.Substring(line.IndexOf('<'), line.IndexOf('>'));
                            line = line.Remove(line.IndexOf('<'), line.IndexOf('>'));
                            #endregion

                            #region Command
                            string readLine = subStrCommand.Split('<')[1];
                            string command = readLine.Split('>')[0];
                            switch (command[0])
                            {
                                #region command first 'a'
                                case 'a':
                                    if (command.Substring(0, 7).CompareTo("account") == 0)
                                    {
                                        string valStr = command.Split('(')[1];
                                        string nameStudentAndPasswordAndGuid = valStr.Split(')')[0];
                                        nameAccount = nameStudentAndPasswordAndGuid.Split(';')[0];
                                        passwordAccount = nameStudentAndPasswordAndGuid.Split(';')[1];
                                        guidAccount = Guid.Parse(nameStudentAndPasswordAndGuid.Split(';')[2]);
                                        CurrentAccount = new StudentAccount(nameAccount, passwordAccount,guidAccount);
                                        inAccount = true;
                                    }
                                    break;
                                #endregion
                                #region command first 'q'
                                case 'r':
                                    if ((inAccount) && (command[1] == 'e'))
                                    {
                                        string valStr = command.Split('(')[1];
                                        dataReg = DateTime.Parse( valStr.Split(')')[0]);
                                        CurrentAccount.RegistredData = dataReg;
                                        inReg = true;
                                    }

                                    break;
                                #endregion
                                #region command first 't'
                                case 't':
                                    if ((inAccount) && (inReg) && (command[1] == 'e'))
                                    {
                                        string valStr = command.Split('(')[1];
                                        string nameAndGuidTest = valStr.Split(')')[0];
                                        string nameTest = nameAndGuidTest.Split(';')[0];
                                        Guid guidTest = Guid.Parse(nameAndGuidTest.Split(';')[1]);
                                        currentTest = new StudentSolvedTest(nameTest,guidTest);
                                        inTest = true;
                                    }
                                    else
                                       if ((inAccount) && (inReg) && (inTest) && (command[1] == 'i'))
                                       {
                                           string valStr = command.Split('(')[1];
                                           DateTime timeTest = DateTime.Parse(valStr.Split(')')[0]);
                                           currentTest.TimeTest = timeTest;
                                       }
                                    break;
                                #endregion
                                #region command first 'c'
                                case 'c':
                                    if ((inAccount) && (inReg) && (inTest) && (command[1] == 'q'))
                                    {
                                        string valStr = command.Split('(')[1];
                                        int num = Convert.ToInt32(valStr.Split(')')[0]);
                                        currentTest.CountQuestions = num;
                                    }
                                    else
                                        if ((inAccount) && (inReg) && (inTest) && (command[1] == 'a'))
                                        {

                                            #region Result
                                            if (command.Substring(0, 3).CompareTo("can") == 0 && command[3]=='(')
                                            {
                                                string valStr = command.Split('(')[1];
                                                int num = Convert.ToInt32(valStr.Split(')')[0]);
                                                currentTest.CountAnswers = num;
                                            }

                                            else

                                                if (command.Substring(0, 4).CompareTo("cans") == 0 && command[4] == '(')
                                            {
                                                string valStr = command.Split('(')[1];
                                                int num = Convert.ToInt32(valStr.Split(')')[0]);
                                                currentTest.CountStudentAnswers = num;
                                            }

                                            else

                                                    if (command.Substring(0, 4).CompareTo("cant") == 0 && command[4] == '(')
                                            {
                                                string valStr = command.Split('(')[1];
                                                int num = Convert.ToInt32(valStr.Split(')')[0]);
                                                currentTest.CountTrunessAnswers = num;
                                            }

                                            else

                                                        if (command.Substring(0, 5).CompareTo("canst") == 0 && command[5] == '(')
                                            {
                                                string valStr = command.Split('(')[1];
                                                int num = Convert.ToInt32(valStr.Split(')')[0]);
                                                currentTest.CountTrunessStudentAnswers = num;
                                            }
                                            #endregion
                                        }
                                    break;
                                #endregion
                                #region command first '/'
                                case '/':
                                    if (command[1] == 'a')
                                    {
                                        inAccount = false;
                                        return true;
                                    }
                                    else
                                        if (command[1] == 't')
                                        {
                                            CurrentAccount.SolvedTests.Add(currentTest);
                                            inTest = false;
                                        }
                                    break;
                                #endregion
                            }


                            #endregion
                        }
                        else
                        {
                            //добавляем новую строку в line для поиска конца команды '>'
                            continue;
                        }
                    }
                    line = "";

                }
            }
            catch (Exception)
            {
                WindowMsgError error = new WindowMsgError("Ошибка","Ошибка при чтении файла аккаунта");
                error.ShowDialog();
                return false;
            }
            WindowMsgError error2 = new WindowMsgError("Ошибка", "Ошибка при чтении файла аккаунта");
            error2.ShowDialog();
            return false;
        }

        #endregion

    }
}