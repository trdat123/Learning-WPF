using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
