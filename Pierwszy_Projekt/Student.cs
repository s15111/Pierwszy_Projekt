using HtmlParserSharp.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Pierwszy_Projekt
{

    public class Student
    {
        [XmlElement(elementName: "indexNumber")]
        public string Index { get; set; }

        [XmlElement(elementName: "fname")]
        public string FirstName { get; set; }

        [XmlElement(elementName: "lname")]
        public string LastName { get; set; }

        [XmlElement(elementName: "birthdate")]
        public string data { get; set; }

        [XmlElement(elementName: "email")]
        public string mail { get; set; }

        [XmlElement(elementName: "MothersName")]
        public string imie_Matki { get; set; }

        [XmlElement(elementName: "FathersName")]
        public string imie_Ojca { get; set; }

        [XmlElement(elementName: "StudesName")]
        public string rodzaj_studiow { get; set; }

        [XmlElement(elementName: "StudiesMode")]
        public string tryb_studiow { get; set; } 
     
      
        
       
       
    }
}
