using OpenXmlPowerTools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Pierwszy_Projekt
{
    public class Program
    {
        public static void Main(string[] args)
        {

            try
            {


                var hash = new HashSet<Student>(new OwnComparer());
                var path_to_source_csv = @"C:\";
                var path_to_save_log = @"C:\";
                var path_to_save_xml = @"C:\";
                var rodzaj = @"xml";
                var str = string.Empty;

                Console.WriteLine("podaj sciezke do pliku csv i wcisnij enter: ");
                str = Console.ReadLine();

                if (!string.IsNullOrEmpty(str))
                {
                    path_to_source_csv = str + @"\dane.csv";
                   
                }
                else
                {
                    path_to_source_csv = path_to_source_csv + @"\dane.csv";
                    
                }
               
                Console.WriteLine("podaj sciezke gdzie zapisany ma byc plik i wcisnij enter: ");
                str = Console.ReadLine();

                if (!string.IsNullOrEmpty(str))
                {
                    path_to_save_xml =  str;
                    path_to_save_log = str + @"\łog.txt";
                }
                else
                {
                    path_to_save_xml = path_to_save_xml;
                    path_to_save_log = path_to_save_log + @"\łog.txt";

                }

                Console.WriteLine("podaj rodzaj pliku jaki chcemy zapisac : ");
                str = Console.ReadLine();

                if (!string.IsNullOrEmpty(str))
                {
                    rodzaj = str;
                }
                else
                {
                    rodzaj = rodzaj;
                }


                var lines = File.ReadLines(path_to_source_csv);
                var todaysDate = DateTime.Today;
                var today = DateTime.UtcNow;
                StreamWriter streamWriter = new StreamWriter(path_to_save_log);


                foreach (var line in lines)
                {
                    string[] split = line.Split(',');

                    var newStu = new Student
                    {
                        FirstName = split[0],
                        LastName = split[1],
                        rodzaj_studiow = split[2],
                        tryb_studiow = split[3],
                        Index = "s" + split[4],
                        data = split[5],
                        mail = split[6],
                        imie_Matki = split[7],
                        imie_Ojca = split[8]
                    };




                    if (!hash.Add(newStu))
                    {
                        streamWriter.WriteLine(line);
                    }
                    else
                    {
                        hash.Add(newStu);
                    }




                }

                Console.WriteLine(today);


                if (rodzaj.Equals("xml")) {
                    XDocument xmlFile = new XDocument(new XElement("uczelnia",
                                new XAttribute("createdAt", todaysDate),
                                 new XAttribute("author", "Dominik Kabala"),

                                new XElement("studenci",
                                    from student in hash
                                    select new XElement("student",
                                        new XAttribute("indexNumber", student.Index),
                                        new XElement("fname", student.FirstName),
                                        new XElement("lname", student.LastName),
                                        new XElement("birthdate", student.data),
                                        new XElement("email", student.mail),
                                        new XElement("mothersName", student.imie_Matki),
                                        new XElement("fathersName", student.imie_Ojca),
                                        new XElement("studies",
                                            new XElement("name", student.rodzaj_studiow),
                                            new XElement("mode", student.tryb_studiow)
                                        )
                                    )
                                )));

                    xmlFile.Save(path_to_save_xml + @"\żesult.xml");
                }

            } catch(ArgumentException ex)
            {

                Console.WriteLine(ex + "bledna sciezka");

            }

            catch (FileNotFoundException ex)
            {

                Console.WriteLine(ex + "Plik nie istnieje");

            }




        }


        


    }
}