using System;
using System.Xml;
namespace _07_linq
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("student_sample_data.xml");
            foreach(XmlNode node in doc.DocumentElement.ChildNodes){
                string text = node.InnerText;
                Console.WriteLine(text);
            }
            
        }
    }
}
