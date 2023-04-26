using System.Collections.Generic;

namespace ElectronicJournalCourse
{
    // Třída popisující položky
     class Subject
    {
        private string _name = "";
        private List<Grade> _grade ;

        public Subject() { }

        public Subject(string name)
        {
            _name=name;
        }

        public Subject(string name,List<Grade> grade)
        {
            _name = name;
            _grade = grade;
        }
        public string Name {

            get { return _name;} 
            set { _name = value; } 
        }
        public List<Grade> Grade { get { return _grade; } 
        set { _grade = value; }
        }
        
        


    }
}