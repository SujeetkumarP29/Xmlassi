using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Xmlassi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("------------ Choose the Below option for What would you like to do?---------------");
            Console.WriteLine("-----------------------1. Create a new XML file-----------------------------------");
            Console.WriteLine("---------------------2. Read an existing XML file---------------------------------");
            Console.WriteLine("------------3. Display employee details from an existing XML file-----------------");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateXml();
                    break;
                case "2":
                    ReadXml();
                    break;
                case "3":
                    DisplayEmployeeDetails();
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }

        static void CreateXml()
        {
            XmlDocument doc = new XmlDocument();
            XmlElement root = doc.CreateElement("Employees");
            doc.AppendChild(root);

            Console.WriteLine("Enter the number of employees:");
            int numEmployees = int.Parse(Console.ReadLine());

            for (int i = 0; i < numEmployees; i++)
            {
                XmlElement employee = doc.CreateElement("Employee");

                XmlElement id = doc.CreateElement("EmployeeID");
                Console.WriteLine("Enter Employee ID:");
                id.InnerText = Console.ReadLine();
                employee.AppendChild(id);

                XmlElement name = doc.CreateElement("EmployeeName");
                Console.WriteLine("Enter Employee Name:");
                name.InnerText = Console.ReadLine();
                employee.AppendChild(name);

                XmlElement salary = doc.CreateElement("EmployeeSalary");
                Console.WriteLine("Enter Employee Salary:");
                salary.InnerText = Console.ReadLine();
                employee.AppendChild(salary);

                XmlElement Designation = doc.CreateElement("EmployeeName");
                Console.WriteLine("Enter Employee Designation:");
                Designation.InnerText = Console.ReadLine();
                employee.AppendChild(Designation);



                root.AppendChild(employee);
            }

            doc.Save("employees.xml");
        }

        static void ReadXml()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("employees.xml");

            Console.WriteLine("XML file contents:");
            Console.WriteLine(doc.InnerXml);
            Console.ReadLine();
        }

        static void DisplayEmployeeDetails()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("employees.xml");

            XmlNodeList employees = doc.SelectNodes("//Employee");
            Console.WriteLine("Employee details:");

            foreach (XmlNode employee in employees)
            {
                string id = employee.SelectSingleNode("EmployeeID").InnerText;
                string name = employee.SelectSingleNode("EmployeeName").InnerText;
                string salary = employee.SelectSingleNode("EmployeeSalary").InnerText;
                string Designation = employee.SelectSingleNode("EmployeeDesignation").InnerText;

                Console.WriteLine($"ID: {id}, Name: {name}, Salary: {salary},Designation:{Designation}");
                Console.ReadLine();
            }
        }
    }
}
        
    

