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

            //// List students who must repeat subject: has a subject less than 5
            //Console.WriteLine("\n---Students who has a subject less than 5---");
            //SubjectLessThan5(data);

            //// Statistic student by Gender
            //Console.WriteLine("\n---Statistic by gender---");
            //StatisticByGender(data);

            //// Statistic student by Class
            //Console.WriteLine("\n---Statistic by Class---");
            //StatisticByClass(data);

            //// Statistic by city
            //Console.WriteLine("\n---Statistic by city---");
            //StatisticByCity(data);

            //// Calculate GPA of each student
            //Console.WriteLine("\n---GPA of each student---");
            //CalculateGPA(data);

            ////Highest GPA
            //Console.WriteLine("\n---Student who has highest GPA---");
            //HighestGPA(data);

            //Highest score each subject
            Console.WriteLine("\n---Highest score each subject---");
            HighestScoreEach(data);
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
            Console.ReadLine();
        }

        private static void StatisticByClass(Dataset data)
        {
            var classData = data.Students.GroupBy(s => s.Class, s => s.Id,
                (k, v) => new { Class = k, Number = v.Count() });

            ListData(classData, g => $"{g.Class}: {g.Number}");
            Console.ReadLine();
        }

        private static void StatisticByCity(Dataset data)
        {
            var cityData = data.Students.GroupBy(s => s.City, s => s.Id,
                (k, v) => new { City = k, Number = v.Count() });

            ListData(cityData, g => $"{g.City}: {g.Number}");
            Console.ReadLine();
        }

        private static void CalculateGPA(Dataset data)
        {
            var gpaData = data.Students.Select(s => new {
                Name = $"{s.FirstName} {s.LastName}",
                Gpa = s.exam.Average(e => e.point)
            });
            ListData(gpaData, g => $"{g.Name}: {g.Gpa}");
            Console.ReadLine();
        }

        private static void SubjectLessThan5(Dataset data)
        {
            var repeatedStudents = data.Students.Where(x => x.exam.Any(r => r.point < 5));
            ListData(repeatedStudents, s => $"{s.FirstName} {s.LastName}");
            Console.ReadLine();
        }

        private static void HighestGPA(Dataset data)
        {
            var gpaData = data.Students.Select(s => new { Gpa = s.exam.Average(e => e.point) });
            ListData(gpaData, g => $"{g.Gpa}");
            Console.ReadLine();
        }

        private static void HighestScoreEach(Dataset data)
        {
            var result = data.Students.Select(s => new
            {
                Subject = $"{s.exam.Select(e => e.subject)}",
                Name = $"{s.exam.Where(e => e.point == 10)}"
            });
            ListData(result, r => $"{r.Subject}: {r.Name}");
            Console.ReadLine();
        }
    }
}