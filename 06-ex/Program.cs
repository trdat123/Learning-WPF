using System;
using _06_ex.Model;
using System.Collections.Generic;

namespace base_project
{

    class Program
    {
        static void Main(string[] args)
        {
            List<Student> studentList = new List<Student>();
            studentList.Add(new Student { StudentName = "John Cena", StudentID = 1 });
            //First name is "John"
            studentList.Add(new Student { StudentName = "Cena John", StudentID = 3 });
            //First name is "Cena"
            studentList.Add(new Student { StudentName = "The Rock", StudentID = 2 });
            //First name is "The"

            studentList.Sort(); //Sort by ID
            System.Console.WriteLine("Sort by ID...");
            foreach (var item in studentList)
            {
                System.Console.WriteLine($"Name: {item.StudentName}\nID: {item.StudentID}");
            }

            studentList.Sort(new FirtNameComparer()); //Sort by First Name
            System.Console.WriteLine("\nSort by First Name...");
            foreach (var item in studentList)
            {
                System.Console.WriteLine($"Name: {item.StudentName}\nID: {item.StudentID}");
            }


        }
    }
}
