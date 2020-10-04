using System.Collections.Generic;
using System;

namespace _06_ex.Model
{
    public class Student : IComparable<Student>
    {
        public string StudentName { get; set; }
        public int StudentID { get; set; }
        public int CompareTo(Student other)
        {
            return this.StudentID.CompareTo(other.StudentID);
        }
    }

    public class FirtNameComparer : IComparer<Student>
    {
        public int Compare(Student x, Student y)
        {
            var firstName1 = x.StudentName.Substring(0, x.StudentName.IndexOf(" "));
            var firstName2 = y.StudentName.Substring(0, y.StudentName.IndexOf(" "));
            return firstName1.CompareTo(firstName2);
        }
    }
}