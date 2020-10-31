using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using WpfApplication1.Models;

namespace WpfApplication1.Service
{
    public class StudentService : IStudentService
    {
        //get data
        private List<StudentModel> _data;
        public StudentService()
        {
            _data = LoadFromFile().Students;
        }

        public static Dataset LoadFromFile()
        {
            XmlSerializer reader = new XmlSerializer(typeof(Dataset));
            StreamReader file = new StreamReader("student_sample_data.xml");

            Dataset data = (Dataset)reader.Deserialize(file);
            file.Close();
            return data;
        }

        //add student to list
        public StudentModel Add(StudentModel student)
        {
            return _data.Add(student);
        }

        //get all class
        public List<string> GetAllClasses()
        {
            //List<ClassModel> aa = new List<ClassModel>();
            var aa = _data.Select(s => s.Class).Distinct().ToList();
            return aa;
        }

        //delete student
        public void Remove(int studentId)
        {
            throw new NotImplementedException();
        }

        //search student
        public List<StudentModel> SearchStudent(StudentSearchCriteria criteria)
        {
            return _data.Where(s => 
                        (
                        string.IsNullOrEmpty(criteria.SearchText) ||
                        s.FirstName.Contains(criteria.SearchText) ||
                        s.LastName.Contains(criteria.SearchText) ||
                        s.Email.Contains(criteria.SearchText) ||
                        s.StudentId.ToString().Contains(criteria.SearchText)
                        ) 
                        && 
                        (
                        string.IsNullOrEmpty(criteria.ClassName) ||
                        s.Class == criteria.ClassName
                        )
                    ).ToList();
        }

        //update student
        public StudentModel Update(StudentModel student)
        {
            throw new NotImplementedException();
        }
    }
}
