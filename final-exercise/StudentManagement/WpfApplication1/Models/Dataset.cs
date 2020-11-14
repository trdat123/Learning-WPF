using System.Collections.Generic;
using System.Xml.Serialization;

namespace WpfApplication1.Models
{
    [XmlRoot("Dataset")]
    public class Dataset
    {
        [XmlElement("Student")]
        public List<StudentModel> Students { get; set; }
    }
}
