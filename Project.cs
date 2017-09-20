

namespace EducationTest
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;

  public class Project
  {
        public string PathProject{get{if(File.Exists(_PathProject))return _PathProject;return string.Empty;}set{}}
        private string _PathProject;

        private string _nameProject;

        public string NameProject
        {
            get { return _nameProject; }
            set { _nameProject = value; }
        }

     
        public Guid GuidProj { get { return _GuidProj; } set { _GuidProj = value; } }
        private Guid _GuidProj;

        public string KeyCript{ get { return _KeyCript; } set { } }
        private string _KeyCript;

        public List<Question> Questions;
        public int CountQuestions { get { return Questions.Count; } }

        public Project(string nameProject,string pathProject,Guid guidProj,string keyCript)
        {
            _nameProject = nameProject;
            _PathProject = pathProject;
            _GuidProj = guidProj;
            _KeyCript = keyCript;
            Questions = new List<Question>();
        }

        public void clearStudentSelectVarAnswer()
        {
            foreach(Question selectQ in Questions)
            {
                foreach(Answer selectA in selectQ.Answers)
                {
                    selectA.selectVarStudent = false;
                }
            }
        }
  }
}
