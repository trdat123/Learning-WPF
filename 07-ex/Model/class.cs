using System;
using System.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization.XmlSerializer;

namespace 07_e x.Model {
        public class Student : ISerializable
        {
            public int Id { get; set }; 
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Gender { get; set; }
            public string City { get; set; }
            public int StudentId { get; set; }
            public Student () {
                Result = new List<Result> ();
            }
            public List<Result> Employees { get; set; }

            public void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                info.AddValue("Id", Id);
                info.AddValue("FirstName", FirstName);
                info.AddValue("LastName", LastName);
                info.AddValue("Email", Email);
                info.AddValue("Gender", Gender);
                info.AddValue("City", City);
                info.AddValue("StudentId", StudentId);
                
            }

            public Student(SerializationInfo info, StreamingContext context)
            {
                Id = (int)info.GetValue("Id", typeof(int));
                FirstName = (string)info.GetValue("FirstName", typeof(string));
                LastName = (string)info.GetValue("LastName", typeof(string));
                Email = (string)info.GetValue("Email", typeof(string));
                Gender = (string)info.GetValue("Gender", typeof(string));
                City = (string)info.GetValue("City", typeof(string));
                StudentId = (int)info.GetValue("StudentId", typeof(int));
    }
        }
   
            public class Result {
                public string Subject { get; set; }

                public int Score { get; set; }
            }

            /*
            public override string ToString()
            {
            return string.Format("ID: {0}\nFirst Name: {1}\nLast Name: {2}\nEmail: {3}\nGender: {4}\n" +
                "City: {5}\nStudentID: {6}\n");
            }*/
}