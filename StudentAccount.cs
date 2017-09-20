

namespace EducationTest
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class StudentAccount
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public Guid GuidAccount { get; set; }
        public DateTime RegistredData { get; set; }
        public int CountSolvedTest { get; set; }
        public List<StudentSolvedTest> SolvedTests { get; set; }

        public StudentAccount(string name, string password, Guid guidAccount)
        {
            Name = name;
            Password = password;
            GuidAccount = guidAccount;
            SolvedTests = new List<StudentSolvedTest>();
        }
    }
}
