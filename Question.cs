

namespace EducationTest
{
    using System.Collections.Generic;

    public  class Question
    {
        public int id { get; set; }
        public string Text { get; set; }
        public List<Answer> Answers { get; set; }
        public int CountAnswers { get { return Answers.Count; } }

        public Question()
        {
            Answers = new List<Answer>();
        }
        
        public void AnswersIdSort()
        {
            int id = 1;
            foreach (Answer select in Answers)
            {
                select.id = id;
                ++id;
            }
        }
    }
}
