using System;

namespace ElectronicJournalCourse
{
    // Třída Popis hodnocení
    internal class Grade : IComparable<Grade>   
    {
        string count;
        DateTime date;

        public Grade() { }
        public Grade(string count,DateTime date)
        {
            this.count = count;
            this.date = date;
        }
        public string Count { get { return count; } set { count=value; } }
        public DateTime Date { get { return date; } set { date=value; } }

       
        public int CompareTo(Grade other)
        {
            return date.CompareTo(other.date);
        }
    }
}