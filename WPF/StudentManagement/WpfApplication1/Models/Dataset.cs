using System.Collections.Generic;
using System.Xml.Serialization;
using WpfApplication1.Models;

namespace WpfApplication1.Models {
    [XmlRoot("dataset")]
    public class Dataset {

        [XmlElement("Student")]
        public List<StudentModel> Students { get; set; }
    }
}
