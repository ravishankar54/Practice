using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EqualityAndComparison
{
    public delegate void Completed(string msg);
    public class DelegatePublisher
    {
        public void Add(int a, int b, Completed msg)
        {
            msg("Result sum is " + (a + b));
        }
    }

    public class DelegateSubscriber
    {
        public void DelegateCall()
        {
            DelegatePublisher dpub = new DelegatePublisher();
            dpub.Add(10, 12, Print);
        }

        private void Print(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
