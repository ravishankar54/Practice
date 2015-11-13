using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcWebApiApplication.Controllers
{
    public class HomeController : AsyncController
    {
        private readonly object _lock = new object();
        public void IndexAsync()
        {
            AsyncManager.OutstandingOperations.Increment(2);
            Operation1();
            Operation2();
        }
        public ActionResult IndexCompleted(string Operation1, string Operation2)
        {
            ViewData["Operation1"] = Operation1;
            ViewData["Operation2"] = Operation2;
            return View("Index");
        }
        void Operation1()
        {
            lock (_lock)
            {
                AsyncManager.Parameters["Operation1"] = "Result1";
            }
            //last line of this method

            AsyncManager.OutstandingOperations.Decrement();
        }
        void Operation2()
        {
            lock (_lock)
            {
                AsyncManager.Parameters["Operation2"] = "Result2";
            }
            //last line of this method

            AsyncManager.OutstandingOperations.Decrement();
        }
    }
}
