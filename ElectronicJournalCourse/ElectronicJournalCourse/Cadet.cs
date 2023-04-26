namespace ElectronicJournalCourse
{
    using System;
    using System.Collections.Generic;

    internal class Cadet : IComparable<Cadet> //Třída popisující kadet
    {
        private string _firstName;
        private string _lastName;
        private string _numberGrup;
        private List<Subject> subjects = new List<Subject> { };

        public Cadet() { }

        public Cadet(string firstName,string lastName,string numberGrup)
        {
            _firstName = firstName;
            _lastName = lastName;
            _numberGrup = numberGrup;
        }
        public Cadet(string firstName, string lastName, string numberGrup,List<Subject> subjects)
        {
            _firstName = firstName;
            _lastName = lastName;
            _numberGrup = numberGrup;
            this.subjects = subjects;
        }
        public string FirstName { get { return _firstName; } set { _firstName=value; } }
        public string LastName { get { return _lastName;} set { _lastName=value; } }
        public string NumberGrup { get { return _numberGrup; } set { _numberGrup = value; } }
        public List<Subject> Subjects { get { return subjects; } set { subjects=value; } }

        public int CompareTo(Cadet other)
        {
            string s = _lastName+FirstName;
            string s2 = other._lastName+other._firstName;
            return s.CompareTo(s2);
        }

        public override string ToString()
        {
            return _lastName+" "+_firstName;
        }
    }
}