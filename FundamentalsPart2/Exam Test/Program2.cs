using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamTest
{
    public class Program2
    {
        public static void ChangeTheString(string weather) { weather = "sunny"; }
        public static void ChangeTheArray(string[] rainyDays)
        {
            rainyDays[1] = "Sunday";
        }
        public static void ChangeTheStructure(Forecast forecast)
        {
            forecast.Temperature = 35;
        }
        static void Main(string[] args)
        {
            string weather = "rainy";
            ChangeTheString(weather);
            Console.WriteLine("The weather is " + weather);

            string[] raindays = new[] { "Monday", "Friday" };
            ChangeTheArray(raindays);
            Console.WriteLine("The rainy days were on " + raindays[0] + " and " + raindays[1]);

            Forecast forecast = new Forecast { Pressure = 700, Temperature = 20 };
            ChangeTheStructure(forecast);
            Console.WriteLine("The temperature is " + forecast.Temperature + " 'C");

            Console.ReadKey();
        }
    }

    public struct Forecast
    {
        public int Temperature { get; set; }
        public int Pressure { get; set; }
    }
    public struct BaseStructure
    {

    }
    public struct Structure : IInterface
    {

    }
    public interface IInterface
    {

    }

    public class BaseClass
    {

    }

    public class AbstractClass
    {

    }
}
