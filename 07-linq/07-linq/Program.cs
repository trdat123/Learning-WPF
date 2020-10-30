using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System.Linq;
using _07_linq;

namespace _07_ex
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Dataset data = LoadDataFromXml();

            //Print out students
            //ListData (data.Students, s => $"{s.FirstName} {s.LastName}");

            // List students who must repeat subject: has a subject less than 5
            Console.WriteLine("\n---Students who has a subject less than 5---");
            SubjectLessThan5(data);

            // Statistic student by Gender
            Console.WriteLine("---Statistic by gender---");
            StatisticByGender(data);

            // Statistic student by Class
            Console.WriteLine("---Statistic by Class---");
            StatisticByClass(data);

            // Calculate GPA of each student
            Console.WriteLine("\n---GPA of each student---");
            CalculateGPA(data);
        }

        private static Dataset LoadDataFromXml()
        {
            XmlSerializer reader = new XmlSerializer(typeof(Dataset));
            StreamReader file = new StreamReader(@"C:\Users\Tr Dat\Desktop\WindowsProgrammingExcercises\07-ex\student_sample_data.xml");

            Dataset data = (Dataset)reader.Deserialize(file);
            file.Close();
            return data;
        }

        private static void ListData<T>(IEnumerable<T> data, Func<T, string> selector)
        {
            foreach (var s in data.ToList())
            {
                Console.WriteLine(selector.Invoke(s));
            }
        }

        private static void StatisticByGender(Dataset data)
        {
            var genderData = data.Students.GroupBy(s => s.Gender, s => s.Id,
                (k, v) => new { Gender = k, Number = v.Count() });

            ListData(genderData, g => $"{g.Gender}: {g.Number}");
        }

        private static void StatisticByClass(Dataset data)
        {
            var classData = data.Students.GroupBy(s => s.Class, s => s.Id,
                (k, v) => new { Class = k, Number = v.Count() });

            ListData(classData, g => $"{g.Class}: {g.Number}");
        }

        private static void CalculateGPA(Dataset data)
        {
            // Prepare Result list
            //List<Result> resultList = data.Students.SelectMany(s => s.Exam).ToList();
            //resultList.GroupBy(r => r.StudentId, r => r.Score,
            //    (studentId, listScore) => new { StudentId = studentId, Gpa = listScore.Average() });

            var gpaData = data.Students.Select(s => new {
                Name = $"{s.FirstName} {s.LastName}",
                //Gpa = s.Exam.Select(e => e.Score).Average()
                Gpa = s.Exam.Average(e => e.Score)
            });
            ListData(gpaData, g => $"{g.Name}: {g.Gpa}");
        }

        private static void SubjectLessThan5(Dataset data)
        {
            var repeatedStudents = data.Students.Where(x => x.Exam.Any(r => r.Score < 5));
            ListData(repeatedStudents, s => $"{s.FirstName} {s.LastName}");
            Console.ReadLine();
        }
    }
}