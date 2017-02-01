using System.Collections.Generic;

namespace ExamTest
{
    //public abstract class Vehicle
    //{
    //    public int MaxSpeed { get; set; }

    //    public virtual void Drive()
    //    {
    //        Console.WriteLine("I am drving the Vehicle");
    //    }
    //}

    //public class Car: Vehicle
    //{
    //    public override void Drive()
    //    {
    //        Console.WriteLine("I am drving the Car");
    //    }
    //}
    public class Vehicle
    {
        public int MaxSpeed;
        public static string Country;
        public Vehicle(int maxSpeed)
        {

            this.MaxSpeed = maxSpeed;
            Country = "UK";
        }

        public class Car : Vehicle
        {
            List<Vehicle> list;
            List<Car> list2;
            public string Transmission;
            public Car(int maxSpeed, string transmission) : base(maxSpeed)
            {
                this.MaxSpeed = 100;
                this.Transmission = transmission;
            }
            static Car()
            {
                Country = "USA";
            }
        }
    }
}
