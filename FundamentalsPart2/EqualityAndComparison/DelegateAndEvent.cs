using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EqualityAndComparison
{
    public class DelegateAndEvent
    {
        public delegate void MyEventHandler(object sender, EventArgs args);
        public event MyEventHandler MyEvent
        {
            add
            {
                Console.WriteLine("add operation");
            }
            remove
            {
                Console.WriteLine("remove operation");
            }
        }
    }

    public class DelegateAndEventTest
    {
        public void TestEvent()
        {
            DelegateAndEvent myTest = new DelegateAndEvent();
            myTest.MyEvent += myTest_MyEvent;
            myTest.MyEvent -= myTest_MyEvent;
        }
        public void myTest_MyEvent(object sender, EventArgs e)
        {
        }
    }

    public delegate void EventHandler(object sender, EventArgs e);
    public class Publisher
    {
        public Publisher()
        {
            Products = new List<Product>();
        }
        public List<Product> Products { get; set; }

        public event EventHandler ProdcutAddedInfo;
        protected virtual void OnChanged(EventArgs e)
        {
            if (ProdcutAddedInfo != null) ProdcutAddedInfo(this, e);
        }
        public virtual void Add(Product product)
        {
            Products.Add(product);
            OnChanged(EventArgs.Empty);
        }
        public virtual void Clear()
        {
            OnChanged(EventArgs.Empty);
        }
    }
    public class Subscriber
    {
        private Publisher publishers;
        public Subscriber(Publisher publisher)
        {
            this.publishers = publisher;
            publishers.ProdcutAddedInfo += publishers_ProdcutAddedInfo;
        }
        void publishers_ProdcutAddedInfo(object sender, EventArgs e)
        {
            if (sender == null)
            {
                Console.WriteLine("No New Product Added.");
                return;
            }
            Console.WriteLine("A New Prodct Added.");
        }
        public void UnSubscribeEvent()
        {
            publishers.ProdcutAddedInfo -= publishers_ProdcutAddedInfo;
        }
    }

    public class MyEvt
    {
        public delegate void t(Object sender, MyArgs e);

        // declare a delegate

        public event t tEvt; //declares an event for the delegate

        public void mm()
        {
            //function that will raise the callback
            MyArgs r = new MyArgs();
            tEvt(this, r); //calling the client code
        }

        public MyEvt()
        {
        }

    }

    //arguments for the callback

    public class MyArgs : EventArgs
    {
        public MyArgs()
        {
        }
    }

    public class MyEvtClient
    {
        public MyEvt oo;

        public MyEvtClient()
        {
            this.oo = new MyEvt();
            this.oo.tEvt += new MyEvt.t(oo_tt);
        }

        //this code will be called from the server

        public void oo_tt(object sender, MyArgs e)
        {
            Console.WriteLine("yes");
            Console.ReadLine();
        }
    }
}
