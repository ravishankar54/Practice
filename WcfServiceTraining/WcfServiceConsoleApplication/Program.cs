using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using WcfServiceLibrary;

namespace WcfServiceConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0 && args[0].Equals("ds"))
            {
                DeSerialize();
            }
            else
            {
                Serialize();
            }
        }
        static void Serialize()
        {
            Author author = new Author();
            author.FirstName = "Akshay";
            author.LastName = "Patel";
            author.StartDate = DateTime.Now;
            author.ArticleName = "WCF - Serialization - Day 6";
            using (FileStream fs = new FileStream("author.xml", FileMode.Create))
            {
                DataContractSerializer seraliazer = new DataContractSerializer(typeof(Author));
                seraliazer.WriteObject(fs, author);
            }
        }

        static void DeSerialize()
        {
            using (FileStream fs = new FileStream("author.xml", FileMode.Open))
            {
                DataContractSerializer deseraliazer = new DataContractSerializer(typeof(Author));
                Author author = deseraliazer.ReadObject(fs) as Author;
                Console.WriteLine("Name: {0}, Article: {1}", author.FirstName, author.ArticleName);
            }
        }
    }
}
