using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace WpfApplication1.Models
{
    public class StudentModel : Conductor<object>
    {
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
