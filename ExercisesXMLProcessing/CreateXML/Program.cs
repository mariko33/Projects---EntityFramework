using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace CreateXML
{
    class Program
    {
        static void Main()
        {
            //Task 1
            //XmlDocument doc=new XmlDataDocument();
            //XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            //XmlElement root = doc.DocumentElement;
            //doc.InsertBefore(xmlDeclaration, root);
            //XmlElement students = doc.CreateElement("students");
            //doc.AppendChild(students);
            //XmlElement student = doc.CreateElement("student");
            //students.AppendChild(student);
            //XmlElement name = doc.CreateElement("name");
            //student.AppendChild(name);
            //XmlElement gender = doc.CreateElement("gender");
            //student.AppendChild(gender);
            //XmlElement birthDate = doc.CreateElement("BirthDate");
            //student.AppendChild(birthDate);
            //XmlElement phoneNumber = doc.CreateElement("PhoneNuber");
            //student.AppendChild(phoneNumber);
            //XmlElement email = doc.CreateElement("Email");
            //student.AppendChild(email);
            //XmlElement exams = doc.CreateElement("Exams");
            //student.AppendChild(exams);
            //XmlElement examDate = doc.CreateElement("ExamsDate");
            //exams.AppendChild(examDate);
            //XmlElement dateTaken = doc.CreateElement("DateTaken");
            //exams.AppendChild(dateTaken);
            //XmlElement grade = doc.CreateElement("Grade");
            //exams.AppendChild(grade);
            //doc.Save("../../../dataexit/students.xml");

            XElement root=new XElement("students");
            XElement student=new XElement("student");
            student.Add(new XElement("name"));
            student.Add(new XElement("gender"));
            student.Add(new XElement("birthDate"));
            //student.Add(new XElement("exams"));
            XElement exams=new XElement("exams");
            exams.Add(new XElement("examName"));
            exams.Add(new XElement("dateTaken"));
            exams.Add(new XElement("grade"));
            student.Add(exams);
            root.Add(student);
            root.Save("../../../dataexit/students2.xml");

        }
    }
}
