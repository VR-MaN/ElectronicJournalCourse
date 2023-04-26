using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicJournalCourse
{
    // Třídní operační skupina
     class Group
    {
        private string number;
        private List<Student> students = new List<Student> { };
        

        public Group() { }

        public Group(string number,List<Student> students)
        {
            this.number = number;
            this.students = students;
        }
        public string Number { get { return number; }set { number = value; } }
        public List<Student> Student { get { return students; } set { students=value; } }


        public override string ToString()
        {
            return number.ToString();
        }
    }
}
