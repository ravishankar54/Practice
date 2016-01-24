using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EqualityAndComparison
{
    class Program
    {
        static void Main(string[] args)
        {
            var dsub = new DelegateSubscriber();
            dsub.DelegateCall();
            //MyEvtClient cc = new MyEvtClient();
            //cc.oo.mm();

            //Publisher publisher = new Publisher();
            //Subscriber subscriber = new Subscriber(publisher);
            //publisher.Add(new Product
            //{
            //    ProductName = "Complan",
            //    Price = 20
            //});
            //publisher.Add(new Product
            //{
            //    ProductName = "Horlics",
            //    Price = 120
            //});
            //publisher.Add(new Product
            //{
            //    ProductName = "Boost",
            //    Price = 200
            //});
            //subscriber.UnSubscribeEvent();
            Console.ReadKey();
        }
    }

    public class Test
    {
        public void Method()
        {
            short i16 = new short();//int16
            int i32 = new int();//int32
            long i64 = new long();//int64
            float f = new float();//Single
            decimal d = new decimal();//Decimal
            double db = new double();//Double
        }
        public void Go()
        {
            Thing x = new Animal();
            ((Animal)x).Weight = 34;
            Console.WriteLine(((Animal)x).Weight);
            Switcharoo(ref x);
            Console.WriteLine(((Animal)x).Weight);// will not work

            Console.WriteLine("x is Animal    :   " + (x is Animal).ToString());
            Console.WriteLine("x is Vegetable :   " + (x is Vegetable).ToString());
        }

        public void Switcharoo(ref Thing pValue)
        {
            ((Animal)pValue).Weight = 35;
            pValue = new Vegetable();
        }

        public void DudeTest()
        {
            Dude Bill = new Dude();
            Bill.Name = "Bill";
            Bill.LeftShoe = new Shoe();
            Bill.RightShoe = new Shoe();
            Bill.LeftShoe.Color = Bill.RightShoe.Color = "Blue";

            Dude Ted = Bill.Clone() as Dude;
            Ted.Name = "Ted";
            Ted.LeftShoe.Color = Ted.RightShoe.Color = "Red";

            Console.WriteLine(Bill.ToString());
            Console.WriteLine(Ted.ToString());
        }
    }

    public class Thing
    {
    }

    public class Animal : Thing
    {
        public int Weight;
    }

    public class Vegetable : Thing
    {
        public int Length;
    }


}
