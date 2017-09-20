
namespace EducationTest
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class StudentSolvedTest
    {
        public Guid GuidTest { get; set; }
        public string NameTest { get; set; }
        public DateTime TimeTest { get; set; }
        public int CountQuestions { get; set; }
        public int CountAnswers { get; set; }
        public int CountStudentAnswers { get; set; }
        public int CountTrunessAnswers { get; set; }
        public int CountTrunessStudentAnswers { get; set; }

        public StudentSolvedTest(string nameTest,Guid guidTest)
        {
            NameTest = nameTest;
            GuidTest = guidTest;
        }
    }
}
