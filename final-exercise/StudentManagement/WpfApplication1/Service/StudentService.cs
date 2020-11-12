using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using WpfApplication1.Models;
using Caliburn.Micro;
using System.Xml;

namespace WpfApplication1.Service
{
    public class StudentService : Screen, IStudentService
    {
        //get data
        private List<StudentModel> _data;

        public List<StudentModel> data
        {
            get { return _data; }
            set {
                _data = value;
                NotifyOfPropertyChange(() => data);
            }
        }

        public StudentService()
        {
            data = LoadFromFile().Students;
        }

        public static Dataset LoadFromFile()
        {
            XmlSerializer reader = new XmlSerializer(typeof(Dataset));
            var fileName = @"C:\Users\Tr Dat\Desktop\WindowsProgrammingExcercises\final-exercise\StudentManagement\WpfApplication1\Models\student_sample_data.xml";
            StreamReader file = new StreamReader(fileName);
            Dataset data = (Dataset)reader.Deserialize(file);
            file.Close();
            return data;
        }

        //public void Save()
        //{
        //    StudentModel aa = new StudentModel();
        //    using (var stream = new FileStream("student_sample_data.xml", FileMode.Append, FileAccess.Write))
        //    {
        //        var XML = new XmlSerializer(typeof(Dataset));
        //        XML.Serialize(stream, (Dataset));
        //    }
        //}

        //add student to list
        public List<StudentModel> Add(StudentModel student)
        {
            data.Add(student);
            return data;
        }

        //get all class
        public List<string> GetAllClasses()
        {
            return data.Select(s => s.Class).Distinct().ToList();
        }

        //delete student
        public void Remove()
        {
            var selectedStudent = data.Where(s => s.Checked == true).ToList();
            foreach (var item in selectedStudent)
            {
                data.Remove(item);
            }
        }

        //search student
        public List<StudentModel> SearchStudent(StudentSearchCriteria criteria)
        {
            return data.Where(s => 
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
    }
}
