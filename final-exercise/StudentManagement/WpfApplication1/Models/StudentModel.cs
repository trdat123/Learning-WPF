using System;
using System.Collections.Generic;

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

        public string StudentId { get; set; }

        public string Class { get; set; }

        public DateTime Birthdate { get; set; }

        public List<Result> exam { get; set; }
    }

    public class Result
    {
        public string subject { get; set; }

        public int point { get; set; }
    }
}
