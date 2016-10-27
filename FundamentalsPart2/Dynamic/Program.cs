using System;
using System.Diagnostics;
using System.Dynamic;
using System.Reflection;
using System.Xml.Linq;
using static System.Console;
namespace Dynamic
{
    class Program
    {
        static void Main(string[] args)
        {
            dynamic doc = new DynamicXml("Employees.xml");
            foreach (var employee in doc.Employees)
            {
                WriteLine(employee.FirstName);
            }
            ReadLine();
        }

        private static void ExpandoObjectWithXml()
        {
            var doc = XDocument.Load("Employees.xml");
            foreach (var element in doc.Element("Employees").Elements("Employee"))
            {
                WriteLine(element.Element("FirstName").Value);
            }

            var doc2 = XDocument.Load("Employees.xml").AsExpando();
            foreach (var employee in doc2.Employees)
            {
                WriteLine(employee.FirstName);
            }
        }

        private static void ExpandoDemo()
        {
            dynamic expando = new ExpandoObject();
            expando.Name = "Ravi Shankar";
            expando.Speak = new Action(() => Console.WriteLine(expando.Name));
            expando.Speak();

            foreach (var member in expando)
            {
                WriteLine(member.Key);
            }
        }

        private static void AutomateExcelCreationWithoutInteropDllReferenceWithDynamic()
        {
            Type excelType = Type.GetTypeFromProgID("Excel.Application");

            dynamic excel = Activator.CreateInstance(excelType);

            excel.Visible = true;
            excel.Workbooks.Add();

            dynamic sheet = excel.ActiveSheet();

            Process[] processes = Process.GetProcesses();
            for (int i = 0; i < processes.Length; i++)
            {
                sheet.Cells[i + 1, "A"] = processes[i].ProcessName;
                sheet.Cells[i + 1, "B"] = processes[i].Threads.Count;
            }
        }

        private static void DynamicDemo()
        {
            object obj = GetSpeaker();
            // ((Employee)obj).Speak();
            // obj.GetType().GetMethod("Speak").Invoke(obj, null);

            dynamic dyn = GetSpeaker();

            //dyn.Speak();

            Type testDynamic = Assembly.Load("TestClassLibrary").GetTypes()[0];
            dynamic testDynamicObj = Activator.CreateInstance(testDynamic);
            testDynamicObj.Speak();
        }

        private static object GetSpeaker()
        {
            return new Employee() { FirstName = "Ravi Shankar Boyina" };
        }
    }

    class Employee
    {
        public string FirstName { get; set; }
        public void Speak()
        {
            WriteLine("My name is {0}", FirstName);
        }
    }
}
