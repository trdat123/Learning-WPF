using System.Collections.Generic;
using Caliburn.Micro;
using System.IO;
using System.Xml.Serialization;

namespace WpfApplication1.Models
{
    [XmlRoot("dataset")]
    public class Dataset
    {
        [XmlElement("Student")]
        public List<StudentModel> Students { get; set; }

        public static Dataset LoadFromFile(string fileName)
        {
            using (var stream = new FileStream(fileName, FileMode.Open))
            {
                var XML = new XmlSerializer(typeof(Dataset));
                return (Dataset)XML.Deserialize(stream);
            }
        }
    }

    public class StudentModel
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
