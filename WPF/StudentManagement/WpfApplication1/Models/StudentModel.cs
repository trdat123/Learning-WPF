using System.Collections.Generic;
using Caliburn.Micro;
using System.IO;
using System.Xml.Serialization;
using System;

namespace WpfApplication1.Models
{
    public class StudentModel
    {
        public bool Checked { get; set; }
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Gender { get; set; }

        public string City { get; set; }

        public int StudentId { get; set; }

        public string Class { get; set; }

        public List<Result> Exam { get; set; }

    }

    public class Result
    {
        public string Subject { get; set; }

        public int Score { get; set; }
    }
}
